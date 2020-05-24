using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRagdollTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RagDollScript ragDollScript = GetComponent<RagDollScript>();
        ragDollScript.DoRagdoll(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
