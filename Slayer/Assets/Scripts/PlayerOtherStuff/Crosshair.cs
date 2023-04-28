using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private RectTransform crosshair;

    public float restingSize;
    public float maxSize;
    public float speed;
    private float currentSize;

    private void Start()
    {
        crosshair = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isPlayerMoving)
        {
            currentSize = Mathf.Lerp(currentSize,maxSize,speed * Time.deltaTime);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize,restingSize,speed * Time.deltaTime);
        }

        crosshair.sizeDelta = new Vector2 (currentSize,currentSize);
    }

    bool isPlayerMoving
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                return true;
            else
                return false;
        }
    }
}
