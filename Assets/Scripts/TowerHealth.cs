using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public HealthBar towerHealthBar;
    public int towerHP;
    public bool towerDestroyed = false;

    private int currentTowerHealth;


    private void Start()
    {
        currentTowerHealth = towerHP;
        towerHealthBar.SetMaxHealth(towerHP);
    }


    public void TakeDamage(int damage)
    {
        currentTowerHealth -= damage;
        Debug.Log("Health: " + currentTowerHealth);
        towerHealthBar.SetHealth(currentTowerHealth);
        if (currentTowerHealth <= 0)
        {
            currentTowerHealth = 0;
            TowerDestroyed();
        }

    }

    void TowerDestroyed()
    {
        towerDestroyed = true;
        Destroy(this.gameObject);
        GameController.Instance.GameOver();
    }
}
