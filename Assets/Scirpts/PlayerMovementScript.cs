using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Sofia F's + Unity's movement script!!

public class PlayerMovementScript : MonoBehaviour
{
    public int JumpHigh = 500;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed = 3; // May be adjusted
    public float sprintSpeed = 5; // May be adusted

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpHigh); // 500 is used to mske it jump higher, so depending on the gameobject sizes, this number can be changed to make jumping more suitable.
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * sprintSpeed);
        }
    }



    // FOR SOF: Create a new class

    private void OnCollsionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}