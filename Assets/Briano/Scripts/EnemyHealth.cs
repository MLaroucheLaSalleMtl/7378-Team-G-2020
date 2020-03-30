using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameManager gManager;
    public float health = 100f;
    

    void Start()
    {
        gManager = GameManager.instance;
        
    }

    public float TakeDamage(float damage)
    {
        

        health -= damage;
        Debug.Log("Enemy Health is " + health);
        if(health <= 0)
        {
            //Destroy(gameObject);
            //gManager.ChangeStartingMessage(3);
            //Animator anim = GetComponent<Animator>();
            //anim.enabled = false;
            GetComponent<RagDollScript>().DoRagdoll(true);
            //Destroy(this.gameObject);
           
        }

        return health;
    }

    private void Update()
    {
        
    }
}

