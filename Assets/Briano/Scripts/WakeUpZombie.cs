using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class WakeUpZombie : MonoBehaviour
{
    public PuppetMaster puppetMaster;
    public PuppetMaster puppetMaster1;
    public PuppetMaster puppetMaster2;
    public PuppetMaster puppetMaster3;
    public PuppetMaster puppetMaster4;
    public PuppetMaster puppetMaster5;
    public PuppetMaster puppetMaster6;
    public PuppetMaster puppetMaster7;
    public PuppetMaster puppetMaster8;
    public PuppetMaster puppetMaster9;
    public PuppetMaster puppetMaster10;
    public PuppetMaster puppetMaster11;
    public PuppetMaster puppetMaster12;
    public PuppetMaster puppetMaster13;
    public PuppetMaster puppetMaster14;
    public PuppetMaster puppetMaster15;
    public PuppetMaster puppetMaster16;
    public PuppetMaster puppetMaster17;

    public PuppetMaster.StateSettings stateSettings = PuppetMaster.StateSettings.Default;

    void Start()
    {
        puppetMaster.Freeze(stateSettings);
        puppetMaster1.Freeze(stateSettings);
        puppetMaster2.Freeze(stateSettings);
        puppetMaster3.Freeze(stateSettings);
        puppetMaster4.Freeze(stateSettings);
        puppetMaster5.Freeze(stateSettings);
        puppetMaster6.Freeze(stateSettings);
        puppetMaster7.Freeze(stateSettings);
        puppetMaster8.Freeze(stateSettings);
        puppetMaster9.Freeze(stateSettings);
        puppetMaster10.Freeze(stateSettings);
        puppetMaster11.Freeze(stateSettings);
        puppetMaster12.Freeze(stateSettings);
        puppetMaster13.Freeze(stateSettings);
        puppetMaster14.Freeze(stateSettings);
        puppetMaster15.Freeze(stateSettings);
        puppetMaster16.Freeze(stateSettings);
        puppetMaster17.Freeze(stateSettings);
    }

    void Update()
    {
        
    }

    public void WakeUp1()
    {
        puppetMaster.Resurrect();
        puppetMaster1.Resurrect();
        puppetMaster2.Resurrect();
    }
    public void WakeUp2()
    {
        puppetMaster3.Resurrect();
        puppetMaster4.Resurrect();
    }

    public void WakeUp3()
    {
        puppetMaster5.Resurrect();
        puppetMaster6.Resurrect();
        puppetMaster7.Resurrect();
    }

    public void WakeUp4()
    {
        puppetMaster8.Resurrect();
        puppetMaster9.Resurrect();
    }

    public void WakeUp5()
    {
        puppetMaster.Resurrect();
        puppetMaster1.Resurrect();
        puppetMaster2.Resurrect();
        puppetMaster3.Resurrect();
        puppetMaster4.Resurrect();
        puppetMaster5.Resurrect();
        puppetMaster6.Resurrect();
        puppetMaster7.Resurrect();
        puppetMaster8.Resurrect();
        puppetMaster9.Resurrect();
    }

    public void WakeUp6()
    {
        puppetMaster10.Resurrect();
        puppetMaster11.Resurrect();
        puppetMaster12.Resurrect();
        puppetMaster13.Resurrect();
        puppetMaster14.Resurrect();
        puppetMaster15.Resurrect();
        puppetMaster16.Resurrect();
        puppetMaster17.Resurrect();
    }

    public void ResurrectBasement()
    {
        Invoke("WakeUp6", 5);
    }
}
