using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] Enemy;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //makes the program remove a random amount of enemies from the start position
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < 42; i++)
        {
            RemoveRandom();
        }
        
    }
    void RemoveRandom()
    {
        //destroys the enemy
        int randomIndex = Random.Range(0, Enemy.Length);
        GameObject objectToDestroy = Enemy[randomIndex];
        Destroy(objectToDestroy);
       
    }

   
}
