using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public StateMachine statemachine;
    public Transform player;
    public float playerVolume = 15f;   //declaring variables
    public Transform[] patrolWaypoints;
    public Transform visionCone;
    public bool playerInCone;
    public bool canSeePlayer;
    public int currentWaypointIndex;
    public float patrolSpeed = 5; //speed of Ai
    public float detectionRange;
    public float hearingThreshold = 10f; 
    public float hearingRange = 15f;

    private void Start()
    {
        statemachine = new StateMachine();
        statemachine.ChangeState(new StatePatrol(this));
    }
    private void Update()
    {
        statemachine.Update();
    }

    public void ChangeState(State newState)
    {
        statemachine.ChangeState(newState);
    }

    public bool CanSeePlayer()  //a bool that checks if the ai can see the player
    {
    return HasLineOfSight(player);  
    }

    public bool CanHearPlayer(float noiseLevel) //a bool that checks if the player is heard. Hearing not implimented.
    {
        if (player == null) return false;

        if (Vector3.Distance(transform.position, player.position) < hearingRange && noiseLevel > hearingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetPlayerInVisionCone(bool isVisible) //checks if the player is seen by the ai and chases them
    {
       playerInCone = isVisible;
    }
    public void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * patrolSpeed);
        Vector3 direction = (player.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            float rotationSpeed = 3f;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);

        }
    }

    public bool HasLineOfSight(Transform target) //using raycasting to detect the player
    {
        if (!playerInCone)
        {
            return false;
        }
        Vector3 directionToTarget = (target.position - transform.position).normalized;


        RaycastHit hit;

        if(Physics.Raycast(transform.position, directionToTarget, out hit, detectionRange))
        {
            if (hit.transform == target)
            {
                return true; //player is in direct LOS
            }
        }
              
        return false;
    }
    public void Patrol()  //setting the Ai as patrolling and how the ai navigates them
    {
        if (patrolWaypoints.Length == 0)
        {
            return;
        }

       Transform targetWaypoint = patrolWaypoints[currentWaypointIndex];
       transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, Time.deltaTime * patrolSpeed);
       Vector3 direction = (targetWaypoint.position - transform.position).normalized;  
        if (direction != Vector3.zero)
        {
            float rotationSpeed = 3f;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);

        }
       if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f) //checking how close to the checkpoint the enemy is
        {
        currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Length;
        }
       
    }
}
