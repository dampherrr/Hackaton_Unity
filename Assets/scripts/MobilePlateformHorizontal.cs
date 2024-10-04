using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    public Transform startingPoint;
    private int _currentWaypointIndex = 0;
    [SerializeField] private float _speed = 3f;

    private Transform player;
    private bool playerOnPlatform = false; // Pour savoir si le joueur est sur la plateforme

    void Start()
    {
        if (startingPoint != null)
        {
            transform.position = startingPoint.position;
        }
    }

    void Update()
    {
        // Déplacement de la plateforme
        if (waypoints.Length > 0)
        {
            Transform wp = waypoints[_currentWaypointIndex];
            if (Vector3.Distance(transform.position, wp.position) < 0.1f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
            }
        }

        // Raycast pour détecter si le joueur est sur la plateforme
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                player = hit.transform;
                playerOnPlatform = true;
            }
        }
        else
        {
            playerOnPlatform = false;
        }

        // Si le joueur est sur la plateforme, il suit la plateforme
        if (playerOnPlatform)
        {
            player.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
