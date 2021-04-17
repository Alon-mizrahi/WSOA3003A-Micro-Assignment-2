using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blink : MonoBehaviour
{
    public Button drawbttn;
    Color btnimg;
    public CardSystem cardsystem;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while(cardsystem.isStarted==false)
        {
            drawbttn.GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(1f);
            drawbttn.GetComponent<Image>().color = Color.yellow;
            yield return new WaitForSeconds(1f);
        }
        drawbttn.GetComponent<Image>().color = Color.white;
    }



}
