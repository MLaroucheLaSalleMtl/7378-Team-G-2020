using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;

    public void OpenDoor()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("hasKey", true);

    }



}
