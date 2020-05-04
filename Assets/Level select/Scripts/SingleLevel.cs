using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SingleLevel : MonoBehaviour
{
    private int currentStarsNum = 0;
    public int levelIndex;
    public GameObject mainCanvas;
    public GameObject gameOver;
    public GameObject gameComplete;
    public GameObject[] stars;
    public Sprite starSprite;


    //Back to the level selection scene
    public void BackButton()
    {
        SceneManager.LoadSceneAsync("Level Selection");
        //SceneManager.LoadScene("Level Selection");
    }

    //to get the number of star in the paricular level
    public void PressStarsButton(int _starsNum)
    {
        currentStarsNum = _starsNum;

        if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }

        MenuDisplayControl(levelIndex);

    }

    public void MenuDisplayControl(int LevelIndexNew)
    {
        if (PlayerPrefs.GetInt("Lv" + LevelIndexNew) > 0)
        {
            //display the level complete canvas
            mainCanvas.SetActive(false);
            gameComplete.SetActive(true);
            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + LevelIndexNew); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
        else
        {
            //display the game over canvas
            mainCanvas.SetActive(false);
            gameOver.SetActive(true);

        }
       
    }

}
