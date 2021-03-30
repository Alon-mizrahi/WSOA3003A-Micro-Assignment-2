using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSystem : MonoBehaviour
{
    public GameObject[] deck;
    private int deckIterator=0;

    public GameObject PlayerCardHolder1;
    public GameObject PlayerCardHolder2;
    public GameObject PlayerCardHolder3;

    private bool isTruePlayerCardHolder1 = false;
    private bool isTruePlayerCardHolder2 = false;
    private bool isTruePlayerCardHolder3 = false;

    public GameObject EnemyCardHolder1;
    public GameObject EnemyCardHolder2;
    public GameObject EnemyCardHolder3;

    public bool isTrueEnemyCardHolder1 = false;
    public bool isTrueEnemyCardHolder2 = false;
    public bool isTrueEnemyCardHolder3 = false;


    //access to states
    public GameObject battleSystem;
    battleSystem battlescript;
    private GameObject TempGO;

    void Start()
    {
        battlescript = battleSystem.GetComponent<battleSystem>();
        Shuffle(); 
        //Debug.Log(battlescript.state);
    }

    private void Update()
    {
        if (PlayerCardHolder1.transform.childCount > 0) { isTruePlayerCardHolder1 = true; } else { isTruePlayerCardHolder1 = false; }
        if (PlayerCardHolder2.transform.childCount > 0) { isTruePlayerCardHolder2 = true; } else { isTruePlayerCardHolder2 = false; }
        if (PlayerCardHolder3.transform.childCount > 0) { isTruePlayerCardHolder3 = true; } else { isTruePlayerCardHolder3 = false; }

        if (EnemyCardHolder1.transform.childCount > 0) { isTrueEnemyCardHolder1 = true; } else { isTrueEnemyCardHolder1 = false; }
        if (EnemyCardHolder2.transform.childCount > 0) { isTrueEnemyCardHolder2 = true; } else { isTrueEnemyCardHolder2 = false; }
        if (EnemyCardHolder3.transform.childCount > 0) { isTrueEnemyCardHolder3 = true; } else { isTrueEnemyCardHolder3 = false; }
    }


    public void OnDrawCard() //called by button
    {
        if (battlescript.state == BattleState.PLAYERTURN) {
            //check player doesnt have 3 cards already
            if (isTruePlayerCardHolder1 == false)
            {
                //deck[deckIterator].transform.position = PlayerCardHolder1.transform.position;
                deck[deckIterator].transform.parent = PlayerCardHolder1.transform;
                deck[deckIterator].transform.position = PlayerCardHolder1.transform.position;  //new Vector3(0f, 0f, 100f);
                deckIterator++;
                isTruePlayerCardHolder1 = true;
                battlescript.OnDrawButton();
                return;
            }
            else if (isTruePlayerCardHolder2 == false)
            {
                //deck[deckIterator].transform.position = PlayerCardHolder2.transform.position;
                deck[deckIterator].transform.parent = PlayerCardHolder2.transform;
                deck[deckIterator].transform.position = PlayerCardHolder2.transform.position;
                deckIterator++;
                isTruePlayerCardHolder2 = true;
                battlescript.OnDrawButton();
                return;
            }
            else if (isTruePlayerCardHolder3 == false)
            {
                //deck[deckIterator].transform.position = PlayerCardHolder3.transform.position;
                deck[deckIterator].transform.parent = PlayerCardHolder3.transform;
                deck[deckIterator].transform.position = PlayerCardHolder3.transform.position;
                deckIterator++;
                isTruePlayerCardHolder3 = true;
                battlescript.OnDrawButton();
                return;
            }
        }

        //enemy draw
        if (battlescript.state == BattleState.ENEMYTURN)
        {
            //check player doesnt have 3 cards already
            if (isTrueEnemyCardHolder1 == false)
            {
                //deck[deckIterator].transform.position = EnemyCardHolder1.transform.position;
                deck[deckIterator].transform.parent = EnemyCardHolder1.transform;
                deck[deckIterator].transform.position = EnemyCardHolder1.transform.position;

                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                deckIterator++;
                isTrueEnemyCardHolder1 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
            else if (isTrueEnemyCardHolder2 == false)
            {
                //deck[deckIterator].transform.position = EnemyCardHolder2.transform.position;
                deck[deckIterator].transform.parent = EnemyCardHolder2.transform;
                deck[deckIterator].transform.position = EnemyCardHolder2.transform.position;

                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                deckIterator++;
                isTrueEnemyCardHolder2 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
            else if (isTrueEnemyCardHolder3 == false)
            {
                //deck[deckIterator].transform.position = EnemyCardHolder3.transform.position;
                deck[deckIterator].transform.parent = EnemyCardHolder3.transform;
                deck[deckIterator].transform.position = EnemyCardHolder3.transform.position;

                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                deckIterator++;
                isTrueEnemyCardHolder3 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
        }
        //Debug.Log("button push cardsystem says high");
    }


    void Shuffle()
    {
        for (int i = 0; i < deck.Length - 1; i++)
        {
            int rnd = Random.Range(i, deck.Length);
            TempGO = deck[rnd];
            deck[rnd] = deck[i];
            deck[i] = TempGO;
        }

    }

    //card attacks and heals
 
    //card clicked
    //call function based on atk or def
    //look at state to see who played
    // affect changes via another function called from battle system script/ or this script since here balancing numbers

    //using card make sure to use data value balancing numbers



}
