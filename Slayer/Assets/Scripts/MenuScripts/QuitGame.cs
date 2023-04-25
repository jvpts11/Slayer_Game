using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Exited from the game");
        Application.Quit();
    }
}
