using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// Перезагрузка сцены
    /// </summary>
    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

}
