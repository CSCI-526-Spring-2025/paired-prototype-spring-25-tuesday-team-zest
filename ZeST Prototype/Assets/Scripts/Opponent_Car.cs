using System;
using System.Collections;
using UnityEngine;

public class Opponent_Car : MonoBehaviour
{
    public float speed = 0.3f; //Player linear speed
    public float rotationSpeed = 20.0f; //Player rotation speed
    public float bounceForce = 5.0f;
    private Rigidbody carRB;
    public GameObject finishGoal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        carRB.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bouncy"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                carRB.AddForce(contact.normal * bounceForce, ForceMode.Impulse);
            }
        }
    }
    
}
