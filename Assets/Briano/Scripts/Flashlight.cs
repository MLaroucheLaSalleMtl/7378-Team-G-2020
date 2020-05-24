using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    public GameManager gManager;
    public bool isEnabled = false;
    public GameObject flashLight;

    void Start()
    {
        gManager = GameManager.instance;
    }
    public void FlashLight(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isEnabled = !isEnabled;
            if(isEnabled)
            {
                flashLight.SetActive(true);
                gManager.ChangeTurorialTextColor("Text (6)");
            }
            else
            {
                flashLight.SetActive(false);
            }
        }
    }
}
