using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGenerator : MonoBehaviour
{
    public GameObject[] possibleExits;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        // makes a random possible exit point go away so that the player never knows where they have to go
        possibleExits = GameObject.FindGameObjectsWithTag("PossibleExit");

        RemoveRandom();
    }
    void RemoveRandom()
    {
        int randomIndex = Random.Range(0, possibleExits.Length);
        GameObject objectToDestroy = possibleExits[randomIndex];
        Destroy(objectToDestroy);
        //DestroyObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
