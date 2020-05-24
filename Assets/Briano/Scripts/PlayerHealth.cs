using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gManager;
    public float health = 100f;
    public int healthPack = 0;

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

    public void HealPlayer(InputAction.CallbackContext context)
    {
        if(healthPack>0 && health != 100)
        {
            health += 50;
            if (health > 100)
            {
                health = 100;
            }
            healthPack--;
            gManager.ChangeTurorialTextColor("Text (5)");
        }
        gManager.healthText.text = health.ToString("###");
    }
}
