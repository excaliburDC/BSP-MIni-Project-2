using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaveSpawner : MonoBehaviour
{
   

    public List<Wave> waves; 
    public List<Transform> spawnPoints;
    public float timeBetweenWaves = 5f;
    public static int enemiesInWaveLeft;
    public int spawnedEnemies;
    public bool isWaveFinished;

   
    public float waveCountdown;
    public int totalEnemiesInCurrentWave;
    
    private int currentWave;
    private int totalWaves;
    

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0; 
        totalWaves = waves.Count - 1;
        
        
    }

    private void Update()
    {
        if(WaveDefeated())
            StartNextWave();

       
        
    }

    void StartNextWave()
    {
       
        if (currentWave > totalWaves)
        {
            currentWave = 0;
            //Debug.Log("Level Complete");
            return;
        }

        waveCountdown -= Time.deltaTime;
        Debug.Log("Time Left for Next Wave: " + waveCountdown);

        if(waveCountdown<=0)
        {
            totalEnemiesInCurrentWave = waves[currentWave].enemiesPerWave;
            enemiesInWaveLeft = 0;
            spawnedEnemies = 0;

            StartCoroutine(SpawnEnemies(waves[currentWave]));
            waveCountdown = timeBetweenWaves;
        }
        
    }
    
    IEnumerator SpawnEnemies(Wave enemyWave)
    {
        
        while (spawnedEnemies < totalEnemiesInCurrentWave)
        {
            int randomEnemyIndex = Random.Range(0, enemyWave.enemyPrefab.Count);
            spawnedEnemies++;
            enemiesInWaveLeft++;
            int spawnPointIndex = Random.Range(0, spawnPoints.Count);


            GameObject gObj = Instantiate(enemyWave.enemyPrefab[randomEnemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            gObj.GetComponent<EnemyMovement>().randomSpawnPos = spawnPointIndex;
            
            yield return new WaitForSeconds(enemyWave.timeBetweenEnemies);
        }
        yield return null;
    }

    // called by an enemy when they're defeated
    private bool WaveDefeated()
    {
        Debug.Log("Enemies left:" + enemiesInWaveLeft);
        // We start the next wave once we have spawned and defeated them all
        if (enemiesInWaveLeft == 0 && spawnedEnemies == totalEnemiesInCurrentWave)
        {
            
            currentWave++;
           
            return true;
          
        }

        return false;
     
    }
}
