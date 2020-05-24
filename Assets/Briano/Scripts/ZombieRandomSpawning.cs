using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRandomSpawning : MonoBehaviour
{
    public GameObject zombie;
    public float xPos;
    public float zPos;
    public int enemyCount;


    IEnumerator EnemyDrop()
    {
        while(enemyCount<10)
        {
            xPos = Random.Range(93,112);
            zPos = Random.Range(93, 130);
            Instantiate(zombie, new Vector3(xPos, 438, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            Debug.Log("new zombie");
            enemyCount += 1;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
