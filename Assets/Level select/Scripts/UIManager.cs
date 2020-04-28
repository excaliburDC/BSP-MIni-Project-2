using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text starsText;
    public GameObject Map1;
    public GameObject Map2;
    //private LevelSelection levelselect;
    public GameObject NextMapButton;
  
    private bool isActivatedPre = false;
    private bool isActivatedNext= false;
    void start()
    {
       // levelselect = GameObject.Find("4").GetComponent<LevelSelection>();

    }
    private void Update()
    {
        UpdateStarsUI();
        ActivateMap();
    }
    //It is used to update stars in each level
    public void UpdateStarsUI()
    {
        int sum = 0;

        for(int i = 1; i <= 8; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());//Add the level 1 stars number, level 2 stars number.....
        }

        starsText.text = sum + "/" + 24;
    }
    //this is only for checking purpose
    public void clearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    // to activate the second map after level 4
    public void ActivateMap()
    {
        if (isActivatedNext == false)
        {
            if (PlayerPrefs.GetInt("Lv4") > 0)
            {
                Map1.SetActive(true);
                Map2.SetActive(false);
                NextMapButton.SetActive(true);
                isActivatedNext = true;

            }
        }
        if (isActivatedPre == false)
        {
            if (PlayerPrefs.GetInt("Lv5") > 0 )
            {
                Map1.SetActive(false);
                Map2.SetActive(true);

                isActivatedPre = true;
            }
        }


    }
    //to back and forth between 2 map
    public void NextMapButtonFn()
    {
        Map1.SetActive(false);
        Map2.SetActive(true);
        //NextMapButton.SetActive(false);
    }
    public void PrevMapButtonFn()
    {
        Map1.SetActive(true);
        Map2.SetActive(false);
      
    }
    public void TowerUpgrade()
    {
        SceneManager.LoadScene("Inventory");
    }
   
}
