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

    public AudioClip SoapyDashSFX;
    public AudioClip PickUpSFX;
    public AudioSource audio;
    //public AudioSource pickUpPop;
    //public AudioSource dashSoapSlide;

    private bool isDashing = false;
    private float dashDuration = 3f;
    private float dashTimer = 0f;

    public float speed = 1; // May be adjusted
    public float sprintSpeed = 100; // May be adusted

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        //dashSoapSlide = GetComponent<AudioSource>();
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
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500); // 500 is used to mske it jump higher, so depending on the gameobject sizes, this number can be changed to make jumping more suitable.
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
            dashTimer = dashDuration;
            audio.clip = SoapyDashSFX;
            audio.Play();
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
            audio.clip = PickUpSFX;
            other.gameObject.SetActive(false);
            audio.Play();
        }
    }
}