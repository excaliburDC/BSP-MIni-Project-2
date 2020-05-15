using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : SingletonManager<GameController>
{
    public GameObject waveCountdownCanvas;
    public GameObject gameOverUI;
    public GameObject levelCompleteUI;
    public GameObject hudUI;
    public Text waveCountdownText;
    public bool waveStarted = false;
    public int levelIndex;
    public GameObject[] stars;
    public Sprite starSprite;
    private int currentStarsNum = 0;
    

    public int numEnemiesKilled = 0; //used for updating stars earned for the level 




    private void Awake()
    {
        numEnemiesKilled = 0;
        hudUI.SetActive(true);
        gameOverUI.SetActive(false);
        levelCompleteUI.SetActive(false);
        waveCountdownText.text = "";
       
      
    }
   

    //called when game is ovver
    public void GameOver()
    {

        
        StarsConditions();
        hudUI.SetActive(false);
        gameOverUI.SetActive(true);

    }
    public void LevelComplete()
    {
    
        StarsConditions();
        hudUI.SetActive(false);
        levelCompleteUI.SetActive(true);
    }
    public void StarsConditions()
    {
        if (PlayerPrefs.GetFloat("TowerHealth") > (PlayerPrefs.GetFloat("TowerHP") / 2))
        {
            PressStarsButton(3);
        }
        else if (PlayerPrefs.GetFloat("TowerHealth") > (PlayerPrefs.GetFloat("TowerHP") / 3))
        {
            PressStarsButton(2);
        }
        else if (PlayerPrefs.GetFloat("TowerHealth") > 0)
        {
            PressStarsButton(1);
        }

        Debug.LogError("3 :" + (PlayerPrefs.GetFloat("TowerHP")));
        Debug.LogError("2 :" + (PlayerPrefs.GetFloat("TowerHP")));
    }

    public void PressStarsButton(int _starsNum)
    {
        currentStarsNum = _starsNum;

        if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }
      
        if (PlayerPrefs.GetInt("Lv" + levelIndex) > 0)
        {          
            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + levelIndex); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }

   
}
