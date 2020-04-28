using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeOperation : MonoBehaviour
{
    public Text msg;
    public Text coins;
    public Text Price;
    public Button UpgradeBtn;
    public Button BuyBtn;
    public int TowerNo;
    public int UpgradationTimes;
    public Slider slider;

    private float fillspeed = 0.5f;
    private float targetProgress =0.0f;
    private int noOfBtnClick=1;
    private int price = 10;
    private int havingCoins;

    public void Awake()
    {
        
        targetProgress = PlayerPrefs.GetFloat("Progression" + TowerNo);
        price = PlayerPrefs.GetInt("Price" + TowerNo);
        noOfBtnClick = PlayerPrefs.GetInt("UpgradeLevel" + TowerNo);
       
    }
    public void Update()
    {
        targetProgress = PlayerPrefs.GetFloat("Progression" + TowerNo);
        havingCoins = PlayerPrefs.GetInt("Coins");
        coins.text = "Coins: " + havingCoins.ToString();
        Price.text = "Price: " + price.ToString();
        msg.color = Color.blue;
        if (slider.value < targetProgress)
            slider.value += fillspeed * Time.deltaTime;
       
    }
   
    public void Upgrade()
    {
        if (PlayerPrefs.GetInt("UpgradeLevel" + TowerNo) >= UpgradationTimes+1)
        {
            UpgradeBtn.interactable = false;
            msg.color = Color.green;
            msg.text = "Upgrade complete";
           Debug.Log("Upgrade complete");
            return;
        }
       
        if (havingCoins > price  && price >0)
        {

            if (PlayerPrefs.GetInt("UpgradeLevel" + TowerNo) >= 1)
            {
                msg.text = "Upgradation " + PlayerPrefs.GetInt("UpgradeLevel" + TowerNo).ToString();
                price *= 2;
                havingCoins -= price;
                Price.text = "Price: " + price.ToString();
                ++noOfBtnClick;
                PlayerPrefs.SetInt("Coins", havingCoins);
                PlayerPrefs.SetInt("Price" + TowerNo, price);
                PlayerPrefs.SetInt("UpgradeLevel" + TowerNo, noOfBtnClick);
                coins.text = "Coins: " + PlayerPrefs.GetInt("Coins").ToString();
                Price.text = "Price: " + price.ToString();
                if(gameObject.tag =="Update5")
                {
                    targetProgress += 0.2f;
                    PlayerPrefs.SetFloat("Progression" + TowerNo,targetProgress);
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
    public void ResetAll()
    {
        PlayerPrefs.SetFloat("Progression" + TowerNo, 0f);
        PlayerPrefs.SetInt("Coins", 1000);
        PlayerPrefs.SetInt("UpgradeLevel" + TowerNo, 1);
        PlayerPrefs.SetInt("Price" + TowerNo, 10);
    }

}
