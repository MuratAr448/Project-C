using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ridgedbody and movment variablere
    private Rigidbody rb;
    [SerializeField] private float movement;

    //healthVariable
    public int maxHitPoints = 5;
    public int currentHitPoints;

    //IframeVariable
    [SerializeField]private float IframeTimer;
    [SerializeField] private float IframeTime = 3;
    [SerializeField] private bool IframeCheck;
   
    void Start()
    {
        IframeCheck = false;
        currentHitPoints = maxHitPoints;
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        IframeChecker();
    }

    private void FixedUpdate()
    {
        if(Input.GetAxis("Vertical") > 0) 
        {
            rb.AddRelativeForce(Vector3.forward * movement);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddRelativeForce(Vector3.back * movement);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.AddRelativeForce(Vector3.right * movement);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            rb.AddRelativeForce(Vector3.left * movement);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullets")
        {
            if (currentHitPoints == 1)
            {
                Debug.Log("gameOver");
            }
            else if (IframeCheck == false)
            {
                currentHitPoints--;
                IframeCheck = true;
            }
        }

    }

    private void IframeChecker()
    {
        if (IframeCheck == true)
        {
            IframeTimer += Time.deltaTime;
            if(IframeTimer > IframeTime)
            {
                IframeTimer = 0;
                IframeCheck = false;
            }
        }
    }
}
