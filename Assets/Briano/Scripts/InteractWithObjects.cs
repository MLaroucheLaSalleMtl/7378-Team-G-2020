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

    void Start()
    {
        gManager = GameManager.instance;
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
        }
    }
}
