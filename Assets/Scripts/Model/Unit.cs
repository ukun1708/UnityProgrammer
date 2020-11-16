using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorUniits
{
    Red, 
    Blue
}

public class Unit : MonoBehaviour
{
    public float speed;

    public float radius;

    public float angle;

    /// <summary>
    /// Цвет юнита
    /// </summary>
    public ColorUniits color;

    public void UpdateRadius()
    {
        this.transform.localScale = Vector3.one * 2f * radius;
    }
}
