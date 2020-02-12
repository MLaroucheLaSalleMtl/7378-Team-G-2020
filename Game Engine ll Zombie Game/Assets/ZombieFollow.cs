using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    private Vector3 destination;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    // Update is called once per frame
    void Update()
    {
      if(Vector3.Distance(destination,target.position)>1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
    }
}
