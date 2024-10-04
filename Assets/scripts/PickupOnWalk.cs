using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupOnWalk : MonoBehaviour
{
    public GameObject key1;
    public GameObject door1;
    public static bool HaveKey;
    public static bool OpenDoor;

    public float triggerX = -174.5165f;
    private bool isTriggered = false;
    void Update()
    {
        if (isTriggered)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float playerX = player.transform.position.x;
                if (playerX > triggerX)
                {
                    HaveKey = true;
                    OpenDoor = true;

                    // verifier la clé n'a pas été détruite
                    if (key1 != null)
                    {
                        key1.SetActive(false);
                    }

                    // verifier la porte n'a pas été détruite

                    if (door1 != null)
                    {
                        door1.SetActive(false);
                    }

                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            key1.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            key1.SetActive(false);
        }
    }

}

