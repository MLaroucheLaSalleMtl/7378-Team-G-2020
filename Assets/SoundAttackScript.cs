using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAttackScript : MonoBehaviour
{
    public AudioSource zombieAttSound;

    public void playAttackSound()
    {
        zombieAttSound.Play();

    }
}
