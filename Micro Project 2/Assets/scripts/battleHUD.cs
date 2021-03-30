using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleHUD : MonoBehaviour
{
    public Text nameText;

    public Slider PhysicalitySlider;
    public Slider JoySlider;
    public Slider MeaningSlider;

    public void setHUD(unit unit)
    {
        nameText.text = unit.UnitName;

        PhysicalitySlider.maxValue = unit.maxPysicality;
        PhysicalitySlider.value = unit.currentPysicality;

        JoySlider.maxValue = unit.maxJoy;
        JoySlider.value = unit.currentJoy;

        MeaningSlider.maxValue = unit.maxMeaning;
        MeaningSlider.value = unit.currentMeaning;
    }

}
