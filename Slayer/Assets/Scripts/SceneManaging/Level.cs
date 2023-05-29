using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level Instance;

    float startingTime = 90f;
    public float currentTime = 0f;

    public KeyCode startLevelKey;

    [HideInInspector]
    public bool gameStarted;

    /*
     * 1 - o jogador entra no n�vel e pode andar pelo n�vel antes de come�ar o n�vel
     * 
     * 2 - o jogador aperta numa tecla e come�a o counter do tempo do nivel
     * 
     * 3 - os portais s�o desabilitados para que o jogador n�o possa sair do nivel
     * 
     * 4 - se o jogador morre no nivel aparece a tela de morte e ele volta pro nivel inicial
     * 
     * 5 - se o jogador vence ele avan�a para o nivel seguinte
     * 
     */

    private void Start()
    {
        gameStarted = false;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyUp(startLevelKey))
        {
            gameStarted = true;
            currentTime -= Time.deltaTime;
        }
        */

        if(!PlayerMovement.Instance.playerDied && Input.GetKeyDown(startLevelKey) && !gameStarted)
        {
            StartTimer();
        }
        
        if(gameStarted)
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void StartTimer()
    {
        gameStarted = true;
        currentTime = startingTime;
    }
}
