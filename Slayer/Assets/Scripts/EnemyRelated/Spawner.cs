using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour , IDoNothing
{

    [SerializeField] public GameObject enemyToSpawn;
    public float timeBetweenSpawns;
    [SerializeField] public Transform spawnerPos;
    [SerializeField] public float enemyHealthIncrease = 25;
    [SerializeField] public int enemyInscreseNumber = 2;
    [SerializeField] public float enemyHealth;
    [SerializeField] public int initialEnemyNumber = 5;

    public int currentEnemies;
    public int enemiesKilled;

    private Wave wave;

    public float spawnFrequency;


    void Start()
    {
        timeBetweenSpawns = spawnFrequency;
        currentEnemies = 0;
        wave = new Wave(1, enemyHealth, initialEnemyNumber);
    }

    void Update()
    {
        if (Level.Instance.gameStarted != false)
        {
            timeBetweenSpawns -= Time.deltaTime;
            Debug.Log(wave.maxEnemyNum);
            if(currentEnemies <= wave.maxEnemyNum)
            {
                if (timeBetweenSpawns <= 0)
                {
                    InstantiateEnemy();
                    ResetTime();
                }
            }
        }
        else
        {
            DoNothing();
        }
    }

    private void ResetTime()
    {
        timeBetweenSpawns = spawnFrequency;
    }

    public void NotifyDeath()
    {
        enemiesKilled++;
        if(enemiesKilled >= wave.maxEnemyNum)
        {
            wave.waveNum++;
            wave.maxEnemyNum += enemyInscreseNumber;
            wave.enemyHealth += enemyHealthIncrease;
            enemiesKilled = 0;
            currentEnemies = 0;
        }
    }

    private void InstantiateEnemy()
    {
        GameObject enemy = Instantiate(enemyToSpawn, spawnerPos.transform.position, Quaternion.identity);
        enemy.GetComponentInChildren<Enemy>().InitializeEnemy(wave.enemyHealth, this);
        currentEnemies++;
        
    }

    public void DoNothing()
    {
        
    }
}
