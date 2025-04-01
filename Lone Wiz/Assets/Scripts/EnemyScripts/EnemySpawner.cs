using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redSlimePrefab, blueSlimePrefab, eyeballPrefab, dragonPrefab, greenSlimePrefab;
    public Transform[] spawnPoints;

    private Dictionary<string, int> maxEnemiesPerType;
    private Dictionary<string, int> activeEnemies;

    // Initialize dictionaries in Awake
    void Awake()
    {
        maxEnemiesPerType = new Dictionary<string, int>
        {
            { "GreenSlime", 10 },
            { "RedSlime", 10 },
            { "BlueSlime", 0 },
            { "Eyeball", 3 },
            { "Dragon", 0 }
        };

        activeEnemies = new Dictionary<string, int>
        {
            { "GreenSlime", 0 },
            { "RedSlime", 0 },
            { "BlueSlime", 0 },
            { "Eyeball", 0 },
            { "Dragon", 0 }
        };
    }

    public int SpawnWave(int waveNumber)
    {
        int totalSpawned = 0;

        //Debug.Log("Line 30!");

        AdjustEnemyLimits(waveNumber);

        //Debug.Log("Line 34!");

        foreach (var enemyType in maxEnemiesPerType.Keys)
        {
            if (!maxEnemiesPerType.ContainsKey(enemyType))
            {
                //Debug.LogError($"Enemy type {enemyType} is missing from maxEnemiesPerType!");
                continue;
            }

            int maxEnemies = maxEnemiesPerType[enemyType];
            if (maxEnemies <= 0)
            {
                //Debug.Log($"Skipping {enemyType} since max allowed is 0.");
                continue;
            }

            //Debug.Log($"Spawning: {enemyType}, Max Allowed: {maxEnemies}");

            // Adjust the range to ensure valid values
            int spawnAmount = Random.Range(1, maxEnemies + 1); // Inclusive range

            for (int i = 0; i < spawnAmount; i++)
            {
                if (SpawnEnemy(enemyType))
                    totalSpawned++;
            }
            //Debug.Log("Line 53!");
        }
        //Debug.Log("Line 63!");
        return totalSpawned;
    }

    bool SpawnEnemy(string enemyType)
    {
        if (activeEnemies[enemyType] >= maxEnemiesPerType[enemyType])
            return false;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemyPrefab = GetEnemyPrefab(enemyType);

        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            BaseEnemy enemyScript = enemy.GetComponent<BaseEnemy>();
            if (enemyScript != null)
            {
                enemyScript.OnDeath += () => GameManager.Instance.EnemyDefeated();
            }
            activeEnemies[enemyType]++;
            return true;
        }
        return false;
    }

    void AdjustEnemyLimits(int wave)
    {
        if (wave < 3)
        {
            // Early waves: Only Green and Red Slimes
            maxEnemiesPerType["GreenSlime"] = 10;
            maxEnemiesPerType["RedSlime"] = 10;
            maxEnemiesPerType["Eyeball"] = 0;  
            maxEnemiesPerType["BlueSlime"] = 0;
            maxEnemiesPerType["Dragon"] = 0;  
        }
        else if (wave >= 3)
        {
            maxEnemiesPerType["Eyeball"] = 3; // Introduce Eyeballs at Wave 3
        }
        if (wave >= 6)
        {
            maxEnemiesPerType["GreenSlime"] = 0; // Remove Green Slime
            maxEnemiesPerType["BlueSlime"] = 5;  // Introduce Blue Slimes
        }
        if (wave >= 10)
        {
            maxEnemiesPerType["Eyeball"] += 2;  // Increase Eyeballs
            maxEnemiesPerType["Dragon"] = 1;    // Introduce Dragons at Wave 10
        }
    }

    GameObject GetEnemyPrefab(string enemyType)
    {
        switch (enemyType)
        {
            case "GreenSlime": return greenSlimePrefab;
            case "RedSlime": return redSlimePrefab;
            case "BlueSlime": return blueSlimePrefab;
            case "Eyeball": return eyeballPrefab;
            case "Dragon": return dragonPrefab;
            default: return null;
        }
    }
}
