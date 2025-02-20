using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redSlimePrefab, blueSlimePrefab, eyeballPrefab, dragonPrefab;
    public Transform[] spawnPoints;

    private Dictionary<string, int> maxEnemiesPerType;
    private Dictionary<string, int> activeEnemies;

    void Start()
    {
        maxEnemiesPerType = new Dictionary<string, int>
        {
            { "RedSlime", 10 }, { "BlueSlime", 0 }, { "Eyeball", 3 }, { "Dragon", 0 }
        };

        activeEnemies = new Dictionary<string, int>
        {
            { "RedSlime", 0 }, { "BlueSlime", 0 }, { "Eyeball", 0 }, { "Dragon", 0 }
        };
    }

    public int SpawnWave(int waveNumber)
    {
        int totalSpawned = 0;

        AdjustEnemyLimits(waveNumber);

        foreach (var enemyType in maxEnemiesPerType.Keys)
        {
            int spawnAmount = Random.Range(1, maxEnemiesPerType[enemyType]);

            for (int i = 0; i < spawnAmount; i++)
            {
                if (SpawnEnemy(enemyType))
                    totalSpawned++;
            }
        }

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
        if (wave >= 3) maxEnemiesPerType["Dragon"] = 1;
        if (wave >= 6) maxEnemiesPerType["RedSlime"] = 0;
        if (wave >= 6) maxEnemiesPerType["BlueSlime"] = 5;
        if (wave >= 10) maxEnemiesPerType["Eyeball"] += 2;
    }

    GameObject GetEnemyPrefab(string enemyType)
    {
        switch (enemyType)
        {
            case "RedSlime": return redSlimePrefab;
            case "BlueSlime": return blueSlimePrefab;
            case "Eyeball": return eyeballPrefab;
            case "Dragon": return dragonPrefab;
            default: return null;
        }
    }
}
