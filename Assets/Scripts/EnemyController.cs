using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : SingletonManager<EnemyController>
{
    
   // public List<Enemy> enemy;
    public List<Transform> leftWayPointsList;
    public List<Transform> rightWayPointsList;
    public List<Transform> frontWayPointsList;
    public List<Transform> spawnPoints;

    [HideInInspector] public int randomSpawnPos;

    private bool enemyActive;
    private bool isEnemyDead = false;
    




    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
       
        
    }

    private void Update()
    {
        //if (!enemyActive)
        // return;
        //EnemyAttackDirection();
    }

 

    void EnemySpawn()
    {
        randomSpawnPos = Random.Range(0, spawnPoints.Count);
        //PoolManager.Instance.SpawnInWorld("Spider", spawnPoints[randomSpawnPos].position, spawnPoints[randomSpawnPos].rotation);
        //PoolManager.Instance.SpawnInWorld("StoneMonster", spawnPoints[randomSpawnPos].position, spawnPoints[randomSpawnPos].rotation);
        
    }



    //void EnemyAttackDirection()
    //{
    //    if (GameController.Instance.randomSpawnPos == 0)
    //        EnemyComesFromLeft();

    //    else if (GameController.Instance.randomSpawnPos == 1)
    //        EnemyComesFromFront();

    //    else
    //        EnemyComesFromRight();
    //}







}
