using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorScript : MonoBehaviour
{
    public Animator dooranim;
    //public GameObject key;
    //public GameObject player;
   // public Collider backDoorCollider;
    //private bool checkKey = false;//<-------

    //1) When player takes key, pc checks and it opens. 
    //2) When player has key and goes to the door, Box collider checks for destroyed key, if checked opens door
    //3) pc asks for "use key" from the inventory

    

    //public void hasKey()
    //{


    //}

    public void KeyDestroyed(bool checkKey)
    {
      
        if(checkKey==true)
        {
            Debug.Log("Now it has to open");
            dooranim.SetBool("isOpen", true);

        }
        if(checkKey==false)
        {
            dooranim.SetBool("isOpen",false);
            Debug.Log("Needa key for that");
        }
    }


    //public void isKeyDestroyed()
    //{
    //    if (GameObject.FindGameObjectWithTag("key") == null)
    //    {
    //        dooranim.SetBool("isOpen", true);
    //        Debug.Log("openSesamee");

            


    //    }

    //}



    //public void isPlayerInside()
    //{
    //    //if (dooranim.GetBool("isOpen")) 



    //}



 
    void Start()
    {
        KeyDestroyed(false);

    }

    // Update is called once per frame
    void Update()
    {
        //KeyDestroyed(fals);<---Should have had included that.. ?
        
    }
}
