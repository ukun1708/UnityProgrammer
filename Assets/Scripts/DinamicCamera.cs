using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicCamera : MonoBehaviour
{

    public float camOffset = 50f;
    public float camAngleOffset = 10f;

    void Start()
    {
        
    }

    /// <summary>
    /// Динамическая позиционирование камеры
    /// </summary>
    public void ScaleCamera()
    {
        float a = GameConfig.Singleton.gameAreaHeight * 0.5f;

        float aW = GameConfig.Singleton.gameAreaWidth * 0.5f;

        float alpha = Camera.main.fieldOfView * 0.5f + camAngleOffset;

        float aspect = Camera.main.aspect;

        float b = a / aspect / Mathf.Tan(Mathf.Deg2Rad * alpha) + camOffset;

        float bW = aW / aspect / Mathf.Tan(Mathf.Deg2Rad * alpha) + camOffset;

        if (b > bW)
        {            
            transform.localPosition = new Vector3(0f, Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.x) * bW, Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.x) * -bW);
        }
        else
        {
            transform.localPosition = new Vector3(0f, Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.x) * b, Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.x) * -b);
        }
    }
}
