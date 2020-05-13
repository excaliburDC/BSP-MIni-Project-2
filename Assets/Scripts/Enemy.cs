using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Create Enemy")]
public class Enemy : ScriptableObject
{
    
    public string enemyName;
    public float moveSpeed;
    public int health;
    public int attackPower;
    public float attackRate;
    public float searchRange;
    public int coinAmount;
   
    
}
