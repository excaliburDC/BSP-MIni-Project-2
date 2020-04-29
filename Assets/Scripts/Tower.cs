using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player/ Create Tower")]
public class Tower : ScriptableObject
{
    public string towerName;
    public float towerRange;
    public float rotateSpeed;
    public float attackPower;
    public float attackRate;
}
