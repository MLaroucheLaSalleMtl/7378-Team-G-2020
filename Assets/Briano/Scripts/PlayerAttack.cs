using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using RootMotion.Dynamics; 

public class PlayerAttack : MonoBehaviour
{
    public GameManager gManager;
    public Camera cam;
    public GameObject weapons;
    public WeaponStats cWS; //currentWeaponStats
    public Animator weaponAnim;
    public ParticleSystem muzzleFlash;
    public GameObject axe;
    public GameObject pistol;
    public GameObject shotgun;
    public InteractWithObjects objects;
    public AudioSource audioGun;
    public WakeUpZombie zombies;
    public GameObject spawner;

    public float reloadTime = 2f;
    private bool isReloading = false;
    public bool switchWeapon = false;
    public bool nothingActive = true;
    public bool unlockPistol = false;
    public bool unlockShotgun = false;
    public float attackTimer = 0f;
    public int damagedArea;

    
    public LayerMask layers;
    public ParticleSystem blood;
    

    void Start()
    {
        gManager = GameManager.instance;
        SelectWeapon();
    }

    void Update()
    {
        if(!nothingActive)
        {
            attackTimer += Time.deltaTime;
            if (isReloading)
            {
                return;
            }
            if (cWS.currentAmmo <= 0 && !cWS.outOfAmmo)
            {
                StartCoroutine(Reload());
                return;
            }
        }
    }

    public void SelectWeapon()
    {
        if(!nothingActive)
        {
            if (unlockPistol && !unlockShotgun)
            {
                pistol.SetActive(true);
                shotgun.SetActive(false);
                cWS = weapons.GetComponentInChildren<WeaponStats>();
                weaponAnim = cWS.GetComponent<Animator>();
                muzzleFlash = GetComponentInChildren<ParticleSystem>();
                audioGun = GetComponentInChildren<AudioSource>();
                gManager.ammoText.text = cWS.currentAmmo.ToString("D1") + "/" + cWS.allAmmo.ToString("D2");
                isReloading = false;
            }
            else
            {
                if (switchWeapon)
                {
                    pistol.SetActive(false);
                    shotgun.SetActive(true);
                    cWS = weapons.GetComponentInChildren<WeaponStats>();
                    weaponAnim = cWS.GetComponent<Animator>();
                    muzzleFlash = GetComponentInChildren<ParticleSystem>();
                    audioGun = GetComponentInChildren<AudioSource>();
                    gManager.ammoText.text = cWS.currentAmmo.ToString("D1") + "/" + cWS.allAmmo.ToString("D2");
                    isReloading = false;
                }
                else
                {
                    pistol.SetActive(true);
                    shotgun.SetActive(false);
                    cWS = weapons.GetComponentInChildren<WeaponStats>();
                    weaponAnim = cWS.GetComponent<Animator>();
                    muzzleFlash = GetComponentInChildren<ParticleSystem>();
                    audioGun = GetComponentInChildren<AudioSource>();
                    gManager.ammoText.text = cWS.currentAmmo.ToString("D1") + "/" + cWS.allAmmo.ToString("D2");
                    isReloading = false;
                }
            }
        }
    }

    public void OnFire (InputAction.CallbackContext context)
    {
        if (context.started)
        { 
            if(!nothingActive && !gManager.gamePaused)
            {
                if (attackTimer >= cWS.cooldown && isReloading == false)
                {
                    if (cWS.currentAmmo > 0)
                    {
                        audioGun.Play();
                        muzzleFlash.Play();
                        weaponAnim.SetTrigger("Shoot");
                        weaponAnim.SetTrigger("Idle");
                        AttackHit();
                        attackTimer = 0f;
                        cWS.currentAmmo--;
                        gManager.ammoText.text = cWS.currentAmmo.ToString("D1") + "/" + cWS.allAmmo.ToString("D2");
                    }
                }
            }
        }
    }

    public void AttackHit()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, cWS.range,layers))
        {
            Debug.Log(hit.collider.gameObject);
            
            var broadcaster = hit.collider.attachedRigidbody.GetComponent<MuscleCollisionBroadcaster>();



            if (broadcaster != null)
            {
                broadcaster.Hit(cWS.unpin, ray.direction * cWS.force, hit.point);
                Debug.Log("Shot enemy");
                blood.transform.position = hit.point;
                blood.transform.rotation = Quaternion.LookRotation(-ray.direction);
                blood.Emit(5);
                EnemyHealth health = hit.collider.GetComponentInParent<EnemyHealth>();
                health.TakeDamage(cWS.damage);
            }
        }
    }

    public void SwitchPistol(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (unlockPistol)
            {
                switchWeapon = false;
                SelectWeapon();
            }
        }
    }

    public void SwitchShotgun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(unlockPistol)
            {
                switchWeapon = true;
                SelectWeapon();
            }
        }
    }

    public void MeleeHit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(MeleeAttack());
            return;
        }
    }

    IEnumerator MeleeAttack()
    {
        pistol.SetActive(false);
        shotgun.SetActive(false);
        axe.SetActive(true);
        weaponAnim = axe.GetComponent<Animator>();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Debris")
            {
                Debug.Log("Shot enemy");
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.tag == "panel1")
            {
                gManager.Message("Power off!");
                gManager.ChangeTurorialTextColor("Text (8)");
                objects.metalicDoor1 = true;
            }
            else if (hit.collider.tag == "panel2")
            {
                gManager.Message("Power off!");
                objects.metalicDoor2 = true;
            }
            else if (hit.collider.tag == "panel3")
            {
                gManager.Message("Power off!");
                objects.metalicDoor3 = true;
                //spawner.SetActive(true);
                zombies.WakeUp4();
                zombies.WakeUp3();
                zombies.WakeUp2();
                zombies.WakeUp1();
            }
        }
        weaponAnim.SetTrigger("Shoot");
        yield return new WaitForSeconds(1);
        weaponAnim.SetTrigger("Idle");
        axe.SetActive(false);
        SelectWeapon();
    }

    public void SwitchGun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!nothingActive)
            {
                switchWeapon = !switchWeapon;
                SelectWeapon();
            }
        }   
    }

    public void ReloadGun()
    {
        if (!nothingActive)
        {
            if (cWS.currentAmmo < cWS.maxAmmo)
            {
                StartCoroutine(Reload());
                return;
            }
        }
    }
    IEnumerator Reload()
    {
        if(cWS.allAmmo > 0)
        {
            gManager.ammoText.text = "Reloading";
            isReloading = true;
            yield return new WaitForSeconds(reloadTime);
            
                if(cWS.currentAmmo + cWS.allAmmo >= cWS.maxAmmo)
                {
                cWS.allAmmo -= cWS.maxAmmo - cWS.currentAmmo;
                cWS.currentAmmo = cWS.maxAmmo;
            }
                else if(cWS.currentAmmo + cWS.allAmmo < cWS.maxAmmo)
                {
                cWS.currentAmmo += cWS.allAmmo;
                cWS.allAmmo = 0;
                cWS.outOfAmmo = true;
                }
        gManager.ammoText.text = cWS.currentAmmo.ToString("D1") + "/" + cWS.allAmmo.ToString("D2");
        isReloading = false;
        }
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
