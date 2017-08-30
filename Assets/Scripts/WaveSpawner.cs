using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	[Header("Enemy prefabs")]
    public Transform enemyPrefab;
    public GameObject enemyV2;
    public GameObject enemyV3;
    public GameObject enemyV4;
	public GameObject broodMother;

	[Header("Waves 1 - 5 config")]

	public int[] wave1enemies;

    public static bool isWaveActive = false;
    private int[] enemies;

    public Transform spawnPoint;

    public float timeBetweenWaves = 30f;
    private float countdown = 2f;
    private bool startWave = false;
    private int switcher = 0;
    private int counter;

    private int waveNumber = 0;
    private int amountOfLvl1Enemies;
    private int amountOfLvl2Enemies;
    private int amountOfLvl3Enemies;
    private int amountOfLvl4Enemies;

    private void Start()
    {
        isWaveActive = false;
        StartCoroutine(timerBetweenWaves());
        InvokeRepeating("checkForWave", 0, 1f);
    }

    void checkForWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isWaveActive = false;
            CancelInvoke();
            StartCoroutine(timerBetweenWaves());
        }
    }

    public IEnumerator timerBetweenWaves()
    {
        yield return new WaitForSeconds(30f);

        if (!isWaveActive)
        {
            StartCoroutine(SpawnWave());
        }
    }

    public void startWaveButtonPushed()
    {

        if (GameMaster.overseerReady && GameMaster.rangerReady == true)
        {
            StopCoroutine(timerBetweenWaves());
            isWaveActive = true;
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
        waveNumber++;
        Debug.Log("spawning wave");

        switch (waveNumber)
        {
            case 1:
                SpawnEnemy();
                Debug.Log("case 1");
                break;

            case 2:
                SpawnEnemy();
                spawnEnemyV2();
                spawnEnemyV3();
                //spawnEnemyV4();
                Debug.Log("case 2");
                break;

            case 3:
                Debug.Log("case 3");
                for (int i = 0; i < 5; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 3; i++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 3; i++)
                {
                    spawnEnemyV3();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 2; i++)
                {
                    //spawnEnemyV4();
                }
                break;

            case 4: //8 lvl 1 enemies and 6 lvl 2
                for (int i = 0; i < 5; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }
                for (int n = 0; n < 6; n++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }
                for (int i = 0; i < 6; i++)
                {
                    spawnEnemyV3();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 4; i++)
                {
                    //spawnEnemyV4();
                }
                break;

            case 5:
                for (int i = 0; i < 11; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(.5f);
                }

                for (int n = 0; n < 9; n++)
                {
                    spawnEnemyV2();
                    yield return new WaitForSeconds(.5f);
                }
                for (int i = 0; i < 7; i++)
                {
                    spawnEnemyV3();
                    yield return new WaitForSeconds(.5f);
                }

                for (int i = 0; i < 6; i++)
                {
                    //spawnEnemyV4();
                }

				for (int i = 0; i < 1; i++)
				{
					spawnBroodMother();
					yield return new WaitForSeconds(.5f);
				}
                break;

            default:
                Debug.Log("default case triggered");

                //Random Wave generation
                amountOfLvl1Enemies = waveNumber * 2 * Random.Range(1, 4);
                amountOfLvl2Enemies = waveNumber * 2 * Random.Range(1, 3);
                amountOfLvl3Enemies = waveNumber * 2 * Random.Range(1, 2);
                amountOfLvl4Enemies = waveNumber * Random.Range(1, 2);
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

                for (int n = 0; n < amountOfLvl3Enemies + 1; n++)
                {
                    spawnEnemyV3();
                    yield return new WaitForSeconds(.5f);
                }

                for (int n = 0; n < amountOfLvl4Enemies + 1; n++)
                {
                    //spawnEnemyV4();
                    yield return new WaitForSeconds(.5f);
                }
                break;
        }
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

    void spawnEnemyV4()
    {
        Instantiate(enemyV4, spawnPoint.position, spawnPoint.rotation);
        
    }

	void spawnBroodMother()
	{
		Instantiate(broodMother, spawnPoint.position, spawnPoint.rotation);
	}

}
