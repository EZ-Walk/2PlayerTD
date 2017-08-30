using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Analytics : MonoBehaviour {

	[Header("Analytics")]
	public static int[] gameData;
	public string fileName;
	public static int arrowKillSnowman;
	public static int turretKillSnowman;
	public static int pistolKillSnowman;
	



	private void saveGameData()
	{
		var gd = File.CreateText(fileName);
		gd.WriteLine();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
