using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f; //Player linear speed    //Test value = 0.6
    public float rotationSpeed = 30.0f; //Player rotation speed
    public float bounceForce = 5.0f;
    private Rigidbody playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveAmount * speed * Time.fixedDeltaTime;
        //playerRB.MovePosition(playerRB.position + movement);
        playerRB.AddForce(transform.forward * moveAmount * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        
        // Rotate player based on horizontal input.
        float turnAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        playerRB.MoveRotation(playerRB.rotation * turnRotation);
        //playerRB.AddTorque(transform.up * turnAmount*rotationSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Logic for adding the innovative collision mechanics of the game
        if (collision.gameObject.CompareTag("Bouncy"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                playerRB.AddForce(contact.normal * bounceForce, ForceMode.Impulse);
            }
        }
    }

}
