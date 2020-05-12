using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinManager : MonoBehaviour
{ 
    // use this function where the enemies will be defeated and coins should be updated
    public static void UpdateCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
        BuyingTowers.Havingcoins += PlayerPrefs.GetInt("Coins");
        Debug.Log(BuyingTowers.Havingcoins);
        PlayerPrefs.Save();
    }





    //this is only for testing
    public void DecreaseCoin(int valueToUpdate)
    {
       if(PlayerPrefs.GetInt("Coins") >= valueToUpdate  )
       {
            Debug.Log("Decrease");
            int coins = PlayerPrefs.GetInt("Coins");
            coins -= valueToUpdate;
            UpdateCoins(coins);
        }
    }
    public void IncreaseCoin(int valueToUpdate)
    {  
        Debug.Log("Increase");
        int coins = PlayerPrefs.GetInt("Coins");
        coins += valueToUpdate;
        UpdateCoins(coins);
    }
}
