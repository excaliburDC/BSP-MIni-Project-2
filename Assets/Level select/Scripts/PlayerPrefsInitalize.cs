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

    public void Awake()
    {
       // price[0] = 0;
       // upgradeLevel[0] = 0;
        //progression[0] = 0;
        //levelStars[0] = 0;
    }
    public void Update()
    {
        userName = PlayerPrefs.GetString("UserName");
        password = PlayerPrefs.GetString("Password");
        coins = PlayerPrefs.GetInt("Coins");

        //for (i = 1; i <= 5; i++)
        //{
        //    //progression[i] = PlayerPrefs.GetFloat("Progression" + i);
        //    upgradeLevel[i] = PlayerPrefs.GetInt("UpgradeLevel" + i);
        //    price[i] = PlayerPrefs.GetInt("Price" + i);
        //}
        //for (i = 1; i < 9; i++)
        //{
        //    levelStars[i] = PlayerPrefs.GetInt("Lv" + i);
        //}
    }
    public void SavePlayer()
    {
        Debug.Log("Save fn");
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        Debug.Log("Load fn");
        PlayerData data = SaveSystem.LoadPlayer();
        userName = data.userName;
        password = data.password;
        coins = data.coins;
        //for (i = 1; i <= 5; i++)
        //{
        //    //progression[i] = data.progression[i];
        //    upgradeLevel[i] = data.upgradeLevel[i];
        //    price[i] = data.price[i];
        //}
        //for (i = 1; i < 9; i++)
        //{
        //    levelStars[i] = data.levelStars[i];
        //}

    }
   
  
}
