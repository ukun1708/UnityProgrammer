using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{

    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        var pros = GameController.Singleton.redUnitRadCount / (GameController.Singleton.redUnitRadCount + GameController.Singleton.blueUnitRadCount); // процентное соотношение радиусов юнитов
        
        slider.value = Mathf.Lerp(slider.value, pros, Time.deltaTime);
    }
}
