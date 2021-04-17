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


    CardSystem cardsystem;

    battleSystem battleSystem;
    public GameObject battlesystm;
    private void Start()
    {
        cardsystem = GameObject.Find("CardSystem").GetComponent <CardSystem>();
        cardsystem.CardDescription.gameObject.SetActive(false);

        battleSystem = battlesystm.GetComponent<battleSystem>();

        cardType.text = CardName;



        if (PlayerHPVal == 0)
        {
            PlayerHPValtxt.enabled = false;
            //turn icon off? will have to make public image and redo cards
        }
        else {
            if (PlayerHPVal > 0)
            {
                PlayerHPValtxt.text = "+" + PlayerHPVal;
            }
            else
            {
                PlayerHPValtxt.text = "" + PlayerHPVal;
            }
        }

        if (PlayerAtkModVal == 0)
        {
            PlayerAtkModValtxt.enabled = false;
            //turn icon off? will have to make public image and redo cards
        }
        else
        {
            if (PlayerAtkModVal > 0)
            {
                PlayerAtkModValtxt.text = "+" + PlayerAtkModVal;
            }
            else
            {
                PlayerAtkModValtxt.text = "" + PlayerAtkModVal;
            }
        }

        if (PlayerDefModVal == 0)
        {
            PlayerDefModValtxt.enabled = false;
            //turn icon off? will have to make public image and redo cards
        }
        else
        {
            if (PlayerDefModVal > 0)
            {
                PlayerDefModValtxt.text = "+" + PlayerDefModVal;
            }
            else
            {
                PlayerDefModValtxt.text = "" + PlayerDefModVal;
            }
        }

        if (EnemyHPVal == 0)
        {
            EnemyHPValtxt.enabled = false;
            //turn icon off? will have to make public image and redo cards
        }
        else
        {
            if (EnemyHPVal > 0)
            {
                EnemyHPValtxt.text = "+" + EnemyHPVal;
            }
            else
            {
                EnemyHPValtxt.text = "" + EnemyHPVal;
            }
        }

        if (EnemyAtkModVal == 0)
        {
            EnemyAtkModValtxt.enabled = false;
            //turn icon off? will have to make public image and redo cards
        }
        else
        {
            if (EnemyAtkModVal > 0)
            {
                EnemyAtkModValtxt.text = "+" + EnemyAtkModVal;
            }
            else
            {
                EnemyAtkModValtxt.text = "" + EnemyAtkModVal;
            }
        }

        if (EnemyDefModVal == 0)
        {
            EnemyDefModValtxt.enabled = false;
            //turn icon off? will have to make public image and redo cards
        }
        else
        {
            if (EnemyDefModVal > 0)
            {
                EnemyDefModValtxt.text = "+" + EnemyDefModVal;
            }
            else
            {
                EnemyDefModValtxt.text = "" + EnemyDefModVal;
            }
        }
    }

    private void OnMouseOver()
    {
        // Widen the object by 0.1
        transform.localScale = new Vector3(1.5f, 1.5f, 0.02f);
        cardsystem.CardDescription.gameObject.SetActive(true);
        if (CardName == "Brawler") { cardsystem.CardDescription.text = "Does high damage but its recklessness also hurts you"; }
        else if (CardName == "Caster") { cardsystem.CardDescription.text = "Effects the enemys modifier values"; }
        else if (CardName == "Healer") { cardsystem.CardDescription.text = "This card Focuses on healing and defence"; }
        else if (CardName == "Soldier") { cardsystem.CardDescription.text = "Soldiers do low damage but increase your modifiers"; }//Soldiers are strong in groups. While holding in your hand it increases your Atk or Def modifiers
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 0.02f);
        cardsystem.CardDescription.gameObject.SetActive(false);
    }


    //Player card used CALLED BY CARD BUTTON PRESS
    public void ATKCardUsed()
    {
        cardsystem.CardDescription.gameObject.SetActive(false);
        // send card unit data to Attack card function (battlesystem)
        battleSystem.OnAttackCard(PlayerHPVal, PlayerDefModVal, PlayerAtkModVal, this.gameObject, EnemyHPVal, EnemyDefModVal, EnemyAtkModVal);    
    }


    public void EnemyCardUsed()
    {
        battleSystem.EnemyCardUsed(PlayerHPVal, PlayerDefModVal, PlayerAtkModVal, this.gameObject, EnemyHPVal, EnemyDefModVal, EnemyAtkModVal);
    }

}
