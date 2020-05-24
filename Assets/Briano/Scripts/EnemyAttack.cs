using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    //public PlayerHealth player;
    public Collider attackbox;
    
    


    private void Start()
    {
       
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }
    
    public void activateAttack()
    {

        attackbox.enabled = true;
        Debug.Log("attack box enabled");
    }

    public void disableAttack()
    {
        attackbox.enabled = false;
        Debug.Log("attackbox disabled");
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag=="Player")
    //    {
    //        DealDamage();
    //        Debug.Log("Ouch");
    //    }

    //}

    
}
