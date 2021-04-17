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
    public GameObject PlayerCardHolder4;
    public GameObject PlayerCardHolder5;

    private bool isTruePlayerCardHolder1 = false;
    private bool isTruePlayerCardHolder2 = false;
    private bool isTruePlayerCardHolder3 = false;
    private bool isTruePlayerCardHolder4 = false;
    private bool isTruePlayerCardHolder5 = false;

    public GameObject EnemyCardHolder1;
    public GameObject EnemyCardHolder2;
    public GameObject EnemyCardHolder3;
    public GameObject EnemyCardHolder4;
    public GameObject EnemyCardHolder5;

    public bool isTrueEnemyCardHolder1 = false;
    public bool isTrueEnemyCardHolder2 = false;
    public bool isTrueEnemyCardHolder3 = false;
    public bool isTrueEnemyCardHolder4 = false;
    public bool isTrueEnemyCardHolder5 = false;


    public GameObject EnemyCardBack1;
    public GameObject EnemyCardBack2;
    public GameObject EnemyCardBack3;
    public GameObject EnemyCardBack4;
    public GameObject EnemyCardBack5;

    public Text CardDescription;

    public bool isStarted = false;

    //access to states
    public GameObject battleSystem;
    battleSystem battlescript;
    private GameObject TempGO;

    void Start()
    {
        EnemyCardBack1.SetActive(false);
        EnemyCardBack2.SetActive(false);
        EnemyCardBack3.SetActive(false);
        EnemyCardBack4.SetActive(false);
        EnemyCardBack5.SetActive(false);

        battlescript = battleSystem.GetComponent<battleSystem>();
        Shuffle(); 
        //Debug.Log(battlescript.state);
    }

    private void Update()
    {
        if (PlayerCardHolder1.transform.childCount > 0) { isTruePlayerCardHolder1 = true; } else { isTruePlayerCardHolder1 = false; }
        if (PlayerCardHolder2.transform.childCount > 0) { isTruePlayerCardHolder2 = true; } else { isTruePlayerCardHolder2 = false; }
        if (PlayerCardHolder3.transform.childCount > 0) { isTruePlayerCardHolder3 = true; } else { isTruePlayerCardHolder3 = false; }
        if (PlayerCardHolder4.transform.childCount > 0) { isTruePlayerCardHolder4 = true; } else { isTruePlayerCardHolder4 = false; }
        if (PlayerCardHolder5.transform.childCount > 0) { isTruePlayerCardHolder5 = true; } else { isTruePlayerCardHolder5 = false; }

        if (EnemyCardHolder1.transform.childCount > 0) { isTrueEnemyCardHolder1 = true; } else { isTrueEnemyCardHolder1 = false; }
        if (EnemyCardHolder2.transform.childCount > 0) { isTrueEnemyCardHolder2 = true; } else { isTrueEnemyCardHolder2 = false; }
        if (EnemyCardHolder3.transform.childCount > 0) { isTrueEnemyCardHolder3 = true; } else { isTrueEnemyCardHolder3 = false; }
        if (EnemyCardHolder4.transform.childCount > 0) { isTrueEnemyCardHolder4 = true; } else { isTrueEnemyCardHolder4 = false; }
        if (EnemyCardHolder5.transform.childCount > 0) { isTrueEnemyCardHolder5 = true; } else { isTrueEnemyCardHolder5 = false; }
    }


    public void OnDrawCard() //called by button
    {
        isStarted = true;
        if (battlescript.state == BattleState.PLAYERTURN) {
            //check player doesnt have Full Hand
            if (isTruePlayerCardHolder1 == false)
            {
                deck[deckIterator].transform.parent = PlayerCardHolder1.transform;
                deck[deckIterator].transform.position = PlayerCardHolder1.transform.position;
                deckIterator++;
                isTruePlayerCardHolder1 = true;
                battlescript.OnDrawButton();
                return;
            }
            else if (isTruePlayerCardHolder2 == false)
            {
                deck[deckIterator].transform.parent = PlayerCardHolder2.transform;
                deck[deckIterator].transform.position = PlayerCardHolder2.transform.position;
                deckIterator++;
                isTruePlayerCardHolder2 = true;
                battlescript.OnDrawButton();
                return;
            }
            else if (isTruePlayerCardHolder3 == false)
            {
                deck[deckIterator].transform.parent = PlayerCardHolder3.transform;
                deck[deckIterator].transform.position = PlayerCardHolder3.transform.position;
                deckIterator++;
                isTruePlayerCardHolder3 = true;
                battlescript.OnDrawButton();
                return;
            }
            else if (isTruePlayerCardHolder4 == false)
            {
                deck[deckIterator].transform.parent = PlayerCardHolder4.transform;
                deck[deckIterator].transform.position = PlayerCardHolder4.transform.position;
                deckIterator++;
                isTruePlayerCardHolder4 = true;
                battlescript.OnDrawButton();
                return;
            }
            else if (isTruePlayerCardHolder5 == false)
            {
                deck[deckIterator].transform.parent = PlayerCardHolder5.transform;
                deck[deckIterator].transform.position = PlayerCardHolder5.transform.position;
                deckIterator++;
                isTruePlayerCardHolder5 = true;
                battlescript.OnDrawButton();
                return;
            }
        }

        //enemy draw
        if (battlescript.state == BattleState.ENEMYTURN)
        {
            //check player doesnt have full hand
            if (isTrueEnemyCardHolder1 == false)
            {
                deck[deckIterator].transform.parent = EnemyCardHolder1.transform;
                deck[deckIterator].transform.position = EnemyCardHolder1.transform.position;
                EnemyCardBack1.SetActive(true);
                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                EnemyCardHolder1.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
                deckIterator++;
                isTrueEnemyCardHolder1 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
            else if (isTrueEnemyCardHolder2 == false)
            {
                deck[deckIterator].transform.parent = EnemyCardHolder2.transform;
                deck[deckIterator].transform.position = EnemyCardHolder2.transform.position;
                EnemyCardBack2.SetActive(true);
                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                EnemyCardHolder2.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
                deckIterator++;
                isTrueEnemyCardHolder2 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
            else if (isTrueEnemyCardHolder3 == false)
            {
                deck[deckIterator].transform.parent = EnemyCardHolder3.transform;
                deck[deckIterator].transform.position = EnemyCardHolder3.transform.position;
                EnemyCardBack3.SetActive(true);
                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                EnemyCardHolder3.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
                deckIterator++;
                isTrueEnemyCardHolder3 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
            else if (isTrueEnemyCardHolder4 == false)
            {
                deck[deckIterator].transform.parent = EnemyCardHolder4.transform;
                deck[deckIterator].transform.position = EnemyCardHolder4.transform.position;
                EnemyCardBack4.SetActive(true);
                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                EnemyCardHolder4.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
                deckIterator++;
                isTrueEnemyCardHolder4 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
            else if (isTrueEnemyCardHolder5 == false)
            {
                deck[deckIterator].transform.parent = EnemyCardHolder5.transform;
                deck[deckIterator].transform.position = EnemyCardHolder5.transform.position;
                EnemyCardBack5.SetActive(true);
                deck[deckIterator].transform.GetChild(0).GetComponentInChildren<Button>().interactable = false;
                EnemyCardHolder5.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
                deckIterator++;
                isTrueEnemyCardHolder5 = true;
                battlescript.state = BattleState.PLAYERTURN;
                battlescript.PlayerTurn();
                return;
            }
        }
    }

    //card randomiser at start(shuffle deck)
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
}
