using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class AwakeZombie : MonoBehaviour
{
    //public PuppetMaster puppetMaster;
    //public PuppetMaster puppetMaster1;
    public PuppetMaster puppetMaster2;
    //public PuppetMaster puppetMaster3;
    public GameObject player;
    //public GameObject zombiePrefab;
    //public GameObject zombiePrefab1;
    //public GameObject zombiePrefab3;

    public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;

    public void OnTriggerEnter(Collider other)
    {
        if(player)
        {
            Debug.Log("Player entered awaking zone");
            //puppetMaster.Resurrect();
            //puppetMaster1.Resurrect();
            puppetMaster2.Resurrect();
            //puppetMaster3.Resurrect();
        }
        

    }




    // Start is called before the first frame update
    void Start()
    {

        //puppetMaster.Freeze(stateSettings);
        //puppetMaster1.Freeze(stateSettings);
        puppetMaster2.Freeze(stateSettings);
        //puppetMaster3.Freeze(stateSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
