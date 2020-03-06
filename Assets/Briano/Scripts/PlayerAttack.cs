using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameManager gManager;
    public Camera cam;
    public GameObject weapons;
    public WeaponStats currentWeaponStats;
    public Animator weaponAnim;
    public ParticleSystem muzzleFlash;
    public GameObject axe;
    public GameObject pistol;

    public int maxAmmo = 8;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;
    public bool switchWeapon = false;
    public bool unlockPistol = false;
    public float attackTimer = 0f;

    void Start()
    {
        gManager = GameManager.instance;
        SelectWeapon();
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    void SelectWeapon()
    {
        if (unlockPistol)
        {
            if (!switchWeapon)
            {
                axe.SetActive(true);
                pistol.SetActive(false);
                gManager.ammoText.text = "Infinity";
            }
            else
            {
                axe.SetActive(false);
                pistol.SetActive(true);
                gManager.ammoText.text = currentAmmo.ToString("D1") + "/8";
                isReloading = false;
            }
            currentWeaponStats = weapons.GetComponentInChildren<WeaponStats>();
            weaponAnim = currentWeaponStats.GetComponent<Animator>();
        }
        else
        {
            axe.SetActive(true);
            pistol.SetActive(false);
            gManager.ammoText.text = "Infinity";
            currentWeaponStats = weapons.GetComponentInChildren<WeaponStats>();
            weaponAnim = currentWeaponStats.GetComponent<Animator>();
        }
    }

    public void OnFire (InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(attackTimer >= currentWeaponStats.cooldown && isReloading == false)
            {
                if (switchWeapon)
                {
                    muzzleFlash.Play();
                }
                weaponAnim.SetTrigger("Shoot");
                weaponAnim.SetTrigger("Idle");
                AttackHit();
                attackTimer = 0f;
            }
        }
        
    }

    public void AttackHit()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, currentWeaponStats.range))
        {
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Enemy")
            {
                Debug.Log("Shot enemy");
                EnemyHealth health = hit.collider.GetComponent<EnemyHealth>();
                health.TakeDamage(currentWeaponStats.damage);
            }
        }
        if (switchWeapon)
        {
            currentAmmo--;
            gManager.ammoText.text = currentAmmo.ToString("D1") + "/8";
        }
    }

    public void SwitchAxe(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            switchWeapon = false;
            SelectWeapon();
        }
    }

    public void SwitchPistol(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(unlockPistol)
            {
                gManager.ChangeStartingMessage(2);
                switchWeapon = true;
                SelectWeapon();
            }
        }

    }

    public void SwitchGun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (unlockPistol)
            {
                gManager.ChangeStartingMessage(2);
                switchWeapon = !switchWeapon;
                SelectWeapon();
            }
        }   
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        gManager.ammoText.text = currentAmmo.ToString("D1") + "/8";
        isReloading = false;
    }
}

//public int currentWeapon = 0;

/*void Update()
    {
        int previousWeapon = currentWeapon;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(currentWeapon == 1)
            {
                currentWeapon = transform.childCount - 1;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentWeapon == 0)
            {
                currentWeapon = transform.childCount + 1;
            }
        }
        if(previousWeapon != currentWeapon)
        {
            SelectWeapon();
        }
    }*/

/*void SelectWeapon()
{
    int i = 0;
    foreach (Transform weapon in transform)
    {
        if (i == currentWeapon)
        {
            weapon.gameObject.SetActive(true);
        }
        else
        {
            weapon.gameObject.SetActive(false);
        }
        i++;
    }
    currentWeaponStats = weapons.GetComponentInChildren<WeaponStats>();
    weaponAnim = currentWeaponStats.GetComponent<Animator>();
}*/
