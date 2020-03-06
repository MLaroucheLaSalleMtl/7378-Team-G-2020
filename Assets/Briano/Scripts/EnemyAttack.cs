using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth player;
    public void DealDamage()
    {
        player.TakeDamage();
    }
}
