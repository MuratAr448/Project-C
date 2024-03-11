using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] private List<GameObject> spawnedEnemy = new();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void RemoveEnemy(GameObject EnemyToRemove)
    {
        spawnedEnemy.Remove(EnemyToRemove);
    }
}
