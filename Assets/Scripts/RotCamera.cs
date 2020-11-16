using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCamera : MonoBehaviour
{
    public float speed = 5f;

    private float oldPos;

    public float speedRot = 5f;

    private Quaternion targetRot;

    void Start()
    {
        targetRot = transform.rotation;
    }

    
    /// <summary>
    /// Вращение камеры вокруг центар области битвы
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPos = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float currentPos = Input.mousePosition.x;

            targetRot *= Quaternion.Euler(Vector3.up * -speed * (oldPos - currentPos) * Time.deltaTime);

            oldPos = Input.mousePosition.x;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot,  Time.deltaTime * speedRot);

        

    }
}
