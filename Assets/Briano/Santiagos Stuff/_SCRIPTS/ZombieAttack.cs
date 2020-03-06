//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using UnityEngine.AI;

//public class ZombieAttack : MonoBehaviour
//{
//    private Animator animator;
//    private bool _isDistanceCheck = false;
//    private float _timeLeft = 1.0f;
//    [SerializeField] private Transform target;
//    private NavMeshAgent agent;
//    private Vector3 destination;

//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        agent = GetComponent<NavMeshAgent>();
//        destination = agent.destination;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Vector3.Distance(destination, target.position) > 1.0f)
//        {
//            destination = target.position;
//            agent.destination = destination;
//            if (Vector3.Distance(destination, target.position) <= 0.0f)
//            {
//                animator.SetBool("attack", true);
//            }
//        }
//    }
//}
            
               

