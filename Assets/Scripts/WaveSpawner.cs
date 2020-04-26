using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave
{
    public int EnemiesPerWave;
    public GameObject enemyPrefab;
}
public class WaveSpawner : SingletonManager<WaveSpawner>
{
    public List<Wave> waves; 
    public List<Transform> spawnPoints;
   
    public float timeBetweenEnemies = 2f;

    

    private int totalEnemiesInCurrentWave;
    private int enemiesInWaveLeft;
    private int spawnedEnemies;
    private int currentWave;
    private int totalWaves;

    void Start()
    {
        currentWave = -1; 
        totalWaves = waves.Count - 1; 
        
    }

    private void Update()
    {
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWave++;
        
        if (currentWave > totalWaves)
        {
            return;
        }
        totalEnemiesInCurrentWave = waves[currentWave].EnemiesPerWave;
        enemiesInWaveLeft = 0;
        spawnedEnemies = 0;
        StartCoroutine(SpawnEnemies());
    }
    
    IEnumerator SpawnEnemies()
    {
        GameObject enemy = waves[currentWave].enemyPrefab;
        while (spawnedEnemies < totalEnemiesInCurrentWave)
        {
            spawnedEnemies++;
            enemiesInWaveLeft++;
            int spawnPointIndex = Random.Range(0, spawnPoints.Count);


            GameObject gObj = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            gObj.GetComponent<EnemyMovement>().randomSpawnPos = spawnPointIndex;
            
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        yield return null;
    }

    // called by an enemy when they're defeated
    public void EnemyDefeated()
    {
        enemiesInWaveLeft--;

        // We start the next wave once we have spawned and defeated them all
        if (enemiesInWaveLeft == 0 && spawnedEnemies == totalEnemiesInCurrentWave)
        {
            StartNextWave();
        }
    }
}
