using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentWave = 1;
    public int totalEnemies;
    public int enemiesRemaining;

    public AudioClip waveStartSound;
    public AudioClip waveEndSound;
    private AudioSource audioSource;

    public EnemySpawner enemySpawner;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        audioSource.PlayOneShot(waveStartSound);
        enemiesRemaining = enemySpawner.SpawnWave(currentWave);
        yield return null;
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            StartCoroutine(EndWave());
        }
    }

    IEnumerator EndWave()
    {
        audioSource.PlayOneShot(waveEndSound);
        yield return new WaitForSeconds(2f); // Pause before starting next wave
        currentWave++;
        StartCoroutine(StartWave());
    }
}
