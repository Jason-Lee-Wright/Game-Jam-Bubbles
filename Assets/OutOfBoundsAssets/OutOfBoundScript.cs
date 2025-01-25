using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OutOfBoundScript : MonoBehaviour
{
    //Sofia F's out of bounds and spawn point script!
    public Vector3 SpawnPoint;
    private AudioSource bubbleTransition;

    void Start()
    {
        bubbleTransition = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = SpawnPoint;
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;

            bubbleTransition.Play();
        }
    }
}