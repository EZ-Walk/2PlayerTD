using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Steamworks;

public class GameData : MonoBehaviour {

	[Header("Analytics")]
	public static int[] gameData;
	public string fileName = "gameData";

	public static int arrowKillSnowman;
	public static int turretKillSnowman;
	public static int pistolKillSnowman;

	public static int arrowKillBalloon;
	public static int turretKillBalloon;
	public static int pistolKillBalloon;

	public static int arrowKillRedBall;
	public static int turretKillRedBall;
	public static int pistolKillRedBall;

	public static int arrowKillBrood;
	public static int turretKillBrood;
	public static int pistolKillBrood;
	



	private void saveGameData()
	{
		var gd = File.CreateText(fileName);
		gd.WriteLine();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
