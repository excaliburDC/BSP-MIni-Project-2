using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : SingletonManager<EnemyController>
{
    

    public List<Transform> leftWayPointsList;
    public List<Transform> rightWayPointsList;
    public List<Transform> frontWayPointsList;


    
    




    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
       
        
    }

    private void Update()
    {
        //timeSinceLastSpawned += Time.deltaTime;
        //if(timeSinceLastSpawned>=spawnRate)
        //{
        //    EnemySpawn();
        //    timeSinceLastSpawned = 0f;
        //}
        //if (!enemyActive)
        // return;
        //EnemyAttackDirection();
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
