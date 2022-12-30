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
    void CheckLineOfSight()
    {
        Vector3 rayDirection = player.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit))
        {
            if (hit.transform.tag == "Player")
            {
                // Debug
                Debug.DrawLine(transform.position, hit.point, Color.green);
                nav.SetDestination(player.position);
            }
            else
                // Debug
                Debug.DrawLine(transform.position, hit.point, Color.red);

        }
        else
        // Debug line of sight
        Debug.DrawLine(transform.position, player.position, Color.black);

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
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }
    Vector3 previousPosition;
    void CheckIfStuck()
    {
        print(Vector3.Distance(previousPosition, transform.position));

        if (Vector3.Distance(previousPosition, transform.position) < 2)
            SetRandomDestination();
        previousPosition = transform.position;
    }
    void Start()
    {
        InvokeRepeating("CheckIfStuck", 3f, 3f);
    }
    NavMeshAgent nav;
    Transform player;
}
