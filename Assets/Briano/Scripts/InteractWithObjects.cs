using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractWithObjects : MonoBehaviour
{
    public GameManager gManager;
    public Camera cam;
    public PlayerAttack player;
    public PlayerHealth playerHealth;
    public DoorScript doorScript;
    public WakeUpZombie zombies;

    public float range = 3.5f;
    public bool blueKey = false;
    public bool greenKey = false;
    public bool purpleKey = false;
    public bool redKey = false;
    public bool metalicDoor1 = false;
    public bool metalicDoor2 = false;
    public bool metalicDoor3 = false;


    void Start()
    {
        gManager = GameManager.instance;
    }
    public void ItemHit(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Pistol")
                {
                    gManager.Message("Equiped pistol");
                    gManager.ChangeTurorialTextColor("Text (1)");
                    UnlockPistol pistol = hit.collider.GetComponent<UnlockPistol>();
                    pistol.UnlockP();
                }
                else if (hit.collider.tag == "Shotgun")
                {
                    gManager.Message("Equiped shotgun");
                    UnlockShotgun shotgun = hit.collider.GetComponent<UnlockShotgun>();
                    shotgun.UnlockS();
                }
                else if (hit.collider.tag == "Ammo")
                {
                    if(!player.nothingActive)
                    {
                        player.cWS.GetAmmo();
                        gManager.Message("Max Ammo");
                        gManager.ChangeTurorialTextColor("Text (2)");
                        gManager.ammoText.text = player.cWS.currentAmmo.ToString("D1") + "/" + player.cWS.allAmmo.ToString("D2");
                    }
                    else
                    {
                        gManager.Message("Cannot take ammo without a gun!");
                    }
                }
                else if (hit.collider.tag == "HealthPack")
                {
                    gManager.Message("Obtained health pack");
                    playerHealth.healthPack++;
                    gManager.ChangeTurorialTextColor("Text (3)");
                    gManager.health++;
                    gManager.UpdateInventory();
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "Doll")
                {
                    gManager.doll++;
                    gManager.Message("Picked up " + gManager.doll.ToString("D1") + "/5 dolls!");
                    gManager.UpdateInventory();
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "blueKey")
                {
                    gManager.Message("Obtained blue key!");
                    gManager.ChangeTurorialTextColor("Text (7)");
                    gManager.blueKey++;
                    gManager.UpdateInventory();
                    blueKey = true;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "greenKey")
                {
                    gManager.Message("Obtained green key!");
                    gManager.greenKey++;
                    gManager.UpdateInventory();
                    greenKey = true;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "purpleKey")
                {
                    gManager.Message("Obtained purple key!");
                    gManager.purpleKey++;
                    gManager.UpdateInventory();
                    purpleKey = true;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "redKey")
                {
                    gManager.Message("Obtained red key!");
                    gManager.redKey++;
                    gManager.UpdateInventory();
                    redKey = true;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "blueDoor")
                {
                    if (blueKey)
                    {
                        doorScript = hit.collider.GetComponent<DoorScript>();
                        doorScript.OpenDoor();
                        zombies.WakeUp2();
                    }
                    else { gManager.Message("Missing the Blue key!"); }
                }
                else if (hit.collider.tag == "greenDoor")
                {
                    Debug.Log("Green Door received RayCast");
                    if (greenKey)
                    {
                        Debug.Log("openSesamee");
                        doorScript = hit.collider.GetComponent<DoorScript>();
                        doorScript.OpenDoor();
                        zombies.WakeUp4();
                    }
                    else { gManager.Message("Missing the Green key!"); }
                }
                else if (hit.collider.tag == "purpleDoor")
                {
                    Debug.Log("Purple Door received RayCast");
                    if (purpleKey)
                    {
                        Debug.Log("openSesamee");
                        doorScript = hit.collider.GetComponent<DoorScript>();
                        doorScript.OpenDoor();
                    }
                    else { gManager.Message("Missing the Purple key!"); }
                }
                else if (hit.collider.tag == "redDoor")
                {
                    Debug.Log("Red Door received RayCast");
                    if (redKey)
                    {
                        Debug.Log("openSesamee");
                        doorScript = hit.collider.GetComponent<DoorScript>();
                        doorScript.OpenDoor();
                        gManager.StartCoroutine("Survived");
                    }
                    else { gManager.Message("Missing the red key!"); }
                }
                else if (hit.collider.tag == "panel1")
                {
                    gManager.Message("Break with axe!");
                }
                else if (hit.collider.tag == "panel2")
                {
                    gManager.Message("Break with axe!");
                }
                else if (hit.collider.tag == "panel3")
                {
                    gManager.Message("Break with axe!");
                }
                else if(hit.collider.tag == "MetalDoor1")
                {
                    if(metalicDoor1)
                    {
                        mDoorAction door = hit.collider.GetComponentInParent<mDoorAction>();
                        door.OpenDoor();
                        gManager.finishedTutorial = true;
                        gManager.tutorialPanel.SetActive(false);
                        zombies.WakeUp1();
                    }
                    else
                    {
                        gManager.Message("Turn off power to open");
                    }
                }
                else if (hit.collider.tag == "MetalDoor2")
                {
                    if (metalicDoor2)
                    {
                        mDoorAction door = hit.collider.GetComponentInParent<mDoorAction>();
                        door.OpenDoor();
                        zombies.ResurrectBasement();
                    }
                    else
                    {
                        gManager.Message("Turn off power to open");
                    }
                }
                else if (hit.collider.tag == "MetalDoor3")
                {
                    if (metalicDoor3)
                    {
                        mDoorAction door = hit.collider.GetComponentInParent<mDoorAction>();
                        door.OpenDoor();
                    }
                    else
                    {
                        gManager.Message("Turn off power to open");
                    }
                }
                else if(hit.collider.tag == "Debris")
                {
                    gManager.Message("Try hitting with axe");
                }
                else
                {
                    return;
                }
            }
        }
    }
}
