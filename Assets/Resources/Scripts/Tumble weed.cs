using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbleweed : MonoBehaviour
{
    Rigidbody rb;
    private float spin = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(0f, 0f, Random.Range(-1.0f, -0.5f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-spin, 0, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
    }
}
