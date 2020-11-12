using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SpriteCreator spriteCreator;

    public myCamera cameraScaler;

    public UnitSpawn spawnerUnits;

    void Start()
    {
        GameConfig config = GameConfig.StartSer();
        //Debug.Log(config.gameAreaHeight);

        spriteCreator.CreateSprite(config.gameAreaHeight, config.gameAreaWidth);

        cameraScaler.ScaleCamera(config.gameAreaHeight);

        StartCoroutine(spawnerUnits.SpawnUnits(-config.gameAreaHeight, config.gameAreaHeight, -config.gameAreaWidth, config.gameAreaWidth, config.unitSpawnDelay, config.numUnitsToSpawn, config.unitSpawnMinRadius, config.unitSpawnMaxRadius));
    }

    void Update()
    {

    }
}
