﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UpgradeOperation : MonoBehaviour
{
    public Text msg;
    public Text coins;
    public Text Price;
    public Button UpgradeBtn;
    public int TowerNo;
    public int UpgradationTimes;
    public Slider slider;
    public GameObject Lock;
    public ParticleSystem particleUpdate;

    private float fillspeed = 0.5f;
    private float targetProgress =0.0f;
    private int noOfBtnClick=1;
    private int price = 10;
    private int havingCoins;
    private bool ToActivate;
   

    public void Awake()
    {
        ResetAll();
        particleUpdate = GameObject.Find("ParticlesForUpdate").GetComponent<ParticleSystem>();
        targetProgress = PlayerPrefs.GetFloat("Progression" + TowerNo);
        price = PlayerPrefs.GetInt("Price" + TowerNo);
        noOfBtnClick = PlayerPrefs.GetInt("UpgradeLevel" + TowerNo);
        Price.text = "Price: " + price.ToString();
        Lock.SetActive(true);

    }
    public void Update()
    {
        targetProgress = PlayerPrefs.GetFloat("Progression" + TowerNo);
        havingCoins = PlayerPrefs.GetInt("Coins");
        coins.text = "Coins: " + havingCoins.ToString();
        msg.color = Color.blue;

        if (slider.value < targetProgress)
        {
            slider.value += fillspeed * Time.deltaTime;
            if (!particleUpdate.isPlaying)
                particleUpdate.Play();
        }
        else
        {
            particleUpdate.Stop();
        }
        CheckActivation();
    }
   public void CheckActivation()
    {
        if (PlayerPrefs.GetInt("Lv6") > 0)
        {
            ToActivate = true;
            Lock.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Lv2") > 0 && TowerNo <= 2)
        {
            ToActivate = true;
            Lock.SetActive(false);
        }
       
    }
    public void Upgrade()
    {
        
        if (ToActivate == true)
        {
            if ((havingCoins - price) > 0 && price > 0)
            {
                ToActivate = false;
                if (PlayerPrefs.GetInt("UpgradeLevel" + TowerNo) >= 1)
                {
                    msg.text = "Upgradation " + PlayerPrefs.GetInt("UpgradeLevel" + TowerNo).ToString();
                    havingCoins = havingCoins - price;
                    price *= 2;

                    Price.text = "Price: " + price.ToString();
                    ++noOfBtnClick;
                    PlayerPrefs.SetInt("Coins", havingCoins);
                    PlayerPrefs.SetInt("Price" + TowerNo, price);
                    PlayerPrefs.SetInt("UpgradeLevel" + TowerNo, noOfBtnClick);
                    if (gameObject.tag == "Update5")
                    {
                        targetProgress += 0.2f;
                        PlayerPrefs.SetFloat("Progression" + TowerNo, targetProgress);
                        SliderFill(0.2f);
                    }
                    else
                    {
                        targetProgress += 0.33f;
                        PlayerPrefs.SetFloat("Progression" + TowerNo, targetProgress);
                        SliderFill(0.33f);
                    }
                    Debug.Log("progress " + targetProgress);
                }
            }
            else
            {
                msg.color = Color.red;
                msg.text = "coins not sufcient";
                Debug.Log("coins not sufcient ");
            }
            if (PlayerPrefs.GetInt("UpgradeLevel" + TowerNo) >= UpgradationTimes + 1)
            {
                Price.text = " ";
                UpgradeBtn.interactable = false;
                msg.color = Color.green;
                msg.text = "Upgrade complete";

                Debug.Log("Upgrade complete");
                return;
            }
        }
    }
    public void BuyHeart()
    {
        if (PlayerPrefs.GetInt("UpgradeLevel" + TowerNo) >= 1)
        {
            price += 5;
            Price.text = "Price: " + price.ToString();
            noOfBtnClick++;
        }
    }
    public void SliderFill(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
    public void LevelScene()
    {
        SceneManager.LoadSceneAsync("Level Selection");
        // SceneManager.LoadScene("Level Selection");
    }
    public void ResetAll()
    {
        PlayerPrefs.SetInt("Coins", 1000);
        PlayerPrefs.SetFloat("Progression" + TowerNo, 0f);
        PlayerPrefs.SetInt("UpgradeLevel" + TowerNo, 1);
        PlayerPrefs.SetInt("Price" + TowerNo, 10);
    }

}
