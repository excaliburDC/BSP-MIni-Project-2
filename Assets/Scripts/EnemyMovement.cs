using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;

    private NavMeshAgent agent;
    private Animator enemyAnim;

    [HideInInspector] public int nextLeftWayPoint;
    [HideInInspector] public int nextRightWayPoint;
    [HideInInspector] public int nextFrontWayPoint;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
        agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
            EnemyAttackDirection();

        else
            return;

    }

    void EnemyAttackDirection()
    {
        if (WaveSpawner.Instance.spawnPointIndex == 0)
            EnemyComesFromLeft();
        else if (WaveSpawner.Instance.spawnPointIndex == 1)
            EnemyComesFromFront();
        else if (WaveSpawner.Instance.spawnPointIndex == 2)
            EnemyComesFromRight();
        else
            return;
    }

    void EnemyComesFromLeft()
    {
        agent.destination = EnemyController.Instance.leftWayPointsList[nextLeftWayPoint].position;
        agent.speed = enemy.moveSpeed;
        enemyAnim.SetBool("IsMoving", true);
        agent.isStopped = false;

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            nextLeftWayPoint = (nextLeftWayPoint + 1);
        }
    }

    void EnemyComesFromRight()
    {
        agent.destination = EnemyController.Instance.rightWayPointsList[nextRightWayPoint].position;
        agent.speed = enemy.moveSpeed;
        enemyAnim.SetBool("IsMoving", true);
        agent.isStopped = false;

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            nextRightWayPoint = (nextRightWayPoint + 1);
        }
    }

    void EnemyComesFromFront()
    {
        agent.destination = EnemyController.Instance.frontWayPointsList[nextFrontWayPoint].position;
        agent.speed = enemy.moveSpeed;
        enemyAnim.SetBool("IsMoving", true);
        agent.isStopped = false;

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            nextFrontWayPoint = (nextFrontWayPoint + 1);
        }
    }


}
