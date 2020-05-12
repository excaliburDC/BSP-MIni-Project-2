using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public LayerMask mask;
    public float towerRotateSpeed = 10f;
    public bool hasPlaced;

    private GameObject currentPlaceableTower;
    private PlaceableTower placeableTower;
    private float LastPosX, LastPosY, LastPosZ;




    private void Update()
    {
        //PlaceTower();

        if (currentPlaceableTower != null && !hasPlaced)
        {
            MoveTowerPosition();
            RotateTowerFromMouseWheel();
            ReleaseIfClicked();
        }

    }

    public void PlaceTower(GameObject gObj)
    {
        Debug.Log(gObj.name);
        hasPlaced = false;
        currentPlaceableTower = Instantiate(gObj);
        placeableTower = currentPlaceableTower.GetComponent<PlaceableTower>();

    }

    //void SetTower(GameObject gObj)
    //{
    //    Debug.Log(gObj.name);
    //    hasPlaced = false;
    //    currentPlaceableTower = Instantiate(gObj);
    //    placeableTower = currentPlaceableTower.GetComponent<PlaceableTower>();
        
    //}

    private bool isValidPosition()
    {
        if(placeableTower.colliders.Count>0)
        {
            return false;
        }

        for (int i = 0; i < placeableTower.matRenderer.Length; i++)
        {
            placeableTower.matRenderer[i].material.color = Color.green;
        }

        return true;
    }

    void MoveTowerPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mask))
        {

            float PosX = hitInfo.point.x;
            float PosY = hitInfo.point.y;
            float PosZ = hitInfo.point.z;

            if (PosX != LastPosX || PosY != LastPosY || PosZ != LastPosZ)
            {
                LastPosX = PosX;
                LastPosY = PosY;
                LastPosZ = PosZ;
                currentPlaceableTower.transform.position = new Vector3(LastPosX, LastPosY + .5f, LastPosZ);
               

            }

           


        }
        //Vector3 m = Input.mousePosition;
        //m = new Vector3(m.x, 0,m.z);
        //Vector3 p = Camera.main.ScreenToWorldPoint(m);
        //currentPlaceableTower.transform.position=new Vector3(p.x,0,p.x);


    }



    void RotateTowerFromMouseWheel()
    {
        Debug.Log(Input.mouseScrollDelta);
        if(Input.GetKey(KeyCode.Q))
        {
            // Rotate Anti-Clockwise
           
            currentPlaceableTower.transform.Rotate(-Vector3.up, towerRotateSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            // Rotate Clockwise
          
            currentPlaceableTower.transform.Rotate(Vector3.up, towerRotateSpeed * Time.deltaTime);
        }

        
    }

    private void ReleaseIfClicked()
    {
        if(!isValidPosition())
        {
            for (int i = 0; i < placeableTower.matRenderer.Length; i++)
            {
                placeableTower.matRenderer[i].material.color = Color.red;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(isValidPosition())
            {
                hasPlaced = true;
                currentPlaceableTower = null;

                for (int i = 0; i < placeableTower.matRenderer.Length; i++)
                {
                    placeableTower.matRenderer[i].material.color = Color.white;
                }
            }

           


        }
    }

    
}
