using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    CardSystem cardsystem;
    string sceneName;
    public unit enemyUnit;
    public battleSystem battleScript;

    string CardType;

    private void Start()
    {
        cardsystem = GameObject.FindWithTag("CardSystem").GetComponent<CardSystem>();
        battleScript = GameObject.Find("BattleSystem").GetComponent<battleSystem>();
        //GameObject EnemyGO = GameObject.Find("Enemy");
        //enemyUnit = EnemyGO.GetComponent<unit>();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

//function called from battlestate
    public void EnemyLevelCheck()
    {
//AI LEVEL 1 DUMB - PICK UP UNTIL FULL HAND THEN PLAY RANDOM CARD-------------------------------------------------------------------------------
        if (sceneName == "1_level")
        {
            if (cardsystem.isTrueEnemyCardHolder1 == false || cardsystem.isTrueEnemyCardHolder2 == false || cardsystem.isTrueEnemyCardHolder3 == false || cardsystem.isTrueEnemyCardHolder4 == false || cardsystem.isTrueEnemyCardHolder5 == false) { cardsystem.OnDrawCard(); }
            else
            {
                int x = Random.Range(1, 6);

                //going to do random number gen and choose of the three cards
                if (x == 1)
                {
                    cardsystem.EnemyCardBack1.SetActive(false);
                    cardsystem.EnemyCardHolder1.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                }
                else if (x == 2)
                {
                    cardsystem.EnemyCardBack2.SetActive(false);
                    cardsystem.EnemyCardHolder2.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                }
                else if (x == 3)
                {
                    cardsystem.EnemyCardBack3.SetActive(false);
                    cardsystem.EnemyCardHolder3.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                }
                else if (x == 4)
                {
                    cardsystem.EnemyCardBack4.SetActive(false);
                    cardsystem.EnemyCardHolder4.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                }
                else if (x == 5)
                {
                    cardsystem.EnemyCardBack5.SetActive(false);
                    cardsystem.EnemyCardHolder5.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                }
            }
        }

//AI LEVEL 2 DEFENSIVE - PICK UP UNTIL FULL THEN PLAY HEALING CARDS UNLESS HEALTH == MAX HEALTH---------------------------------------------------------
        if (sceneName == "2_level")
        {
            if (cardsystem.isTrueEnemyCardHolder1 == false || cardsystem.isTrueEnemyCardHolder2 == false || cardsystem.isTrueEnemyCardHolder3 == false || cardsystem.isTrueEnemyCardHolder4 == false || cardsystem.isTrueEnemyCardHolder5 == false) { cardsystem.OnDrawCard(); }
            else
            {
                //hand is full. now sort through and choose from priorety list

                //enemy HP != max-> play healer else-> play atk
                    for(int i=0; i< 4; i++)
                    {
                        //set order and cardType to look for
                        if(i==0){ CardType = "Healer"; }
                        else if(i==1){ CardType = "Caster"; }
                        else if(i==2){ CardType = "Soldier"; }
                        else if(i==3){ CardType = "Brawler"; }

                        //Loop though cardplaces and look for the desired card type in order
                        if (cardsystem.EnemyCardHolder1.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                        {
                            cardsystem.EnemyCardBack1.SetActive(false);
                            cardsystem.EnemyCardHolder1.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                            break;
                        }
                        else if (cardsystem.EnemyCardHolder2.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                        {
                            cardsystem.EnemyCardBack2.SetActive(false);
                            cardsystem.EnemyCardHolder2.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                            break;
                        }
                        else if (cardsystem.EnemyCardHolder3.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                        {
                            cardsystem.EnemyCardBack3.SetActive(false);
                            cardsystem.EnemyCardHolder3.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                            break;
                        }
                        else if (cardsystem.EnemyCardHolder4.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                        {
                            cardsystem.EnemyCardBack4.SetActive(false);
                            cardsystem.EnemyCardHolder4.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                            break;
                        }
                        else if (cardsystem.EnemyCardHolder5.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                        {
                            cardsystem.EnemyCardBack5.SetActive(false);
                            cardsystem.EnemyCardHolder5.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                            break;
                        }

                    }
            }
        }

        //AI LEVEL 3 AGGRESIVE - PICK UP THREE PLAY BRAWLER FIRST THEN SODIER.
        if (sceneName == "3_level")
        {
            if (cardsystem.isTrueEnemyCardHolder1 == false || cardsystem.isTrueEnemyCardHolder2 == false || cardsystem.isTrueEnemyCardHolder3 == false) { cardsystem.OnDrawCard(); }
            else
            {
                //hand is full. now sort through and choose from priorety list

                //enemy HP != max-> play healer else-> play atk
                for (int i = 0; i < 4; i++)
                {
                    //set order and cardType to look for
                    if (i == 0) { CardType = "Brawler"; } 
                    else if (i == 1) { CardType = "Soldier"; }
                    else if (i == 2) { CardType = "Caster"; }
                    else if (i == 3) { CardType = "Healer"; }

                    //Loop though cardplaces and look for the desired card type in order
                    if (cardsystem.EnemyCardHolder1.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                    {
                        cardsystem.EnemyCardBack1.SetActive(false);
                        cardsystem.EnemyCardHolder1.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                        break;
                    }
                    else if (cardsystem.EnemyCardHolder2.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                    {
                        cardsystem.EnemyCardBack2.SetActive(false);
                        cardsystem.EnemyCardHolder2.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                        break;
                    }
                    else if (cardsystem.EnemyCardHolder3.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                    {
                        cardsystem.EnemyCardBack3.SetActive(false);
                        cardsystem.EnemyCardHolder3.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                        break;
                    }
                    /*else if (cardsystem.EnemyCardHolder4.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                    {
                        cardsystem.EnemyCardBack4.SetActive(false);
                        cardsystem.EnemyCardHolder4.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                        break;
                    }
                    else if (cardsystem.EnemyCardHolder5.transform.GetChild(0).GetComponent<CardUnit>().CardName == CardType)
                    {
                        cardsystem.EnemyCardBack5.SetActive(false);
                        cardsystem.EnemyCardHolder5.transform.GetChild(0).GetComponent<CardUnit>().EnemyCardUsed();
                        break;
                    }*/

                }
            }
        }
    }

}
