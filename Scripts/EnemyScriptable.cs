using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptable : ScriptableObject
{
    public string esName;
    public int esDamage;
    public bool esIsGun;
    public int esHealth;
    public int esSpeed;
    public float esRadius;
    [TextArea]
    public string esDescription;
    public int esDrop;
    public float esDropTime;
    public int esCooldown;
    [Range(1, 100)]
    public int esAccuracy;
}
