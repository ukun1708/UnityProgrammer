using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject unitPrefab;

    public Material m_red;

    public Material m_blue;

    void Start()
    {
        GameController.units = new List<Unit>();
    }

    /// <summary>
    /// Последовательный спавнер юнитов в случайных местах игровой области
    /// </summary>

    public void SpawnUnits(GameConfig config)
    {
        StartCoroutine(SpawnUnitsCor(-config.gameAreaHeight, config.gameAreaHeight, -config.gameAreaWidth, config.gameAreaWidth,
                                    config.unitSpawnDelay, config.numUnitsToSpawn, config.unitSpawnMinRadius, config.unitSpawnMaxRadius,
                                    config.unitSpawnMinSpeed, config.unitSpawnMaxSpeed));
    }

    public IEnumerator SpawnUnitsCor(int randXmin, int randXmax, int randZmin, int randZmax, int spawningDelay, int countUnits, float unitMinRad, float unitMaxRad, int minSpeed, int maxSpeed)
    {
        for (int i = 0; i < countUnits; i++) // количество создаваемых юнитов
        {
            GameObject unitGameObj = Instantiate(unitPrefab, Vector3.zero, Quaternion.identity); // создание экземпляра объекта из префаба

            Unit unit = unitGameObj.AddComponent<Unit>(); // инициализация модели юнита и добавление его в компоненты uintGameObj

            unit.speed = Random.Range((float)minSpeed, (float)maxSpeed); // добавляем в модель случайную скорость 

            unit.angle = Random.Range(0f, 360f);  // добавляем в модель случайное направление движения

            if (Random.Range(0f, 100f) > 50f) // с вероятностью 50% 
            {
                unit.color = ColorUniits.Red; // добавление в модель цвет юнита красный
            }
            else
            {
                unit.color = ColorUniits.Blue; // добавление в модель цвет юнита синий
            }

            unit.radius = Random.Range(unitMinRad, unitMaxRad); // добавление в модель случайное значение радиуса

            GameController.units.Add(unit); // добавляем модель в коллекцию

            unitGameObj.transform.localScale = Vector3.one * 2f * unit.radius; // в экземпляр объекта префаба задаем радиус

            if (unit.color == ColorUniits.Red) // если цвет юнита равен Red
            {
                unitGameObj.GetComponent<Renderer>().material = m_red; // цвет экземпляра становится красным
                GameController.Singleton.redUnitRadCount += unit.radius; // добаляем радиус экземпляра в радиус всех красных объектов
            }
            else // иначе
            {
                unitGameObj.GetComponent<Renderer>().material = m_blue; // цвет экземпляра становится синим
                GameController.Singleton.blueUnitRadCount += unit.radius; // добавляем радиус экземпляра в радиус всех синих объектов
            }

            Vector3 pos = Vector3.zero; // 
            bool key = false; 
            int iterCount = 0; // Проверка на бесконечный цикл

            while (key == false)
            {
                iterCount++;

                pos = new Vector3(Random.Range((float)randXmin, (float)randXmax), 0.5f, Random.Range((float)randZmin, (float)randZmax));

                for (int j = 0; j < GameController.units.Count; j++)
                {
                    float dist = Vector3.Distance(pos, GameController.units[j].transform.position) - unit.radius - GameController.units[j].radius;

                    if (dist > 0)
                    {
                        key = true;
                    }
                    else
                    {
                        key = false;
                        break;
                    }
                }

                if (iterCount > 1000)
                {
                    break;
                }
            }

            if (key == false)
            {
                Debug.LogError("Не найдено свободного места для юнита");
                GameController.units.Remove(unit);
                Destroy(unit.gameObject);

                break;
            }

            unitGameObj.transform.position = pos;
            yield return new WaitForSeconds(spawningDelay);
        }

        GameController.Singleton.start = true;
    }
}
