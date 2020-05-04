using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInitalize : MonoBehaviour
{
    public string userName;
    public string password;
    public int coins;
    public int[] price;
    public int[] upgradeLevel;
    public float[] progression;
    public int[] levelStars;
    int i;

    public void InitializeValue(string username,string passwordval)
    {
        userName = username;
        password = passwordval;
         
        PlayerPrefs.SetInt("Coins",0);
       
        for(i = 1;i<= 5;i++)
        {
            PlayerPrefs.SetFloat("Progression" + i, 0f);
            PlayerPrefs.SetInt("UpgradeLevel" + i, 1);
            PlayerPrefs.SetInt("Price" + i, 10);
        }
        for (i=1;i<9;i++)
        {
            PlayerPrefs.SetInt("Lv" + i, 0);
        }
        updateValue();
    }
    public void updateValue()
    {
        userName = PlayerPrefs.GetString("UserName");
        password = PlayerPrefs.GetString("Password");
        coins = PlayerPrefs.GetInt("Coins");

        for (i = 1; i <= 5; i++)
        {
            progression[i-1] = PlayerPrefs.GetFloat("Progression" + i);
            upgradeLevel[i-1] = PlayerPrefs.GetInt("UpgradeLevel" + i);
            price[i-1] = PlayerPrefs.GetInt("Price" + i);
        }
        for (i = 1; i < 9; i++)
        {
            levelStars[i - 1] = PlayerPrefs.GetInt("Lv" + i);
        }
    }
   
  
}
