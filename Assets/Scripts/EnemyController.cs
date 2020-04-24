using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : SingletonManager<EnemyController>,IPooledObject
{
    public List<Transform> spawnPoints;
    public Enemy enemy;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator enemyAnim;
    [HideInInspector] public List<Transform> leftWayPointsList;
    [HideInInspector] public List<Transform> rightWayPointsList;
    [HideInInspector] public List<Transform> frontWayPointsList;

    private bool enemyActive;

    

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }

    public void OnObjectSpawner()
    {

    }

    public void SetupAI(bool activateEnemy, List<Transform> leftWayPoints, List<Transform> rightWayPoints, List<Transform> frontWayPoints)
    {
        leftWayPointsList = leftWayPoints;
        rightWayPointsList = rightWayPoints;
        frontWayPointsList = frontWayPoints;
        enemyActive = activateEnemy;

        if (enemyActive)
        {
            agent.enabled = true;
        }
        else
        {
            agent.enabled = false;
        }
    }

    void EnemySpawn()
    {
        int randomSpawnPos = Random.Range(0, spawnPoints.Count);

        if (randomSpawnPos == 0)
            EnemyComesFromLeft();

        else if (randomSpawnPos == 1)
            EnemyComesFromFront();

        else
            EnemyComesFromRight();
    }

    void EnemyComesFromLeft()
    { 

    }

    void EnemyComesFromRight()
    {

    }

    void EnemyComesFromFront()
    {

    }





}
