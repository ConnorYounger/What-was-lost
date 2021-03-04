using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleMetalDetector : MonoBehaviour
{
    //Distance detection
    public Transform target;
    private float distance;
    public Image signalStrength;
    //Score counting
    public Text scoreDist;
    public Text foundAlert;
    private int score = 0;
    private int randomRare;
    //Sound
    public AudioSource mDClick;
    public float maxFreq = 0.05f;
    float timer;
    
    void Update()
    {
        //tracks distance between player and object, triggering a Collect when the player walks over the object
        distance = Vector3.Distance(transform.position, target.position);
        signalStrength.fillAmount = (1.0f - (distance / 120));
        // print("distance = " + distance); (print distance from current object to console) //- debug
        scoreDist.text = score.ToString();
        if (Input.GetKeyDown("e"))
        {
            if (distance < 2)
            {
                Collect();
            }
            else
            {
                foundAlert.text = "There's nothing here...";
                Invoke("reset", 2);
            }
        }

        //Metal Detector Sound system
        timer += Time.deltaTime / distance;
        print(timer);
        if (timer > maxFreq)
        {
            mDClick.PlayOneShot(mDClick.clip, 1);
            timer = 0;
        }
    }
    void Collect() // Runs when an object is walked over
    {
        //++score;
        //Randomly decide rarity of found item: Rare: 0-10 10% Uncommon 11-40 30% Common 41-100 60%
        randomRare = (Random.Range(0, 100));
        if (randomRare < 10)
        {
            valuableItem();
        }
        else if (randomRare > 41)
        {
            commonItem();
        }
        else
        {
            uncommonItem();
        }

        //Randomize location of next item
        Vector3 pos = transform.position;

        pos.x = Random.Range(-45.0f, 45.0f);
        pos.y = 0;
        pos.z = Random.Range(-45.0f, 45.0f);

        transform.position = pos;
    }

    //Add different score amounts depending on rarity of found object and Alert player to rarity of found object
    void valuableItem()
    {
        score = score + 10;
        print("Rare Item Found!");
        foundAlert.text = "Rare Item Found!";
        Invoke("reset", 2);
    }
    void commonItem()
    {
        score = score + 1;
        print("Common Item Found!");
        foundAlert.text = "Common Item Found!";
        Invoke("reset", 2);
    }
    void uncommonItem()
    {
        score = score + 5;
        print("Uncommon Item Found!");
        foundAlert.text = "Uncommon Item Found!";
        Invoke("reset", 2);
    }
    void reset() // Clear the alert from the screen
    {
        foundAlert.text = "";
    }
 
}
