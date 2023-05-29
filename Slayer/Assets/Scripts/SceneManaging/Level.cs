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
    public static float currentTime = 0f;

    public KeyCode startLevelKey;

    [HideInInspector]
    public bool gameStarted;

    /*
     * 1 - o jogador entra no nível e pode andar pelo nível antes de começar o nível
     * 
     * 2 - o jogador aperta numa tecla e começa o counter do tempo do nivel
     * 
     * 3 - os portais são desabilitados para que o jogador não possa sair do nivel
     * 
     * 4 - se o jogador morre no nivel aparece a tela de morte e ele volta pro nivel inicial
     * 
     * 5 - se o jogador vence ele avança para o nivel seguinte
     * 
     */

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (Input.GetKey(startLevelKey))
        {
            if(PlayerMovement.instance.playerDied != true)
            {
                gameStarted = true;
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = startingTime;
            }
        }
    }
}
