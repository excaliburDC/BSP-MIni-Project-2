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





    private void Awake()
    {
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


    }

    //called when level is completed
    public void LevelComplete()
    {
        hudUI.SetActive(false);
        levelCompleteUI.SetActive(true);
    }










}
