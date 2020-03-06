using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] public Transform target;
    private Vector3 destination;


    private Animator anim;
    public float speed;
    Vector3 velocity; // / deltatime??

    

    void DistanceToAttack()
    {
        if (target)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            //Debug.Log("Distance to target: " + dist);
            if(dist<=3.5f)
            {
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("attack", false);
                anim.SetFloat("speed", 1.0f);
            }
        }
    }




    public void AttackEnd(Collider collider)
    {
        //if(collider.gameObject.tag == "Player")
        //{
        //    PlayerHealth health = collider.GetComponent<PlayerHealth>();
        //    health.TakeDamage();
        //}
       
    }

    //float speed = agent.GetComponent < "speed" >;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        DistanceToAttack();
        
        //speed = agent.velocity
    }

    //You can also check if (nav.velocity != Vector3.zero) which will show movement if true.

    // Update is called once per frame
    void Update()
    {
      if(Vector3.Distance(destination,target.position)>1.0f)
        {
            destination = target.position;
            agent.destination = destination;
            //Debug.Log(agent.velocity);
            anim.SetFloat("speed", 1.0f);

            DistanceToAttack();
            //if (this.gameObject.)   //Vector3.Distance(destination, target.position) <= 1.0f its wrong wrong formula
            //{
            //    anim.SetBool("attack", true);
            //}

            //{
            //    anim.SetBool("attack", false);

            //}


            //if(agent.velocity!=Vector3.zero)
            //{
            //    anim.SetFloat("speed", 1.0f);
            //    Debug.Log(agent.velocity != Vector3.zero);
            //}

            //if(velocity>=speed)
            //{

            //}
            // if (!destination () >=0){walk}

        }

    }
}
