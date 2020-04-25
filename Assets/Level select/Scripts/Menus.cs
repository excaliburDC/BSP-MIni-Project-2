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
   

}
