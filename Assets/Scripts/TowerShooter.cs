using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    public Tower tower;
    public Transform target;
    public Transform towerHead;
    public Transform weaponSpawnPoint;
    public ParticleSystem shootEffect;
    public string enemyTag = "Enemy";

    private float shootCountdown = 0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

   
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

      

        if (nearestEnemy != null && shortestDistance <= tower.towerRange)
        {
            target = nearestEnemy.transform;
           // targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

  
    // Update is called once per frame
    void Update() 
    {
        if(gameObject.activeInHierarchy && !GameController.Instance.waveStarted)
        {
            Destroy(this.gameObject);
            return;
        }

        if (target == null)
            return;

        LockOnTarget();

        if (shootCountdown <= 0f)
        {
            Shoot();
            shootCountdown = tower.attackRate;
        }

        shootCountdown -= Time.deltaTime;
    }


    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(towerHead.rotation, lookRotation, Time.deltaTime * tower.rotateSpeed).eulerAngles;
        towerHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        ShootEffect();

        GameObject gObj =PoolManager.Instance.SpawnInWorld(tower.weaponName, weaponSpawnPoint.position, weaponSpawnPoint.rotation);

        Shoot s = gObj.GetComponent<Shoot>();

        if (s != null)
            s.FindTarget(target);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tower.towerRange);
    }

    void ShootEffect()
    {
        if (shootEffect == null)
        {
            Debug.Log("This weapon does not require a shoot effect");
            return;
        }
        shootEffect.Play();
    }
}
