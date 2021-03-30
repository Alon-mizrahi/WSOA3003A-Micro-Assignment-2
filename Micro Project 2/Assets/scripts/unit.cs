using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string UnitName;

    //add the three types of HP and there current levels
    public float maxPysicality;
    public float currentPysicality;

    public float maxJoy;
    public float currentJoy;

    public float maxMeaning;
    public float currentMeaning;


    public bool isDead()
    {
        if (currentPysicality <= 0 || currentJoy<=0 ||currentMeaning<=0) { return true; } else { return false; }
    }


}
