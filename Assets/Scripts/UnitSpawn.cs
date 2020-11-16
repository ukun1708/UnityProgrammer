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

    // Последовательный спавнер юнитов в случайных местах игровой области

    public void SpawnUnits(GameConfig config)
    {
        StartCoroutine(SpawnUnitsCor(-config.gameAreaHeight, config.gameAreaHeight, -config.gameAreaWidth, config.gameAreaWidth,
                                    config.unitSpawnDelay, config.numUnitsToSpawn, config.unitSpawnMinRadius, config.unitSpawnMaxRadius,
                                    config.unitSpawnMinSpeed, config.unitSpawnMaxSpeed));
    }

    public IEnumerator SpawnUnitsCor(int randXmin, int randXmax, int randZmin, int randZmax, int spawningDelay, int countUnits, float unitMinRad, float unitMaxRad, int minSpeed, int maxSpeed)
    {
        for (int i = 0; i < countUnits; i++)
        {
            GameObject unitGameObj = Instantiate(unitPrefab, Vector3.zero, Quaternion.identity);

            Unit unit = unitGameObj.AddComponent<Unit>();

            unit.speed = Random.Range((float)minSpeed, (float)maxSpeed);

            unit.angle = Random.Range(0f, 360f);

            if (Random.Range(0f, 100f) > 50f)
            {
                unit.color = ColorUniits.Red;
            }
            else
            {
                unit.color = ColorUniits.Blue;
            }

            unit.radius = Random.Range(unitMinRad, unitMaxRad);

            GameController.units.Add(unit);

            unitGameObj.transform.localScale = Vector3.one * 2f * unit.radius;

            if (unit.color == ColorUniits.Red)
            {
                unitGameObj.GetComponent<Renderer>().material = m_red;
                GameController.Singleton.redUnitRadCount += unit.radius;
            }
            else
            {
                unitGameObj.GetComponent<Renderer>().material = m_blue;
                GameController.Singleton.blueUnitRadCount += unit.radius;
            }
            Vector3 pos = Vector3.zero;
            bool key = false;
            while (key == false)
            {
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
            }

            unitGameObj.transform.position = pos;
            yield return new WaitForSeconds(spawningDelay);
        }

        GameController.Singleton.start = true;
    }
}
