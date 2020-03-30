using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagDollScript : MonoBehaviour
{
    
    private Component[] hingeJoints;
    [SerializeField] private Collider core;
    //public Collider[] allColliders;
 

    // Start is called before the first frame update
    void Start()
    {
        hingeJoints = GetComponentsInChildren<Collider>();

        foreach(Collider joint in hingeJoints)
        {
            if(joint !=core)
            {
                joint.enabled = false;
            }
        }
        //mainCollider = GetComponent<Collider>();
        //allColliders = GetComponentsInChildren<Collider>(true);
        DoRagdoll(false);
        
    }

    // Update is called once per frame
    public void DoRagdoll(bool isRagdoll)
    {
        if (isRagdoll == true)
        {
            
            NavMeshAgent agent=GetComponent<NavMeshAgent>();
            agent.enabled = false;
            
            foreach (Collider joint in hingeJoints)
            {
                joint.enabled = true;
                joint.GetComponentInChildren<Rigidbody>().isKinematic = false;

            }
            core.enabled = false;
            Animator anim = GetComponent<Animator>();
            anim.enabled = false;

        }
        //foreach (var col in allColliders)
        //{
        //    col.enabled = isRagDoll;
        //    mainCollider.enabled = !isRagDoll;
        //    GetComponent<Animator>().enabled = !isRagDoll;
        //    GetComponent<NavMeshAgent>().enabled = !isRagDoll;

        //}

    }
}
