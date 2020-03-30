using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractWithObjects : MonoBehaviour
{
    public GameManager gManager;
    public Camera cam;
    public int range = 1;
    public bool doll1 = false;
    public bool doll2 = false;
    public bool key = false;
    public GameObject doorBlue;//<----
    private Animator doorAnim;//<---
   // private DoorScript doorScript;

    
    

    void Start()
    {
       
        gManager = GameManager.instance;
        //doorScript = GetComponent<DoorScript>();
        //doorScript = door.GetComponent<DoorScript>();
        doorAnim = doorBlue.GetComponent<Animator>();//GameObject.FindGameObjectWithTag("blueDoor");
        
    }
    public void ItemHit()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            
            if(hit.collider.tag == "Pistol")
            {
                Debug.Log(hit.collider.tag);
                UnlockPistol pistol = hit.collider.GetComponent<UnlockPistol>();
                pistol.UnlockP();
            }
            if(hit.collider.tag == "Doll1")
            {
                doll1 = true;
                gManager.FoundDoll();
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.tag == "Doll2")
            {
                doll2 = true;
                gManager.FoundDoll();
                Destroy(hit.collider.gameObject);
            }
            if(hit.collider.tag=="Enemy")
            {
                

            }
            if(hit.collider.tag=="blueKey")
            {
                key = false;
                Destroy(hit.collider.gameObject);
                Debug.Log("has BLUE key");
            }
            if (hit.collider.gameObject==doorBlue)
            {
                Debug.Log("Door received RayCast");
                if (GameObject.FindGameObjectWithTag("blueKey") == null)
                {
                    Debug.Log("openSesamee");
                    //doorScript.KeyDestroyed(true);
                    //door.
                   
                    //doorScript.GetComponent<Animator>().SetBool("isOpen", true);
                    // doorAnim = door.GetComponent<Animator>();
                    doorAnim.SetBool("isOpen", true);
                    //Tag("blueDoor").GetComponent<Animator>().SetBool("isOpen", true);
                    //this.gameObject.GetComponent<EnemyHealth>().TakeDamage(40);


                }
                else { Debug.Log("missing the key!"); }
            }

        }
    }

    

}
