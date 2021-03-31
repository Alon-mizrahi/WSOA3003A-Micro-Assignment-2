using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string UnitName;

    //add the three types of HP and there current levels
    public float maxHP;
    public float currentHP;

    public float maxAtkMod;
    public float currentAtkMod;

    public float maxDefMod;
    public float currentDefMod;


    public bool isDead()
    {
        if (currentHP <= 0) { return true; } else { return false; }
    }


}
