using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.Dynamics;

public class EnemyHealth : MonoBehaviour
{
    public GameManager gManager;
    public float health = 100f;
    public PuppetMaster puppetMaster;
    public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;
    public AudioManager AudioManager;
    

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

            // Debug.Log("Zombie is DEAD");

            AudioManager.PlaySound("zombieDeathSound");
            puppetMaster.Kill(stateSettings);
            
            

        }

        return health;
    }

    private void Update()
    {
        
    }
}

