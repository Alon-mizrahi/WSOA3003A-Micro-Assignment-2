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

}
