using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menus : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Selection");
    }
    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Inventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void SettingMenu()
    {
        Debug.Log("setting");
    }
    public void CreditsMenu()
    {
        Debug.Log("Credits");
    }
    
}
