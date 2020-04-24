using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Transform> leftWayPoints;
    public List<Transform> rightWayPoints;
    public List<Transform> frontWayPoints;


    private void Start()
    {
        EnemyController.Instance.SetupAI(true, leftWayPoints, rightWayPoints, frontWayPoints);
    }
}
