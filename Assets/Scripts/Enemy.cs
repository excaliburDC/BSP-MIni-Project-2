using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Create Enemy")]
public class Enemy : ScriptableObject
{
    public GameObject enemyPrefab;
    public float moveSpeed;
    public float health;
    public float attackPower;
    public float attackRate;
    public float attackRange;
    public float selfDamagePower;
    public Animator enemyAnim;
}
