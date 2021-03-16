﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenAI : MonoBehaviour
{
    public EnemyStats stats;

    private GameObject target;

    public string targetName;
    private string[] states;

    private int currentState;

    public float harassTime = 5;
    public int itemStealChance = 25;
    private float destinationOffset = 2f;
    private float timer;

    private bool hasItem;

    void Start()
    {
        SetStates();

        target = GameObject.Find(targetName);
    }

    private void SetStates()
    {
        states = new string[3] { "Idle", "Engage", "Cooldown" };

        stats.startLocation = transform.position;
    }

    void Update()
    {
        CurrentState();

        if (Input.GetKeyDown(KeyCode.F))
        {
            StopEngageing();
        }
    }

    private void CurrentState()
    {
        if(currentState == 0)
        {
            Idle();
        }
        else if (currentState == 1)
        {
            Engage();
        }
        else if (currentState == 2)
        {
            CoolDown();
        }
    }

    void Idle()
    {
        Debug.Log("current state = Idle");
        // Play Idle Animation

        if (target)
        {
            if(Vector3.Distance(target.transform.position, transform.position) < stats.triggerDistance && currentState == 0)
            {
                Trigger();
            }
        }
    }

    public void Trigger()
    {
        if(currentState == 0)
        currentState = 1;
    }

    void Engage()
    {
        Debug.Log("current state = Engauge");

        if (!hasItem)
        {
            // Play running animation

            if(Vector3.Distance(transform.position, target.transform.position) > destinationOffset)
            {
                // Move towards player
                transform.LookAt(target.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, stats.movementSpeed * Time.deltaTime);

                Debug.Log("Move towards player");
                Debug.Log("Distance = " + Vector3.Distance(transform.position, target.transform.position) + " / " + destinationOffset);
            }
            else
            {
                if(timer < harassTime)
                {
                    timer += Time.deltaTime;

                    Debug.Log("Timer = " + timer);
                }
                else
                {
                    int random = Random.Range(0, 100);

                    Debug.Log("Random steal chance = " + random);

                    if (random <= itemStealChance)
                    {
                        hasItem = true;
                    }

                    timer = 0;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, stats.startLocation) > destinationOffset)
            {
                // Move to starting position
                transform.LookAt(stats.startLocation);
                transform.position = Vector3.MoveTowards(transform.position, stats.startLocation, stats.movementSpeed * Time.deltaTime);

                Debug.Log("Move towards starting pos");                
            }
            else
            {
                // Look at player
                transform.LookAt(target.transform.position);

                Debug.Log("Look at player and wait");

                // Play laughing animation ??? + sound ?? maybe playing animation ?
            }
        }
    }

    public void StopEngageing()
    {
        Debug.Log("Stop Engaging");

        currentState = 2;

        hasItem = false;
        timer = 0;
    }

    void CoolDown()
    {
        Debug.Log("current state = CoolDown");

        if (Vector3.Distance(transform.position, stats.startLocation) > destinationOffset)
        {
            // Move to starting position
            transform.LookAt(stats.startLocation);
            transform.position = Vector3.MoveTowards(transform.position, stats.startLocation, stats.movementSpeed * Time.deltaTime);
        }
        else
        {
            // Start cool down timer
            if(timer < stats.coolDownTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                currentState = 0;
                timer = 0;
            }
        }
    }
}
