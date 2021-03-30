using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class battleSystem : MonoBehaviour
{
    public battleHUD playerHUD;
    public battleHUD enemyHUD;

    public BattleState state;

    public Text enemyNameText;
    public Text DialogText;
    public Transform enemySpawnPt;
    public Transform playerSpawnPt;

    unit playerUnit;
    unit enemyUnit;

    public GameObject enemyprefab;
    public GameObject playerprefab;


    //the balancing data desing numbers
    public float BalanceAtkPHVal = 1f;
    public float BalanceAtkJoyVal = 1f;
    public float BalanceAtkMeaningVal = 1f;

    //the balancing data desing numbers
    public float BalanceDefPHVal = 1f;
    public float BalanceDefJoyVal = 1f;
    public float BalanceDefMeaningVal = 1f;

    public CardSystem cardsystem;
    public Button drawbutton;

    //SETTING UP AND START STATE------------------------------------------------------------
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(setupBattle());
    }

    IEnumerator setupBattle()
    {
        GameObject playerGO = Instantiate(playerprefab, playerSpawnPt);
        playerUnit = playerGO.GetComponent<unit>();

        GameObject enemyGO = Instantiate(enemyprefab, enemySpawnPt);
        enemyUnit = enemyGO.GetComponent<unit>();

        enemyNameText.text = enemyUnit.UnitName;

        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);
        DialogText.text = "lifes hand";

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    private void Update()
    {
        if (state != BattleState.PLAYERTURN) { drawbutton.interactable = false; } else { drawbutton.interactable = true; }
    }

    //ENEMYTURN STATE---------------------------------------------------------------------
    IEnumerator EnemyTurn()
    {
        DialogText.text = "Enemy's turn";
        yield return new WaitForSeconds(1f);
        //do things?
        if (cardsystem.isTrueEnemyCardHolder1 == false || cardsystem.isTrueEnemyCardHolder2==false||cardsystem.isTrueEnemyCardHolder3==false) { cardsystem.OnDrawCard(); }
        else
        {
            int x = Random.Range(1, 4);

            //going to do random number gen and choose of the three cards
            if (x==1)
            {
                cardsystem.EnemyCardHolder1.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
            }
            else if (x==2)
            {
                cardsystem.EnemyCardHolder2.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
            }
            else if(x==3)
            {
                cardsystem.EnemyCardHolder3.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
            }
        }
    }

//PLAYERTURN STATE--------------------------------------------------------------

    public void PlayerTurn() // can play card to attack or heal
    {
        DialogText.text = "Player 1's Turn";
    }

    IEnumerator DrawCard()
    {
        //draw card and add to deck on cardsystem script
        Debug.Log("cross call worked");
        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyTurn());
    }

    public void OnDrawButton() //draw card and end turn
    {
        StartCoroutine(DrawCard());
    }




    public void CardUsed(float PHVal)
    {
        Debug.Log("This is the cards PH Value: " +PHVal);
    }

//Attack and defens play funcitons---------------------------------------------------------------

    public void OnAttackCard(float PHVal, float MeaningVal, float JoyVal, GameObject card)
    {
        //what state we in?
        if (state == BattleState.PLAYERTURN)//player attacking
        {
            StartCoroutine(PlayerAttack(PHVal,MeaningVal,JoyVal));
            Destroy(card);
            return;
        }
        if (state == BattleState.ENEMYTURN)//enemy attacking
        {
            EnemyAttack(PHVal, MeaningVal, JoyVal);
            Destroy(card);
            return;
        }
    }

    public void EnemyCardUsed(float PHVal, float MeaningVal, float JoyVal, GameObject card)
    {
        if(card.GetComponent<CardUnit>().isATKCard == true)
        {
            Destroy(card);
            StartCoroutine(EnemyAttack(PHVal, MeaningVal, JoyVal));
        }
        else
        {
            Destroy(card);
            StartCoroutine(EnemyDefend(PHVal, MeaningVal, JoyVal));
        }
    }

    IEnumerator PlayerAttack(float PHVal, float MeaningVal, float JoyVal)
    {
        //do attack
        enemyUnit.currentJoy -=JoyVal*BalanceAtkJoyVal;
        enemyUnit.currentMeaning -=MeaningVal*BalanceAtkMeaningVal;
        enemyUnit.currentPysicality -= BalanceAtkPHVal*PHVal;

        enemyHUD.JoySlider.value = enemyUnit.currentJoy;
        enemyHUD.MeaningSlider.value = enemyUnit.currentMeaning;
        enemyHUD.PhysicalitySlider.value = enemyUnit.currentPysicality;

        //check if dead
        if (enemyUnit.isDead() == true)
        {
            state = BattleState.WON;
            StartCoroutine(WonFunction());
        }else
        {
            state = BattleState.ENEMYTURN;
            yield return new WaitForSeconds(2f);
            StartCoroutine(EnemyTurn());

        }
    }

    IEnumerator EnemyAttack(float PHVal, float MeaningVal, float JoyVal)
    {
        //do attack
        playerUnit.currentJoy -= JoyVal*BalanceAtkJoyVal;
        playerUnit.currentMeaning -= MeaningVal*BalanceAtkMeaningVal;
        playerUnit.currentPysicality -= PHVal*BalanceAtkPHVal;

        playerHUD.JoySlider.value = playerUnit.currentJoy;
        playerHUD.MeaningSlider.value = playerUnit.currentMeaning;
        playerHUD.PhysicalitySlider.value = playerUnit.currentPysicality;

        //check if dead
        if (playerUnit.isDead() == true)
        {
            state = BattleState.LOST;
            StartCoroutine(LostFunction());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            yield return new WaitForSeconds(2f);
            PlayerTurn();

        }
    }




    public void OnDefenseCard(float PHVal, float MeaningVal, float JoyVal, GameObject card)
    {
        //what state we in?
        if (state == BattleState.PLAYERTURN)//player defending
        {
            StartCoroutine(PlayerDefend(PHVal, MeaningVal, JoyVal));
            Destroy(card);
            return;
        }
        if (state == BattleState.ENEMYTURN)//enemy defending
        {
            StartCoroutine(EnemyDefend(PHVal, MeaningVal, JoyVal));
            Destroy(card);
            return;
        }
    }

    IEnumerator PlayerDefend(float PHVal, float MeaningVal, float JoyVal)
    {
        playerUnit.currentJoy+=JoyVal*BalanceDefJoyVal;
        playerUnit.currentMeaning+=MeaningVal*BalanceDefMeaningVal;
        playerUnit.currentPysicality+=PHVal*BalanceDefPHVal;

        if (playerUnit.currentJoy > playerUnit.maxJoy) { playerUnit.currentJoy = playerUnit.maxJoy; }
        if (playerUnit.currentMeaning > playerUnit.maxMeaning) { playerUnit.currentMeaning = playerUnit.maxMeaning; }
        if (playerUnit.currentPysicality > playerUnit.maxPysicality) { playerUnit.currentPysicality = playerUnit.maxPysicality; }

        state = BattleState.ENEMYTURN;
        DialogText.text = "Enemy's Turn";

        playerHUD.JoySlider.value = playerUnit.currentJoy;
        playerHUD.PhysicalitySlider.value = playerUnit.currentPysicality;
        playerHUD.MeaningSlider.value = playerUnit.currentMeaning;

        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyDefend(float PHVal, float MeaningVal, float JoyVal)
    {
        enemyUnit.currentJoy += JoyVal * BalanceDefJoyVal;
        enemyUnit.currentMeaning += MeaningVal * BalanceDefMeaningVal;
        enemyUnit.currentPysicality += PHVal * BalanceDefPHVal;

        if (enemyUnit.currentJoy > enemyUnit.maxJoy) { enemyUnit.currentJoy = enemyUnit.maxJoy; }
        if (enemyUnit.currentMeaning > enemyUnit.maxMeaning) { enemyUnit.currentMeaning = enemyUnit.maxMeaning; }
        if (enemyUnit.currentPysicality > enemyUnit.maxPysicality) { enemyUnit.currentPysicality = enemyUnit.maxPysicality; }

        state = BattleState.PLAYERTURN;

        enemyHUD.JoySlider.value = enemyUnit.currentJoy;
        enemyHUD.PhysicalitySlider.value = enemyUnit.currentPysicality;
        enemyHUD.MeaningSlider.value = enemyUnit.currentMeaning;
        
        yield return new WaitForSeconds(1f);
        PlayerTurn();
    }



    //-------------------------------------------------------------------------------------------------------------------------


    //WON STATE---------------------------------------------------------------------------
    IEnumerator WonFunction()
    {
        DialogText.text = "You Won! resetting in 5 seconds";
        yield return new WaitForSeconds(5f);
        //reset scene
        Application.LoadLevel(Application.loadedLevel);
    }


//LOST STATE------------------------------------------------------------------------
    IEnumerator LostFunction()
    {
        DialogText.text = "You Lost! resetting in 5 seconds";
        yield return new WaitForSeconds(5f);
        //reset scene
        Application.LoadLevel(Application.loadedLevel);
    }

}
