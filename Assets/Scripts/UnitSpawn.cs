using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject unitRed;

    public GameObject unitBlue;

    public List<GameObject> Units;
    
    void Start()
    {
        Units = new List<GameObject>();
    }

    public IEnumerator SpawnUnits(int randXmin, int randXmax, int randZmin, int randZmax, int spawningDelay, int countUnits, float unitMinRad, float unitMaxRad)
    {
        for (int i = 0; i < countUnits; i++)
        {
            unitRed.transform.localScale = new Vector3(1f, 1f, 1f) * Random.Range(unitMinRad, unitMaxRad);

            Vector3 pos = new Vector3(Random.Range(randXmin, randXmax), 0.5f, Random.Range(randZmin, randZmax));

            Units.Add((GameObject)Instantiate(unitRed, pos, Quaternion.Euler(Vector3.up * Random.Range(0f, 180f))));

            yield return new WaitForSeconds(spawningDelay);

            unitBlue.transform.localScale = new Vector3(1f, 1f, 1f) * Random.Range(unitMinRad, unitMaxRad);

            Units.Add((GameObject)Instantiate(unitBlue, pos, Quaternion.Euler(Vector3.up * Random.Range(0f, 180f))));

            yield return new WaitForSeconds(spawningDelay);
        }
    }
}
