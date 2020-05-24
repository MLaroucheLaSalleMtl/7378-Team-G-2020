using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem1 : MonoBehaviour
{
    private float health=100;

    private void OnCollisionEnter(Collision collision)
    {
        if(this)
        {
            //this.collider.

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Health is: " + health);

        
    }
}
