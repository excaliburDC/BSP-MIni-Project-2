﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public HealthBar towerHealthBar;
    public ParticleSystem destroyedEffect;
    public int towerHP;
    public int TowerNo;
    public bool towerDestroyed = false;

    public int currentTowerHealth;
   

    private void Start()
    {
        currentTowerHealth = towerHP;    
        PlayerPrefs.SetInt("TowerHP", towerHP);
        PlayerPrefs.SetInt("TowerHealth", currentTowerHealth);
        towerHealthBar.SetMaxHealth(towerHP);

       
    }

    public void Update()
    {
        PlayerPrefs.SetInt("TowerHealth", currentTowerHealth);
    }
    public void TakeDamage(int damage)
    {
        currentTowerHealth -= damage;

        //if (GameController.Instance.levelComplete)
        //{
        //    GameController.Instance.finalTowerHealth = currentTowerHealth;
        //}

        currentTowerHealth = CheckUpgradeValue(currentTowerHealth);
        Debug.Log("Health: " + currentTowerHealth);
        towerHealthBar.SetHealth(currentTowerHealth);
        if (currentTowerHealth <= 0)
        {
            currentTowerHealth = 0;
            TowerDestroyed();
        }
        //can use this to show the stars
        PlayerPrefs.SetInt("TowerHealth", currentTowerHealth);

    }
    public int CheckUpgradeValue(int currenthealth)
    {
       switch(PlayerPrefs.GetInt("UpgradeLevel" + TowerNo))
        {
            case 1:
                currenthealth += 1;
                break;
            case 2:
                currenthealth += 2;
                break;
            case 3:
                currenthealth += 3;
                break;
            case 4:
                currenthealth += 4;
                break;
            case 5:
                currenthealth += 5;
                break;
            default:
                Debug.Log("Default");
                break;
        }
        Debug.LogError("upgrade "+TowerNo +" : "+ PlayerPrefs.GetInt("UpgradeLevel" + TowerNo));
        Debug.LogError(currenthealth);
        return currenthealth;
    }
    void TowerDestroyed()
    {
        if (destroyedEffect == null)
            Debug.Log("No need for a destroyed effect on this");

        towerDestroyed = true;
        Instantiate(destroyedEffect);
        Destroy(this.gameObject);
        GameController.Instance.GameOver();
    }
    
}
