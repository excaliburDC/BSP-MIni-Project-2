using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;

   
    private Animator enemyAnim;

    public int nextLeftWayPoint;
    public int nextRightWayPoint;
    public int nextFrontWayPoint;
    [HideInInspector] public int randomSpawnPos;


    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
            EnemyAttackDirection();

        else
            return;

 

    }

    public void EnemyAttackDirection()
    {

        if (randomSpawnPos == 0)
            EnemyComesFromLeft();
        if (randomSpawnPos == 1)
            EnemyComesFromFront();
        if (randomSpawnPos == 2)
            EnemyComesFromRight();
       
    }

    void EnemyComesFromLeft()
    {
        Transform leftDest = EnemyController.Instance.leftWayPointsList[nextLeftWayPoint];

        Vector3 dir = leftDest.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);
        enemyAnim.SetBool("IsMoving", true);

        if (Vector3.Distance(transform.position, leftDest.position) <= 1f)
        {
            if (nextLeftWayPoint >= EnemyController.Instance.leftWayPointsList.Count - 1)
            {
                StartEnemyAttack();
                return;
            }

            nextLeftWayPoint++;
            
        }


        
    }

    void EnemyComesFromRight()
    {

       Transform rightDest = EnemyController.Instance.rightWayPointsList[nextRightWayPoint];

        Vector3 dir = rightDest.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);
        enemyAnim.SetBool("IsMoving", true);

        if (Vector3.Distance(transform.position, rightDest.position) <= 1f)
        {
            if (nextRightWayPoint >= EnemyController.Instance.rightWayPointsList.Count - 1)
            {
                StartEnemyAttack();
                return;
            }

            nextRightWayPoint++;
        }
    }

    void EnemyComesFromFront()
    {
        Transform frontDest = EnemyController.Instance.frontWayPointsList[nextFrontWayPoint];

        Vector3 dir = frontDest.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);
        enemyAnim.SetBool("IsMoving", true);

        if (Vector3.Distance(transform.position, frontDest.position) <= 1f)
        {
            if (nextFrontWayPoint >= EnemyController.Instance.frontWayPointsList.Count - 1)
            {
                StartEnemyAttack();
                return;
            }

            nextFrontWayPoint++;
        }
    }

    void StartEnemyAttack()
    {
        enemyAnim.SetBool("IsMoving", false);
        enemyAnim.SetTrigger("Attack");
        Destroy(this.gameObject);
        WaveSpawner.enemiesInWaveLeft--;
    }


}
