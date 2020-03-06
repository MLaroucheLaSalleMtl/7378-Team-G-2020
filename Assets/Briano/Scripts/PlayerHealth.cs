using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gManager;
    public float health = 100f;

    void Start()
    {
        gManager = GameManager.instance;
        gManager.healthText.text = health.ToString("###");
    }

    public void TakeDamage()
    {
        health -= 10;
        gManager.healthText.text = health.ToString("###");
        Debug.Log(health);
        if (health <= 0)
        {
            gManager.Death();
        }
    }
}
