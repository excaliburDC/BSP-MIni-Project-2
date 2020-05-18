using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    public Animator Anim;
    private string form;

    public void LevelSelect()
    {
        SceneManager.LoadSceneAsync("Level Selection");
      
       
    }
    public void MainMenuBtn()
    {
        SceneManager.LoadSceneAsync("MainMenu");
     
    }
    public void Quit()
    {
        Debug.Log("Quit");

        
        Application.Quit();
    }
    public void Inventory()
    {
        SceneManager.LoadSceneAsync("Inventory");
      
    }

    public void SettingMenu()
    {
        Debug.Log("setting");
        Anim.CrossFade("Setting", 0.5f);

    }
    public void CreditsMenu()
    {
        Debug.Log("Credits");
        Anim.CrossFade("Credits", 0.5f);
    }
    public void BackButton(string TriggerVal)
    {
            Anim.CrossFade(TriggerVal, 0.5f);
    }
   public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
