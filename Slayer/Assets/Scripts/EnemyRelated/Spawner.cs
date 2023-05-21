using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] public GameObject enemyToSpawn;
    [SerializeField] public float timeBetweenSpawns;
    [SerializeField] public Transform spawnerPos;

    float startingTime;


    void Start()
    {
        timeBetweenSpawns = startingTime;
    }

    
    void Update()
    {
        timeBetweenSpawns -= Time.deltaTime;
        if (timeBetweenSpawns <= 0) InstantiateEnemy();
        ResetTime();
    }

    private float ResetTime()
    {
        return timeBetweenSpawns = startingTime;
    }

    private void InstantiateEnemy()
    {
        Instantiate(enemyToSpawn, spawnerPos.transform.position, Quaternion.identity);
    }
}
