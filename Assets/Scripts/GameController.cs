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

    public AudioSource battleHornClip;
    public AudioSource cannonFireClip;
    public AudioSource levelCompleteClip;
    public AudioSource gameOverClip;

    public Text waveCountdownText;

    public bool waveStarted = false;
    public bool levelComplete = false;
  
    public GameObject[] stars;
    public Sprite starSprite;
    public int TotalEnemies;
    //used for updating stars earned for the level 
   
    
    [HideInInspector]
    public int levelIndex;
    [HideInInspector]
    public int finalTowerHealth = 0;
    [HideInInspector]
    public int numEnemiesKilled = 0;

    private int currentStarsNum = 0;
    

    private void Awake()
    {
        levelComplete = false;
        numEnemiesKilled = 0;
        finalTowerHealth = 0;
        hudUI.SetActive(true);
        gameOverUI.SetActive(false);
        levelCompleteUI.SetActive(false);
        waveCountdownCanvas.SetActive(true);
        waveCountdownText.text = "";
        levelIndex = PlayerPrefs.GetInt("LevelIndex");
    }

    //called when game is ovver
    public void GameOver()
    {
        hudUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameOverClip.Play();
    }

    //called when level is completed
    public void LevelComplete()
    {
        StarsConditions();
        levelComplete = true;
        hudUI.SetActive(false);
        levelCompleteUI.SetActive(true);
        levelCompleteClip.Play();
    }
    public void StarsConditions()
    {
        if (finalTowerHealth > (PlayerPrefs.GetFloat("TowerHP") / 2) && numEnemiesKilled > TotalEnemies)
        {
            PressStarsButton(3);
        }
        else if (finalTowerHealth > (PlayerPrefs.GetFloat("TowerHP") / 3) && numEnemiesKilled > (TotalEnemies-10))
        {
            PressStarsButton(2);
        }
        else if (finalTowerHealth > 0)
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
            //display the level complete canvas

            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + levelIndex); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }


    }
}
