using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelStates
    {
        notStarted,
        Running,
        PlayerDied,
        Ended
    }

    public static Level Instance;

    float startingTime = 90f;
    float currentTime = 0f;

    private void Awake()
    {
        levelManaging(LevelStates.notStarted);
    }

    private void Start()
    {
        
    }

    public void levelManaging(LevelStates levelState)
    {
        switch (levelState)
        {
            case (LevelStates)1: 
                DoNothing(); 
                break;
        }
    }

    private void StartLevel()
    {
        currentTime = startingTime;
    }

    private void ResetLevel()
    {
        
    }

    private void EndLevel()
    {

    }

    private void DoNothing()
    {

    }
}
