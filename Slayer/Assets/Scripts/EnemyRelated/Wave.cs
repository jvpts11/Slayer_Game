using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public int waveNum;

    public int maxEnemyNum;

    public float enemyHealthIncrease;

    public float enemyHealth;

    public int enemyNumberIncrease;


    public Wave(int waveNum, float enemyHealth, int maxEnemyNum)
    {
        this.waveNum = waveNum;
        this.enemyHealthIncrease = enemyHealth;
        this.enemyHealth = enemyHealth;
        this.maxEnemyNum = maxEnemyNum;

    }
}
