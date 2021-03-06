﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;
    public HealthBar enemyHealthBar;

    public int nextLeftWayPoint;
    public int nextRightWayPoint;
    public int nextFrontWayPoint;
    [HideInInspector] public int randomSpawnPos;
    public bool enemyDead = false;

    private TowerHealth towerHp;
    private Transform towerTransform;
    private int currentEnemyHealth;
    private Animator enemyAnim;
    private bool isAttacking = false;
    private float attackCountdown = 0f;



    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        currentEnemyHealth = enemy.health;
        enemyHealthBar.SetMaxHealth(enemy.health);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            
            EnemyAttackDirection();

            if(isAttacking) 
            {
                if (attackCountdown <= 0f)
                {
                    StartEnemyAttack();
                    attackCountdown = enemy.attackRate;
                   

                }
                //enemyAnim.SetBool("Attack", false);
                attackCountdown -= Time.deltaTime;
            }
            
        }

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
        if (enemyDead)
            return;

        //if (CheckNearbyTowers())
        //{
        //    AttackTower();
        //    return;
        //}


        Transform leftDest = EnemyController.Instance.leftWayPointsList[nextLeftWayPoint];

        Vector3 dir = leftDest.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, leftDest.position) <= 1f)
        {
            if (nextLeftWayPoint >= EnemyController.Instance.leftWayPointsList.Count - 1)
            {
                isAttacking = true;
                //StartEnemyAttack();

                return;
            }

            nextLeftWayPoint++;

        }




    }

    void EnemyComesFromRight()
    {
        if (enemyDead)
            return;

        //if (CheckNearbyTowers())
        //{
        //    AttackTower();
        //}

        Transform rightDest = EnemyController.Instance.rightWayPointsList[nextRightWayPoint];

        Vector3 dir = rightDest.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, rightDest.position) <= 1f)
        {
            if (nextRightWayPoint >= EnemyController.Instance.rightWayPointsList.Count - 1)
            {
                isAttacking = true;
                //StartEnemyAttack();
                return;
            }

            nextRightWayPoint++;
        }


    }

    void EnemyComesFromFront()
    {
        if (enemyDead)
            return;

        //if (CheckNearbyTowers())
        //{
        //   // AttackTower();

        //}

        Transform frontDest = EnemyController.Instance.frontWayPointsList[nextFrontWayPoint];

        Vector3 dir = frontDest.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);


        if (Vector3.Distance(transform.position, frontDest.position) <= 1f)
        {
            if (nextFrontWayPoint >= EnemyController.Instance.frontWayPointsList.Count - 1)
            {
                isAttacking = true;
                //StartEnemyAttack();
                return;
            }

            nextFrontWayPoint++;
        }



    }

    void AttackTower()
    {

        Vector3 dir = towerTransform.position - transform.position;
        transform.Translate(dir.normalized * enemy.moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, towerTransform.position) <= 1f)
        {
            isAttacking = true;
            
        }
    }

    private bool CheckNearbyTowers()
    {

        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward.normalized * enemy.searchRange, Color.red);

      
        if (Physics.SphereCast(transform.position, enemy.searchRange, transform.forward, out hit, 
                enemy.searchRange) && hit.collider.CompareTag("DefenseTower"))
        {
            Debug.Log(hit.transform.name);
            towerTransform = hit.transform;
            return true;

            
        }


        else
            return false;
        
    }

    void StartEnemyAttack()
    {
        if (towerHp.towerDestroyed)
        {
            isAttacking = false;
            enemyAnim.SetBool("Attack", false);
            return;

        }

        enemyAnim.SetBool("Attack", true);
        // isAttacking = true;
        towerHp.TakeDamage(enemy.attackPower);


        //Destroy(this.gameObject);
        // WaveSpawner.enemiesInWaveLeft--;
    }

    public void TakeDamage(int damage)
    {
        currentEnemyHealth -= damage;
        enemyHealthBar.SetHealth(currentEnemyHealth);
        if (currentEnemyHealth <= 0)
        {
            currentEnemyHealth = 0;
            EnemyDead();
        }
            
    }

   

    void EnemyDead()
    {

        enemyDead = true;
        isAttacking = false;
        
        StartCoroutine(WaitUntilDestroyed());
       

    }

    private IEnumerator WaitUntilDestroyed()
    {
        enemyAnim.SetBool("Attack", false);
        enemyAnim.SetTrigger("IsDead");
        
        CoinManager.UpdateCoins(enemy.coinAmount);
        yield return new WaitForSeconds(1f);
        WaveSpawner.enemiesInWaveLeft--;
        GameController.Instance.numEnemiesKilled++; //updates no of enemies killed for every enemy killed
        Destroy(this.gameObject);
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Weapon")
        {
            Debug.Log("Hit");
            Shoot s = col.gameObject.GetComponent<Shoot>();
            TakeDamage(s.weaponTower.attackPower);
        }

        if (col.gameObject.tag == "MainTower")
        {
            
           towerHp  = col.gameObject.GetComponent<TowerHealth>();
            
        }
    }



}
