using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform destination;
    GameObject player;
    CharacterController characterController;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (Vector3.Distance(player.transform.position, transform.position) > 0.3f)
            {

                characterController.enabled = false;

                player.transform.position = destination.transform.position;

                characterController.enabled = true;

            }
        }

    }
}
