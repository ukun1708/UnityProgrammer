using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinUnits : MonoBehaviour
{
    public Text winTxt;

    public GameObject popUpgb;

    public GameObject backgroundPop;
    
    void Start()
    {
        popUpgb.SetActive(false);
        backgroundPop.SetActive(false);
    }
    
    void Update()
    {
        if (GameController.Singleton.start == true)
        {
            if (GameController.Singleton.redUnitRadCount < 1)
            {
                backgroundPop.SetActive(true);

                popUpgb.SetActive(true);

                winTxt.text = "СИНИЕ ЮНИТЫ";

                GameController.Singleton.steps = 0;                
            }

            if (GameController.Singleton.blueUnitRadCount < 1)
            {
                backgroundPop.SetActive(true);

                popUpgb.SetActive(true);

                winTxt.text = "КРАСНЫЕ ЮНИТЫ";

                GameController.Singleton.steps = 0;                
            }
        }
    }
}
