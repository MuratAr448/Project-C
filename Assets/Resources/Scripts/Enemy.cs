using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemySpawn ES;
    Rigidbody rb;
    [SerializeField] private GameObject EnemyProjectile;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce( 0f, 0f, Random.Range(-10.0f,-1f), ForceMode.Impulse);
        ES = FindObjectOfType<EnemySpawn>();
    }

    void OnCollisionEnter(Collision collision)
    {
        ES.RemoveEnemy(gameObject);
        Destroy(gameObject);
    }
}
