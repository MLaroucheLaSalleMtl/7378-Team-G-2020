using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWakeUpCollider : MonoBehaviour
{
    public WakeUpZombie zombie;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            zombie.WakeUp3();
            gameObject.SetActive(false);
        }
    }
}
