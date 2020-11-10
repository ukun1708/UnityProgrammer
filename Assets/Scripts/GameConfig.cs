using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameConfig
{
    public int gameAreaWidth;
	public int gameAreaHeight;
	public int numUnitsToSpawn;
	public int unitSpawnDelay;
	public float unitSpawnMinRadius;
	public int unitSpawnMaxRadius;
	public int unitSpawnMinSpeed;
	public int unitSpawnMaxSpeed;
	public float unitDestroyRadius;

	//Сериализация GameConfig.json в объект
	public static GameConfig StartSer()
    {
		string path = Application.streamingAssetsPath + "\\GameConfig.json";
		string text = File.ReadAllText(path);

		GameConfig config = JsonUtility.FromJson<GameConfig>(text);

		return config;
    }
}

