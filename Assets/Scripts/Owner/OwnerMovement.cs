using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwnerMovement : MonoBehaviour
{
    void Update()
    {
        // Check if reached destination
        CheckReachedDesination();

        // Check line of sight
        CheckLineOfSight();

        // Input
        if (Input.GetKeyDown(KeyCode.M))
            SetRandomDestination();

        // Debug destination
        Debug.DrawLine(transform.position, nav.destination, Color.yellow);
    }
    [HideInInspector] public bool canSeePlayer = false;
    void CheckLineOfSight()
    {
        Vector3 rayDirection = player.position - transform.position;
        
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit))
        {
            // Check to see if player is in owners field of view
            float fieldOfViewValue = GetFieldOfViewValue();

            if (hit.transform.tag == "Player" && fieldOfViewValue > 0)
            {
                canSeePlayer = true;

                // Debug
                Debug.DrawLine(transform.position, hit.point, Color.green);
                nav.SetDestination(player.position);

                // Owner speed
                nav.speed = 4f;
            }
            else
            {
                canSeePlayer = false;
                // Debug
                Debug.DrawLine(transform.position, hit.point, Color.red);

                // Owner speed
                nav.speed = 3f;
            }

        }
        else
        {
            // Debug line of sight
            Debug.DrawLine(transform.position, player.position, Color.black);
            
            // Owner speed
            nav.speed = 3f;
        }

    }
    float GetFieldOfViewValue()
    {
        // check if behind, ignore y
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toOther = player.position - transform.position;
        return Vector3.Dot(forward.normalized, toOther.normalized);
    }
    void CheckReachedDesination()
    {
        // Ignore the y value
        Vector2 start = new Vector2(transform.position.x, transform.position.z);
        Vector2 end = new Vector2(nav.destination.x, nav.destination.z);
        
        if (Vector2.Distance(start, end) < 1)
            SetRandomDestination();
    }
    public void Freeze(float time)
    {
        StartCoroutine(FreezeQuarantine(time));
    }
    IEnumerator FreezeQuarantine(float time)
    {
        nav.isStopped = true;
        yield return new WaitForSeconds(time);
        nav.isStopped = false;
    }

    public Transform[] destinations;
    void SetRandomDestination()
    {
        int index = Random.Range(0, destinations.Length);
        nav.SetDestination(destinations[index].position );
    }
    Vector3 previousPositionToCheckWhenStuck;
    void CheckIfStuck()
    {
        // print(Vector3.Distance(previousPosition, transform.position));

        if (Vector3.Distance(previousPositionToCheckWhenStuck, transform.position) < 2)
            SetRandomDestination();
        previousPositionToCheckWhenStuck = transform.position;
    }
    void Start()
    {
        InvokeRepeating("CheckIfStuck", 3f, 3f);
        player = GameObject.FindWithTag("Player").transform;
    }
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    Transform player;
    NavMeshAgent nav;
}
