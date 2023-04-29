using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude )
    {
        if (!gameObject.activeSelf)
        {
            yield break;
        }

        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0.0f;

        while ( elapsedTime < duration )
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f,1f) * magnitude;

            transform.localPosition = new Vector3( x, y, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
