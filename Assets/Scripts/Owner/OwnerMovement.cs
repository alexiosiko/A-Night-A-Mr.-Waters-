using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwnerMovement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            GetRandomDestination();

        Debug.DrawLine(transform.position, nav.destination, Color.red);
    }
    public Transform[] destinations;
    void GetRandomDestination()
    {
        int index = Random.Range(0, destinations.Length);
        nav.SetDestination(destinations[index].position );
    }
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    NavMeshAgent nav;
}
