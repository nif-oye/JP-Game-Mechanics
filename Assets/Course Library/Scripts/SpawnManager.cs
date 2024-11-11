using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    float bound = 9;
    public int enemyCount;
    public int waveNumber = 1;
    void Start()
    {
        // InvokeRepeating("Spawner", 2, 5);
        SpawnEnemyWave(waveNumber);
        InvokeRepeating("SpawnPowerup", 2, 30);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(-bound, bound);
        float z = Random.Range(-bound, bound);
        Vector3 spawnPos = new Vector3(x, 0, z);
        return spawnPos;
    }
}
