using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUnit : MonoBehaviour
{
    public string CardName;
    public string CardDiscription;

    //actual text elements
    public Text cardType;

//Player values and text
    public float PlayerHPVal;
    public float PlayerAtkModVal;
    public float PlayerDefModVal;

    public Text PlayerHPValtxt;
    public Text PlayerAtkModValtxt;
    public Text PlayerDefModValtxt;


//Enemy values and text
    public float EnemyHPVal;
    public float EnemyAtkModVal;
    public float EnemyDefModVal;

    public Text EnemyHPValtxt;
    public Text EnemyAtkModValtxt;
    public Text EnemyDefModValtxt;


    //public bool isATKCard;

    battleSystem battleSystem;
    public GameObject battlesystm;
    private void Start()
    {
        battleSystem = battlesystm.GetComponent<battleSystem>();

        cardType.text = CardName;

        PlayerHPValtxt.text = ""+ PlayerHPVal;
        PlayerAtkModValtxt.text = ""+ PlayerAtkModVal;
        PlayerDefModValtxt.text = ""+ PlayerDefModVal;

        EnemyHPValtxt.text = "" + EnemyHPVal;
        EnemyAtkModValtxt.text = "" + EnemyAtkModVal;
        EnemyDefModValtxt.text = "" + EnemyDefModVal;


    }


    //Player card used CALLED BY CARD BUTTON PRESS
    public void ATKCardUsed()
    {
        // send card unit data to Attack card function (battlesystem)
        battleSystem.OnAttackCard(PlayerHPVal, PlayerDefModVal, PlayerAtkModVal, this.gameObject, EnemyHPVal, EnemyDefModVal, EnemyAtkModVal);    
    }


    public void EnemyCardUsed()
    {
        battleSystem.EnemyCardUsed(PlayerHPVal, PlayerDefModVal, PlayerAtkModVal, this.gameObject, EnemyHPVal, EnemyDefModVal, EnemyAtkModVal);
    }

}
