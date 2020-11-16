using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float second, minut;

    public Text textTimer;

    public Text PopUpTextTimer;

    public int speedTime;

    // Таймер симуляции

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Singleton.start == true)
        {
            speedTime = GameController.Singleton.steps;

            second += Time.deltaTime * speedTime;

            textTimer.text = minut.ToString("F0") + ":" + second.ToString("F0");

            PopUpTextTimer.text = minut.ToString("F0") + " минут " + ": " + second.ToString("F0") + " секунд ";

            if (second > 59)
            {
                minut += 1;
                second = 0;
            }
        } 
    }
}
