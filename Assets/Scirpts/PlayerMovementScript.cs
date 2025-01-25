using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Sofia F's + Unity's movement script!!

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public bool isGrounded;
    public GameObject mainCamera;

    private AudioSource pickUpPop;
    private AudioSource dashSoapSlide;

    private bool isDashing = false;
    private float dashDuration = 3f;
    private float dashTimer = 0f;

    public float speed = 1; // May be adjusted
    public float sprintSpeed = 100; // May be adusted

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickUpPop = GetComponent<AudioSource>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        // Get the camera's forward and right directions
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Make the movement flat on the ground
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize the vectors to avoid faster diagonal movement
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Create the movement direction based on camera orientation
        Vector3 movement = cameraForward * movementY + cameraRight * movementX;

        // Apply force to the Rigidbody
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500); // 500 is used to mske it jump higher, so depending on the gameobject sizes, this number can be changed to make jumping more suitable.
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
            dashTimer = dashDuration;
            dashSoapSlide.Play();
        }
        if (isDashing)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * sprintSpeed);

            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpPop.Play();
        }
    }
}