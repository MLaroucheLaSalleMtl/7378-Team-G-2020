using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{


    public PlayerHealth player;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DealDamage();
            Debug.Log("Ouch");
        }

    }
    public void DealDamage()
    {
        
        player.TakeDamage();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
