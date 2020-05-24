using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float damage;
    public float range;
    public float cooldown;
    public int maxAmmoAllowed;
    public int allAmmo;
    public int maxAmmo;
    public int currentAmmo;
    public bool outOfAmmo;
    public float unpin;
    public float force;

    public void GetAmmo()
    {
        allAmmo = maxAmmoAllowed;
    }
}
