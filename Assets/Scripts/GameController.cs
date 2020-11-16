using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SpriteCreator spriteCreator; // Создание области симуляции битвы

    public DinamicCamera cameraScaler; // Динамическая позиционирование камеры

    public UnitSpawn spawnerUnits; // Последовательный спавнер юнитов в случайных местах игровой области

    public MovementUnits movementUnits; // движение юнитов, отскакивание юнитов, уничтожение юнитов 

    public static List<Unit> units;

    GameConfig config;

    public float redUnitRadCount = 0; // общее количество радиуса красных юнитов

    public float blueUnitRadCount = 0; // общее количество радиуса синих юнитов

    public bool start = false;
    public int steps = 1;       // Скорость симуляции  

    public static GameController Singleton;

    void Start()
    {
        Singleton = this;
        config = GameConfig.StartSer();

        spriteCreator.CreateSprite(config.gameAreaHeight, config.gameAreaWidth);

        cameraScaler.ScaleCamera(config.gameAreaWidth);

        spawnerUnits.SpawnUnits(config);
    }

    void Update()
    {
        if (start == true)
        {
            for (int i = 0; i < steps; i++)
            {
                movementUnits.Moveit(config.numUnitsToSpawn);
            }
        }
    }
}
