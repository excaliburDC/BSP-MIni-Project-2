using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour,IPooledObject
{
    public void OnObjectSpawner()
    {
        FindTarget();
    }

    void FindTarget()
    {
        Debug.Log("Target Found");
    }

}
