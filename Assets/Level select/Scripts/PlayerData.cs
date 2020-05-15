using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string userName;
    public string password;
    public int coins;
    public int[] price;
    public int[] upgradeLevel;
    public float[] progression;
    public int[] levelStars;
    int i;
   public PlayerData()
    {
        progression[0] = 0;
        upgradeLevel[0] = 0;
        price[0] = 0;
        levelStars[0] = 0;
    }
    public PlayerData(PlayerPrefsInitalize player)
    {
        userName = player.userName;
        password = player.password;
        coins = player.coins;
        //for (i = 1; i <= 5; i++)
        //{
        //    progression[i] = player.progression[i];
        //    upgradeLevel[i] = player.upgradeLevel[i];
        //    price[i] = player.price[i];
        //}
        //for (i = 1; i < 9; i++)
        //{
        //    levelStars[i] = player.levelStars[i];
        //}
    }
}
