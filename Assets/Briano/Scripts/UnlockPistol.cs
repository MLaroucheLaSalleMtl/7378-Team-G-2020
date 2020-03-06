using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPistol : MonoBehaviour
{
    public GameManager gManager;
    public PlayerAttack player;

    void Start()
    {
        gManager = GameManager.instance;
    }

    public void UnlockP()
    {
        player.unlockPistol = true;
        gManager.ChangeStartingMessage(1);
        Destroy(gameObject);
    }
}
