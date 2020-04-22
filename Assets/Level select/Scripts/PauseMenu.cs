﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
        
    }

    public void Toggle()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        if(pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
