using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetDoorScript : MonoBehaviour
{
    public GameObject mDoor;
    public GameObject Panel1;
    mDoorAction mDoorAction;
    

    public void OnTriggerEnter(Collider other)
    {
        
            Debug.Log("Player Entered");
            mDoorAction = mDoor.GetComponent<mDoorAction>();
            mDoorAction.OpenDoor();

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
