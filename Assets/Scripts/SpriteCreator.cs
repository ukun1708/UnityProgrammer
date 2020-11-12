using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCreator : MonoBehaviour
{

    public GameObject mySprite;

    public GameObject spr;

    public Vector3 spritePos;

    private void Start()
    {
        
    }

    public void CreateSprite(int height, int widght)
    {
        spritePos = new Vector3(0f, 0f, 0f);

        spr = Instantiate(mySprite, spritePos, Quaternion.Euler(Vector3.left * 90f));

        spr.transform.localScale = new Vector3(height, widght, 0f);
    }
}
