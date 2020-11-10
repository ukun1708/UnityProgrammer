using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         GameConfig config = GameConfig.StartSer();
        Debug.Log(config.gameAreaHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
