using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutOfBoundScript : MonoBehaviour
{
    public Vector3 SpawnPoint;
    public AudioSource bubbleTransition;

    void Start()
    {
        bubbleTransition = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bubbleTransition.Play();
            other.gameObject.transform.position = SpawnPoint;
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;

        }
    }
}