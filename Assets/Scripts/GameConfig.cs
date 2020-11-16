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
	public float unitSpawnMaxRadius;
	public int unitSpawnMinSpeed;
	public int unitSpawnMaxSpeed;
	public float unitDestroyRadius;

	public static GameConfig Singleton;

	/// <summary>
	/// Сериализация GameConfig.json в объект
	/// </summary>

	public static GameConfig StartSer()
	{
		string path = Application.streamingAssetsPath + "/GameConfig.json";

		UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(path);

		www.SendWebRequest();

        while (!www.isDone)
        {

        }

		string text = www.downloadHandler.text;

		GameConfig config = JsonUtility.FromJson<GameConfig>(text);

        Singleton = config;

        return config;
    }
}

