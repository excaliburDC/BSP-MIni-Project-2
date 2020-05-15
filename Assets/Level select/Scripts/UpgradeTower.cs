using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
 
    public GameObject forestTower;
    public GameObject magicalTower;
    public GameObject forestTowerPanel;
    public GameObject magicalTowerPanel;   
    private Vector3 characterPos;
    private Vector3 outsidePos;
    private Vector3 characterPosPanel;
    private Vector3 outsidePosPanel;
    public int characterSelect = 1;


    private void Awake()
    {
        characterPos = forestTower.transform.position;
        outsidePos = magicalTower.transform.position;
        characterPosPanel = forestTowerPanel.transform.position;
        outsidePosPanel = magicalTowerPanel.transform.position;

    }


    public void NextButton()
    {
        switch (characterSelect)
        {
            case 1:
                ObjectOnOff(forestTower, forestTowerPanel, magicalTower, magicalTowerPanel);
                characterSelect++;
                break;            
            case 2:
                ObjectOnOff(magicalTower, magicalTowerPanel, forestTower, forestTowerPanel);
                characterSelect++;                        
                ResetBtn();
                break;
            default:
                ResetBtn();
                break;
        }
    }
    public void PreviousButton()
    {
        switch (characterSelect)
        {
            case 1:
                ObjectOnOff(forestTower, forestTowerPanel, magicalTower, magicalTowerPanel);
                characterSelect--;
                ResetBtn();
                break;        
            case 2:
                ObjectOnOff(magicalTower, magicalTowerPanel, forestTower, forestTowerPanel);
                characterSelect--;
                break;       
            default:
                ResetBtn();
                break;
        }
    }
    private void ResetBtn()
    {
        if (characterSelect >= 2)
        {
            characterSelect = 1;
        }
        else
        {
            characterSelect = 2;
        }

    }
    public void ObjectOnOff(GameObject objectname1, GameObject objectname2, GameObject objectname3, GameObject objectname4)
    {
        objectname1.SetActive(false);
        objectname2.SetActive(false);
        objectname1.transform.position = outsidePos;
        objectname2.transform.position = outsidePosPanel;

        objectname3.transform.position = characterPos;
        objectname4.transform.position = characterPosPanel;
        objectname3.SetActive(true);
        objectname4.SetActive(true);
    }
}
