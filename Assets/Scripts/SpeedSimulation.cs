using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSimulation : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {

    }
    /// <summary>
    /// Установление скорости симуляции
    /// </summary>
    public void SliderOnValueChanged()
    {
        GameController.Singleton.steps = (int)slider.value;
    }
}
