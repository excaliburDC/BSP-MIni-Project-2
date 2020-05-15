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

    //used for updating stars earned for the level 
    public int numEnemiesKilled = 0; 
    public int finalTowerHealth = 0;




    private void Awake()
    {
        levelComplete = false;
        numEnemiesKilled = 0;
        finalTowerHealth = 0;
        hudUI.SetActive(true);
        gameOverUI.SetActive(false);
        levelCompleteUI.SetActive(false);
        waveCountdownText.text = "";
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
        levelComplete = true;
        hudUI.SetActive(false);
        levelCompleteUI.SetActive(true);
        levelCompleteClip.Play();
    }
   
}
