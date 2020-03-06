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

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gManager.ChangeStartingMessage(3);
            Destroy(this.gameObject);
        }
    }
}
