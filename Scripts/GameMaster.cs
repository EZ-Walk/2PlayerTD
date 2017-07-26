using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour {

    [Header("Enemies Killed")]
    public GameObject enemiesKilledCounter;
    public GameObject rangerUIEnemiesKilledCounter;

    [Header("Wave Counter")]
    public GameObject waveCounter;
    public GameObject rangerUIWaveCounter;

    [Header("Structure Health")]
    public GameObject end;
    public GameObject enemy;
    public GameObject healthCounter;
    public GameObject rangerUIHealthCounter;
    public GameObject info;

    [Header("Shop")]
    public GameObject Gold;
    public GameObject rangerUIGold;

    private int score;
    private int currentWave;
    private int health = 100;
    public static int gold = 100;

    [Header("Ready Up System")]
    public static bool overseerReady = false;
    public static bool rangerReady = false;
    public GameObject overseerReadyIndicator;
    public GameObject rangerUIOverseerReadyIndicator;
    public GameObject rangerReadyIndicator;
    public GameObject rangerUIRangerReadyIndicator;

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


    private void Start()
    {
        updateGold();
        clearInfo();
        unreadyOverseer();
        unreadyRanger();
        VRTK.Examples.Archery.BowAim.powerMultiplier = 20;
    }


    public void increaseEnemiesKilled ()
    {
        score++;
        enemiesKilledCounter.GetComponent<TextMeshProUGUI>().text = score + "";
        rangerUIEnemiesKilledCounter.GetComponent<TextMeshProUGUI>().text = score + "";
    }

    public void increaseWaveCounter ()
    {
        currentWave++;
        waveCounter.GetComponent<TextMeshProUGUI>().text = currentWave + "";
        rangerUIWaveCounter.GetComponent<TextMeshProUGUI>().text = currentWave + "";
    }

    public void enemyReachesEnd ()
    {
        health = health - 5;
        healthCounter.GetComponent<TextMeshProUGUI>().text = health + "";
        rangerUIHealthCounter.GetComponent<TextMeshProUGUI>().text = health + "";
        enemyReachesEndSE.Play();

        if (health <= 0)
        {
            gameOver.Play();
            info.GetComponent<TextMeshProUGUI>().text = "YOU LOST!!";
        }
    }

    public void builtTurret ()
    {
        gold = gold - shop.costOfCurrentTurret;
        updateGold();
    }

    public void updateGold ()
    {
        Gold.GetComponent<TextMeshProUGUI>().text = gold + "";
        rangerUIGold.GetComponent<TextMeshProUGUI>().text = gold + "";
    }

    public void notEnoughGold()
    {
        info.GetComponent<TextMeshProUGUI>().text = "you dont have enough gold!";
    }

    public void clearInfo()
    {
        info.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void readyOverseer()
    {
        overseerReady = true;
        overseerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Overseer: Ready!";
        rangerUIOverseerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Overseer: Ready!";
        readyUpSE.Play();
    }

    public void unreadyOverseer()
    {
        overseerReady = false;
        overseerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Overseer: Not ready!";
        rangerUIOverseerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Overseer: Not ready!";
        unreadySE.Play();
    }

    public void readyRanger()
    {
        rangerReady = true;
        rangerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Ranger: Ready!";
        rangerUIRangerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Ranger: Ready!";
        readyUpSE.Play();
    }

    public void unreadyRanger ()
    {
        rangerReady = false;
        rangerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Ranger: Not ready";
        rangerUIRangerReadyIndicator.GetComponent<TextMeshProUGUI>().text = "Ranger: Not ready";
        unreadySE.Play();
    }

    public void tryToStartWithoutReady ()
    {
        info.GetComponent<TextMeshProUGUI>().text = "Both players need to ready up before you can start the wave!";
    }

    public void buyBowV2()
    {
        if (gold >= 200)
        {
            gold -= 200;
            updateGold();
            VRTK.Examples.Archery.BowAim.powerMultiplier = 30;
        }
        else
        {
            info.GetComponent<TextMeshProUGUI>().text = "you don't have enough gold!";
        }
    }

    public void buyBowV3()
    {
        if (gold >= 500)
        {
            gold -= 500;
            updateGold();
            VRTK.Examples.Archery.BowAim.powerMultiplier = 50;
            Debug.Log("power mult is " + VRTK.Examples.Archery.BowAim.powerMultiplier);
        }
        else
        {
            info.GetComponent<TextMeshProUGUI>().text = "you don't have enough gold!";
        }
    }
}
