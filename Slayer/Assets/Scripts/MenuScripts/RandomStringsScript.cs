using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomStringsScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    public string[] strings = {"Ur Bad", "Still trying?", "Ur mom does better", "Play Diff", "You fed the bot lane", "Wy are u bad" };

    private int randString;

    void Start()
    {
        randString = Random.Range(0, strings.Length);
        text.text = strings[randString];
    }
}
