using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public GameObject enemyV2;
    public GameObject enemyV3;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private bool startWave = false;
    private int switcher = 0;

    private int waveNumber = 1;
    private int amountOfLvl1Enemies;
    private int amountOfLvl2Enemies;


    /*private void Update()
    {
        if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;
    }*/

    public void startWaveButtonPushed()
    {
        if (GameMaster.overseerReady && GameMaster.rangerReady == true)
        {
            StartCoroutine(SpawnWave());
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().increaseWaveCounter();
            AudioSource waveStart = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().waveStart;
            waveStart.Play();
        } else
        {
            Debug.Log("Can't start the wave until both players have readied up!");
        }
    }

    public IEnumerator SpawnWave ()
    {
        Debug.Log("spawning wave");

        switch (waveNumber)
        {
            case 1:
                SpawnEnemy();
                Debug.Log("case 1");
                waveNumber++;
                yield return new WaitForSeconds(.5f);
                break;

            case 2:
                SpawnEnemy();
                spawnEnemyV2();
                Debug.Log("case 2");
                waveNumber++;
                break;

            case 3:
                for (int i = 0; i < 6; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 4; i++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 3; i++)
                {
                    spawnEnemyV3();
                    yield return new WaitForSeconds(.5f);
                }
                break;

            case 4: //8 lvl 1 enemies and 6 lvl 2
                for (int i = 0; i < 9; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }
                for (int n = 0; n < 7; n++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }
                break;

            case 5:
                for (int i = 0; i < 16; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }

                for (int n = 0; n < 13; n++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }
                break;

            default:
                Debug.Log("default case triggered");

                //Random Wave generation
                amountOfLvl1Enemies = waveNumber * 3 * Random.Range(1, 4);
                amountOfLvl2Enemies = waveNumber * 3 * Random.Range(1, 3);
                for (int i = 0; i < amountOfLvl1Enemies + 1; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }

                for (int n = 0; n < amountOfLvl2Enemies + 1; n++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }
                break;
        }

        
        waveNumber++;
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void spawnEnemyV2 ()
    {
        Instantiate(enemyV2, spawnPoint.position, spawnPoint.rotation);
    }

    void spawnEnemyV3()
    {
        Instantiate(enemyV3, spawnPoint.position, spawnPoint.rotation);
    }


}
