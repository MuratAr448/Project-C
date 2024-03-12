using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Tumbleweed;
    private float EnemyspawnTimer;
    private float Enemyspawntime;
    private float Twspawntimer;
    private float Twspawntime;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        EnemyspawnTimer += Time.deltaTime;
        if (EnemyspawnTimer >= Enemyspawntime)
        {
            var position = new Vector3(Random.Range(-4.5f, 4.5f), 0.7f, 5);
            Instantiate(Enemy, position, Quaternion.identity);
            Enemyspawntime = Random.Range(2f, 3f);
            EnemyspawnTimer = 0;
        }
        Twspawntimer += Time.deltaTime;
        if (Twspawntimer >= Twspawntime)
        {
            var position = new Vector3(Random.Range(-4.5f, 4.5f), 0.7f, 5);
            Instantiate(Tumbleweed, position, Quaternion.identity);
            Twspawntime = Random.Range(4f, 6f);
            Twspawntimer = 0;
        }


    }

}
