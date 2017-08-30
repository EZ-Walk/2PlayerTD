using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Steamworks;

public class GameMaster : MonoBehaviour {

    [Header("Enemies Killed")]
    public GameObject enemiesKilledCounter;

    [Header("Wave Counter")]
    public GameObject waveCounter;
    public GameObject bottomUIWaveCounter;

    [Header("Structure Health")]
    public GameObject end;
    public GameObject enemy;
    public GameObject healthCounter;
    public GameObject bottomUIHealthCounter;
    public GameObject info;
    public static string Info;

    [Header("Shop")]
    public GameObject Gold;
    public GameObject bottomUIGold;
    public GameObject ElectricGel;
	public GameObject bottomUIElectricGel;
    public GameObject Metal;
	public GameObject bottomUIMetal;

    private int score;
    private int currentWave;
    private int health = 100;
    public static int gold = 99999;
    public static int electricGel = 99999;
    public static int metal = 99999;

    [Header("Ready Up System")]
    private bool currentlyReady = false;
    public static bool overseerReady = false;
    public static bool rangerReady = false;
    public GameObject overseerReadyIndicator;
    //false is not ready, true is ready
    public GameObject rangerReadyIndicator;

    [Header("Audio Sources")]
    public AudioSource readyUpSE;
    public AudioSource waveStart;
    public AudioSource enemyDestroyed;
    public AudioSource turretPlaced;
    public AudioSource turretDestroyed;
    public AudioSource arrowFired;
    public AudioSource enemyReachesEndSE;
    public AudioSource gameOver;
    public AudioSource unreadySE;

    [Header("Movement Mode")]
    public bool isWalkingPrefered;

    private void Start()
    {
		clearInfo();
		overseerReady = false;
		rangerReady = false;
        VRTK.Examples.Archery.BowAim.powerMultiplier = 30;
    }

    private void Update()
    {
        enemiesKilledCounter.GetComponent<TextMeshProUGUI>().text = score + "";

        waveCounter.GetComponent<TextMeshProUGUI>().text = currentWave + "";
        bottomUIWaveCounter.GetComponent<TextMeshProUGUI>().text = currentWave + "";

        healthCounter.GetComponent<TextMeshProUGUI>().text = health + "";
        bottomUIHealthCounter.GetComponent<TextMeshProUGUI>().text = health + "";

        Gold.GetComponent<TextMeshProUGUI>().text = gold + "";
        bottomUIGold.GetComponent<TextMeshProUGUI>().text = gold + "";

        ElectricGel.GetComponent<TextMeshProUGUI>().text = electricGel + "";
		bottomUIElectricGel.GetComponent<TextMeshProUGUI>().text = electricGel + "";

		Metal.GetComponent<TextMeshProUGUI>().text = metal + "";
		bottomUIMetal.GetComponent<TextMeshProUGUI>().text = metal + "";

		overseerReadyIndicator.GetComponent<TextMeshProUGUI>().text = overseerReady + "";

        rangerReadyIndicator.GetComponent<TextMeshProUGUI>().text = rangerReady + "";

        info.GetComponent<TextMeshProUGUI>().text = Info;
    }

    public IEnumerator clearInfo()
    {
        yield return new WaitForSeconds(7f);
        Info = " ";
    }

    public void enemyKilled()
    {
        enemyDestroyed.Play();
    }


    public void increaseEnemiesKilled ()
    {
        score++;
    }

    public void increaseWaveCounter ()
    {
        currentWave++;
    }

    public void enemyReachesEnd ()
    {
        health = health - 5;
        enemyReachesEndSE.Play();

        if (health <= 0)
        {
            gameOver.Play();
            Application.LoadLevelAsync("MainMenu");
        }
    }

    public void builtTurret ()
    {
        gold = gold - shop.costOfCurrentTurret;
        Debug.Log(shop.costOfCurrentTurret);
        metal -= shop.metalCostOfCurrentTurret;
        electricGel -= shop.electricGelCostOfCurrentTurret;
        Info = "You have built a turret! Resources have been deducted";
        clearInfo();
    }

    public void notEnoughGold()
    {
        Info = "You don't have the required resources!";
        clearInfo();
    }

    public void toggleReadyOverseer ()
    {
        if (currentlyReady)
        {
            unreadyOverseer();
            currentlyReady = false;
        }
        else if (!currentlyReady)
        {
            readyOverseer();
            currentlyReady = true;
        }
    }

    void readyOverseer()
    {
        overseerReady = true;
        readyUpSE.Play();
    }

    void unreadyOverseer()
    {
        overseerReady = false;
        unreadySE.Play();
    }

    public void readyRanger()
    {
        rangerReady = true;
        readyUpSE.Play();
    }

    public void unreadyRanger ()
    {
        rangerReady = false;
        unreadySE.Play();
    }

    public void tryToStartWithoutReady ()
    {
        Info = "Both players need to ready up before you can start the wave!";
        clearInfo();
    }

    public void buyBowV2()
    {
        if (gold >= 200)
        {
            gold -= 200;
            VRTK.Examples.Archery.BowAim.powerMultiplier = 40;
        }
        else
        {
            Info = "you don't have enough gold!";
            clearInfo();
        }
    }

    public void buyBowV3()
    {
        if (gold >= 500)
        {
            gold -= 500;
            VRTK.Examples.Archery.BowAim.powerMultiplier = 50;
            Debug.Log("power mult is " + VRTK.Examples.Archery.BowAim.powerMultiplier);
        }
        else
        {
            Info = "you don't have enough gold!";
            clearInfo();
        }
    }
}
