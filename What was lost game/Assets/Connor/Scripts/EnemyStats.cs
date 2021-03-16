using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Character", menuName = "Enemy Characters/Enemy Character")]

public class EnemyStats : ScriptableObject
{
    public string characterName;

    public float triggerDistance;
    public float movementSpeed;
    public float coolDownTime;

    [HideInInspector]
    public Vector3 startLocation;
}
