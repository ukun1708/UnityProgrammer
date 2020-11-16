using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUnits : MonoBehaviour
{
    void Start()
    {

    }

    public void Moveit(int countUnits)  // отскакивание юнитов при соударении о границы игровой зоны
    {
        Reflector();
        RemoveItems();

        foreach (Unit unit in GameController.units)
        {
            if (unit.transform.position.x > 100 || unit.transform.position.x < -100)
            {
                unit.angle += 180f;
            }

            if (unit.transform.position.z > 100 || unit.transform.position.z < -100)
            {
                unit.angle += 180f;
            }

            unit.transform.position += new Vector3(Mathf.Cos(unit.angle) * unit.speed * 0.01f, 0f, Mathf.Sin(unit.angle) * unit.speed * 0.01f);
        }
    }

    public void Reflector()
    {

        for (int i = 0; i < GameController.units.Count; i++)
        {
            for (int j = 0; j < GameController.units.Count; j++)
            {
                if (i != j)
                {
                    if (GameController.units[i].color == GameController.units[j].color) // Если цвет юнитов при соударении одинаковая, то отскакивают друг от друга 
                    {
                        float delta = Vector3.Distance(GameController.units[i].transform.position, GameController.units[j].transform.position) - GameController.units[i].radius - GameController.units[j].radius;

                        if (delta <= 0)
                        {
                            GameController.units[i].angle += 180f;
                        }
                    }
                    else // Если цвет юнитов при соударении разная, тогда они не отскакивают друг от друга. Вмсето этого их радиусы уменьшаются до такой величины, чтобы предотвратить соударение.
                    {
                        float delta = Vector3.Distance(GameController.units[i].transform.position, GameController.units[j].transform.position) - GameController.units[i].radius - GameController.units[j].radius;

                        if (delta < 0)
                        {
                            GameController.units[i].radius += delta / 2f;
                            GameController.units[i].UpdateRadius();

                            GameController.units[j].radius += delta / 2f;
                            GameController.units[j].UpdateRadius();

                            GameController.Singleton.redUnitRadCount += delta / 2f;
                            GameController.Singleton.blueUnitRadCount += delta / 2f;

                        }
                    }
                }
            }
        }
    }

    private void RemoveItems() // Если радиус юнита станет меньше "unitDestroyRadius", юнит уничтожается
    {
        foreach (Unit unit in GameController.units)
        {
            if (unit.radius <= GameConfig.Singleton.unitSpawnMinRadius)
            {
                if (unit.color == ColorUniits.Red)
                {
                    GameController.Singleton.redUnitRadCount -= unit.radius;
                }
                else
                {
                    GameController.Singleton.blueUnitRadCount -= unit.radius;
                }

                GameController.units.Remove(unit);
                Destroy(unit.gameObject);
                break;
            }
        }
    }
}
