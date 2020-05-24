using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioClip clipZombieAttack, clipZombieDead,clipZombieAwake;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        clipZombieAttack = Resources.Load<AudioClip>("zombieAttackSound");
        clipZombieDead = Resources.Load<AudioClip>("zombieDeathSound");
        clipZombieAwake = Resources.Load<AudioClip>("zombieAwakeSound");


        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {

            case "zombieAttackSound":

                audioSource.PlayOneShot(clipZombieAttack);

                break;

            case "zombieDeathSound":

                audioSource.PlayOneShot(clipZombieDead);
                

                break;

            case "zombieAwakeSound":

                audioSource.PlayOneShot(clipZombieAwake);


                break;

        }

    }

}


