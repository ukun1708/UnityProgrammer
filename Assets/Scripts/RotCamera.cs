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

    // Вращение камеры

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            float currentPos = Input.mousePosition.x;

            targetRot *= Quaternion.Euler(Vector3.up * -speed * (oldPos - currentPos) * Time.deltaTime); 
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot,  Time.deltaTime * speedRot);

        oldPos = Input.mousePosition.x;
    }
}
