using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarparkGen : MonoBehaviour
{   public Transform[] spawns;
    public GameObject[] prefab;
    //Creating the Arrays
    void Start()
    { // Randomlu picks the number of cars to spawn, runs the spawn script that many times
        int carNum = Random.Range(1,5);
        for(int i=0; i<carNum; ++i)
        {
            Spawn();
        }
    }

   
    void Spawn()
    {
        int spotNum = Random.Range(0, 8);
        int prefabNum = Random.Range(0, 3);

        Instantiate(prefab[prefabNum], spawns[spotNum].position, spawns[spotNum].rotation);
        //todo - delete the spawn number after its picked to prevent duplicates
        //additionally - set the random range to reflect this (random.range(0, 8-i) ought to work)
    }
}
