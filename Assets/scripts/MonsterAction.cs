using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform startingPoint; 
    private int _currentWaypointIndex = 0;
    [SerializeField] private float _speed = 3f;

    private float _waitTime = 1f;
    private float _waitCounter = 0f;
    private bool _waiting = false;

    private GameObject player;
    private CharacterController characterController;

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("Aucun waypoint assigné ! Assignez au moins deux points de passage.");
        }

        
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter < _waitTime)
                return;

            _waiting = false;
        }

        if (waypoints.Length > 0)
        {
            Transform wp = waypoints[_currentWaypointIndex];
            if (Vector3.Distance(transform.position, wp.position) < 0.1f)
            {
                _waitCounter = 0f;
                _waiting = true;
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            characterController.enabled = false;

            
            player.transform.position = startingPoint.position;

            
            characterController.enabled = true;
        }
    }
}
