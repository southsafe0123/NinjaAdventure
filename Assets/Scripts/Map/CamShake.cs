using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public IEnumerator camShake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapse = 0;
        while (elapse < duration)
        {
            float x = originalPos.x + Random.Range(-1f, 1f) * magnitude;
            float y = originalPos.y + Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, originalPos.z);
            elapse += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }
}
