using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/Enemy Waves")]
public class Wave : ScriptableObject
{
    public List<GameObject> enemyPrefab;
    public int enemiesPerWave;
    public float timeBetweenEnemies = 2f;
    

}
