using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public List<GameObject> placeableTowers;

    private GameObject currentPlaceableTower;
    private float mouseWheelRotation;
    private float rotateSpeed;
    public bool hasPlaced;




    private void Update()
    {
        PlaceTower();

        if (currentPlaceableTower != null && !hasPlaced)
        {
            MoveTowerPosition();
            //RotateTowerFromMouseWheel();
            ReleaseIfClicked();
        }

    }

    public void PlaceTower()
    {
        for (int i = 0; i < placeableTowers.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                SetTower(placeableTowers[i]);
               
            }
        }

    }

    void SetTower(GameObject gObj)
    {
        Debug.Log(gObj.name);
        hasPlaced = false;
        currentPlaceableTower = Instantiate(gObj);
        
    }

    void MoveTowerPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo,Mathf.Infinity))
        {
            
            currentPlaceableTower.transform.position = hitInfo.point; ;
            //currentPlaceableTower.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }

        //Vector3 m = Input.mousePosition;
        //m = new Vector3(m.x, 0,m.z);
        //Vector3 p = Camera.main.ScreenToWorldPoint(m);
        //currentPlaceableTower.transform.position=new Vector3(p.x,0,p.x);


    }



    void RotateTowerFromMouseWheel()
    {
        Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableTower.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasPlaced = true;
            currentPlaceableTower = null;
        }
    }
}
