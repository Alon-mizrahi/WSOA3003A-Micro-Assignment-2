using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleHUD : MonoBehaviour
{
    public Text nameText;

    public Slider HPSlider;
    public Slider AtkModSlider;
    public Slider DefModSlider;

    CardSystem cardsystem;

    private void Start()
    {
        cardsystem = GameObject.Find("CardSystem").GetComponent<CardSystem>();
    }

    public void setHUD(unit unit)
    {
        nameText.text = unit.UnitName;

        HPSlider.maxValue = unit.maxHP;
        HPSlider.value = unit.currentHP;

        AtkModSlider.maxValue = unit.maxAtkMod;
        AtkModSlider.value = unit.currentAtkMod;

        DefModSlider.maxValue = unit.maxDefMod;
        DefModSlider.value = unit.currentDefMod;
    }

    private void OnMouseOver()
    {
        cardsystem.CardDescription.text = "Atk Mod increases how much damage your cards do. Def Mod reduces how  much damage you take";
        cardsystem.CardDescription.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        cardsystem.CardDescription.gameObject.SetActive(false);
    }

}
