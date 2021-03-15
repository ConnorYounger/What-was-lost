using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarparkGen : MonoBehaviour
{   public Transform[] spawns;
    public GameObject[] prefab;
    // Start is called before the first frame update
    void Start()
    {
        int carNum = Random.Range(1,5);
        for(int i=0; i<carNum; ++i)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Spawn()
    {
        int spotNum = Random.Range(0, 8);
        int prefabNum = Random.Range(0, 3);

        Instantiate(prefab[prefabNum], spawns[spotNum].position, spawns[spotNum].rotation);
    }
}
