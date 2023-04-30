using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string levelName;

    public GameObject obj;
    public LayerMask layerMask;

    bool isPlayer(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        bool objectIsPlayer = isPlayer(obj, layerMask);

        if (objectIsPlayer) SceneManager.LoadScene(levelName);
    }
}
