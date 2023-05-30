using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimationController : MonoBehaviour
{

    public GameObject textToAnimate;

    void Update()
    {
        try
        {
            if(Gun.Instance.thisGunIsReloading == true)
            {
                textToAnimate.GetComponent<Animator>().Play("TextFadeIn");
            }
            else
            {
                textToAnimate.GetComponent<Animator>().Play("TextFadeOut");
            }
        }
        catch(UnityException e)
        {
            Debug.LogException(e);
        }
        
    }
}
