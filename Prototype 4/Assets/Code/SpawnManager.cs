using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject thunderenemyPrefab;
    public GameObject BigenemyPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 2;
    public GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab,GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(thunderenemyPrefab, GenerateSpawnPosition(), thunderenemyPrefab.transform.rotation);
        }

        int index = Random.Range(0, 10);
        if (index > 4)
        {
            Instantiate(BigenemyPrefab, GenerateSpawnPosition(), BigenemyPrefab.transform.rotation);
        }

    }
}
