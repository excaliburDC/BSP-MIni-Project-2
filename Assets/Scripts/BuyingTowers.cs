using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyingTowers : MonoBehaviour
{
    public Text CoinDisplay;
    public Text PriceOfTower1;
    public Text PriceOfTower2;
    public Text CoinInsufficient;
    public bool TowerAppearence;
    public GameObject BowTower;
    public GameObject CannonTower;
   
    private int Tower1Count =0;
    private int Tower2Count = 0;
    private int price1;
    private int price2;
    private int Havingcoins;


    private void Start()
    {
        //ResetAll();
        price1 = 10;
        price2 = 10;
        Havingcoins = PlayerPrefs.GetInt("Coins");
        CoinDisplay.text = Havingcoins.ToString();
        PriceOfTower1.text = price1.ToString();
        PriceOfTower2.text = price2.ToString();
    }
    public void Update()
    {
        if(TowerAppearence == false)
        {
            BowTower.SetActive(true);
            CannonTower.SetActive(false);
        }
        PlayerPrefs.SetInt("Coins", Havingcoins);
    }

    public void Tower1()
    {
     
       
        if (Havingcoins >= price1)
        {
            Tower1Count++;
            Havingcoins -= price1;
            if (Tower1Count > 5)
            {
                //PlayerPrefs.SetInt("Coins",Havingcoins);
                price1 += 10;
            }     
        }
        else
        {
           
            CoinInsufficient.text = "Thunder Insufficient";
        }
        CoinDisplay.text = Havingcoins.ToString();
        PriceOfTower1.text = price1.ToString();
      
    }
    public void Tower2()
    {
       
        if (Havingcoins >= price2)
        {
            Tower2Count++;
            Havingcoins -= price2;
            if (Tower2Count > 5)
            {        
               // PlayerPrefs.SetInt("Coins", Havingcoins);
              
                price2 += 10;
            }
        }
        else
        {
          
            CoinInsufficient.text = "Thunder Insufficient";
        }

        PriceOfTower2.text = price2.ToString();
        CoinDisplay.text = Havingcoins.ToString();
    }
  //public void ResetAll()
  //  {
  //      PlayerPrefs.SetInt("Coins", 500);
  //  }
}
