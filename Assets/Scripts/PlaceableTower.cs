using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTower : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();

    [HideInInspector]
    public Renderer[] matRenderer;

    private void Start()
    {
        matRenderer = GetComponentsInChildren<Renderer>();
   
        
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="DefenseTower" || col.gameObject.tag=="Trees" || col.gameObject.tag=="Brazier")
        {
            colliders.Add(col);
          
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "DefenseTower" || col.gameObject.tag == "Trees" || col.gameObject.tag == "Brazier")
        {
            colliders.Remove(col);
        }
    }

   
}
