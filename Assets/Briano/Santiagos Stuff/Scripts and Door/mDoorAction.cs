using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mDoorAction : MonoBehaviour
{
    public Animator doorAnimator;

    public void OpenDoor()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("brokePanel", true);

    }

}
