using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponScriptable : ScriptableObject
{
    public string wsName;
    public int wsPrice;
    public int wsDamage;
    public int wsCritDamage;
    public int wsCritChance;
    [TextArea]
    public string wsDescription;
}
