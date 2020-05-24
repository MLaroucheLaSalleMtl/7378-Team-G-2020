using UnityEngine;
using System.Collections;
using RootMotion.Dynamics;

namespace RootMotion.Demos
{
    public class NavMeshPuppet : MonoBehaviour
    {
        public BehaviourPuppet puppet;
        public UnityEngine.AI.NavMeshAgent agent;
        public Transform target;
        public Animator animator;
        public AudioSource zombieAudio;
        public static AudioClip clipZombieAttack, clipZombieDead, clipZombieAwake;
        public AudioSource zombieAttackSound;
        //public SoundAttackScript soundAttackScript;
        //public AudioManager audioManager;


        private void Start()
        {
            target = GameObject.FindWithTag("Player").transform;
            clipZombieAttack = Resources.Load<AudioClip>("zombieAttackSound");
            clipZombieDead = Resources.Load<AudioClip>("zombieDeathSound");
            clipZombieAwake = Resources.Load<AudioClip>("zombieAwakeSound");




        }

        void Update()
        {
            // Keep the agent disabled while the puppet is unbalanced.
            agent.enabled = puppet.state == BehaviourPuppet.State.Puppet;
         
            // Update agent destination and Animator
            if (agent.enabled)
            {
                agent.SetDestination(target.position);

                animator.SetFloat("Forward", agent.velocity.magnitude * 0.35f);

                IsBalanced();
                
                DistanceToAttack();
            }
        }

        void DistanceToAttack()
        {
            if (target)
            {
                float dist = Vector3.Distance(target.position, transform.position);
                if (dist <= 2.8f)
                {
                    animator.SetBool("attack", true);
                    PlayAttackSound();
                    //audioManager.PlaySound("zombieAttackSound");
                    //zombieAudio.Stop();
                    //zombieAudio.PlayOneShot(clipZombieAttack);
                    
                    

                    
                }
                else
                {
                    
                    animator.SetBool("attack", false);
                    
                }
            }
        }


        public void IsBalanced()
        {
         
            animator.SetBool("isBalanced", true);

        }

        public void IsNotBalanced()
        {
         
            animator.SetBool("isBalanced", false);
        }

        public void PlayAttackSound()
        {
            zombieAttackSound.Play();
            
        }

    }

}
