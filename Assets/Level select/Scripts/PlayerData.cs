using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public string userName;
    public string password;
    //public int levelCompleted;
    public int[] levelstars;
    public float[] progression;
    public int[] upgradeLevel;
    public int[] price;
    int i;
    public PlayerData (PlayerPrefsInitalize player)
    {
        userName = player.userName;
        password = player.password;
        for (i = 0; i < 5; i++)
        {
            progression[i] = player.progression[i];
            upgradeLevel[i] = player.upgradeLevel[i];
            price[i] = player.price[i];
        }
        for (i = 0; i < 8; i++)
        {
            levelstars[i] = player.levelStars[i];
        }
    }
}
