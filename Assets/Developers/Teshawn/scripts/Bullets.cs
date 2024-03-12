using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float speed; 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("testing");
        Destroy(gameObject);
    }
}
