using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level Instance;

    float startingTime = 90f;
    public static float currentTime = 0f;

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

    private void Update()
    {
        
    }
}
