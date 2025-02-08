using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f; //Player linear speed
    public float rotationSpeed = 10.0f; //Player rotation speed

    public float bounceForce = 70.0f;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bouncy"))
        {
            Debug.Log("Entered");
            playerRB.AddForce(transform.forward*(-1) * bounceForce, ForceMode.Impulse);
        }
    }
}
