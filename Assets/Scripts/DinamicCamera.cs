using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicCamera : MonoBehaviour
{
    void Start()
    {
        
    }

    /// <summary>
    /// Динамическая позиционирование камеры
    /// </summary>
    public void ScaleCamera(int height)
    {
        float scaleModificator = 1.5f;

        transform.position = new Vector3(0f, height * scaleModificator, -height * scaleModificator);
    }
}
