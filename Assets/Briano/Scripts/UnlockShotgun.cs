using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockShotgun : MonoBehaviour
{
    public GameManager gManager;
    public PlayerAttack player;

    void Start()
    {
        gManager = GameManager.instance;
    }

    public void UnlockS()
    {
        player.unlockShotgun = true;
        Destroy(gameObject);
    }
}
