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
    public Text noOfTower1;
    public Text noOfTower2;
    public bool TowerAppearence;
    public Button BuyCannonTower;
    public Button CannonPlaced;
    public Button ArrowPlaced;
    public GameObject LockImg;
   
    private int Tower1Count = 0;
    private int Tower2Count = 0;
    private int price1;
    private int price2;
    public static int Havingcoins;
    private int canBePlaced1 = 0;
    private int canBePlaced2 = 0;
    private bool canPlaced1 = false;
    private bool canPlaced2 = false;
    private void Start()
    {
        ResetAll();
        price1 = 10;
        price2 = 20;
        Havingcoins = PlayerPrefs.GetInt("Coins");
        CoinDisplay.text = Havingcoins.ToString();
        PriceOfTower1.text = price1.ToString();
        PriceOfTower2.text = price2.ToString();
        noOfTower1.text = Tower1Count.ToString();
        noOfTower2.text = Tower2Count.ToString();
        LockImg.SetActive(false);
    }
    public void Update()
    {
       
        if(TowerAppearence == false)
        {
            BuyCannonTower.interactable = false;
            LockImg.SetActive(true);
        }

        if (canPlaced1 == true)
        {
            //Debug.Log(canPlaced1 + " : " + canPlaced2);
            ArrowPlaced.interactable = true;

        }

        else
        {
            ArrowPlaced.interactable = false;
        }

        if(canPlaced2 == true)
        {
            //Debug.Log(canPlaced1 + " : " + canPlaced2);
            CannonPlaced.interactable = true;
        }
        else 
        {
            CannonPlaced.interactable = false;
        }

        if(Havingcoins>=price1 || Havingcoins>=price2)
        {
            CoinInsufficient.text = "Towers To Buy";
        }

        //PlayerPrefs.SetInt("Coins", Havingcoins);
        CoinDisplay.text = Havingcoins.ToString();
        noOfTower1.text = canBePlaced1.ToString();
        noOfTower2.text = canBePlaced2.ToString();
    }

    public void Tower1()
    {
        if (GameController.Instance.waveStarted)
        {
            if (Havingcoins >= price1)
            {

                Tower1Count++;

                Havingcoins -= price1;
                if (Tower1Count > 5)
                {
                    price1 += 10;
                }
                canPlaced1 = true;
                canBePlaced1++;
            }
            else
            {
                CoinInsufficient.text = "Insufficient Thunder";
            }
            CoinDisplay.text = Havingcoins.ToString();
            PriceOfTower1.text = price1.ToString();
        }
        
    }


    public void Tower2()
    {
        if (GameController.Instance.waveStarted)
        {
            if (Havingcoins >= price2)
            {

                Tower2Count++;
                Havingcoins -= price2;
                if (Tower2Count > 5)
                {
                    price2 += 20;
                }
                canPlaced2 = true;
                canBePlaced2++;
            }
            else
            {
                CoinInsufficient.text = "Insufficient Thunder";
            }
            PriceOfTower2.text = price2.ToString();
            CoinDisplay.text = Havingcoins.ToString();
        }
    }

    public void PlaceTower1()
    {
        --canBePlaced1;
        if (canBePlaced1 >0)
        {
            //Function to place the Arrow Tower  
            Debug.LogWarning("Placed Tower 1");   
        }
        else
        {          
            canPlaced1 = false;
        }
       
    }
    public void PlaceTower2()
    {
        --canBePlaced2;
        if (canBePlaced2 >0)
        {
            //Function to place the Cannon Tower  
            Debug.LogWarning("Placed Tower 2");
        }
        else
        {
          
            canPlaced2 = false;
        }
    }
    public void ResetAll()
    {
        PlayerPrefs.SetInt("Coins", 1000);
    }
}
