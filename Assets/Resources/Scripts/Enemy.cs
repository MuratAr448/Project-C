using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private GameObject EnemyProjectile;
    [SerializeField] private GameObject EnemybulletSpawn;
    private float bullet_timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce( 0f, 0f, Random.Range(-1.0f,-0.5f), ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        bullet_timer += Time.deltaTime;
        if (bullet_timer>=2f)
        {
            Instantiate(EnemyProjectile, EnemybulletSpawn.transform.position, EnemybulletSpawn.transform.rotation);
            bullet_timer = 0f;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
