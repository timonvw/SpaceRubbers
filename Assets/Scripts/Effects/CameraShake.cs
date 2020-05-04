using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //screen shake
    public IEnumerator cameraShake(float seconds, float force)
    {
        Vector3 originalPos = transform.localPosition;
        float timer = 0.0f;

        while (timer < seconds)
        {
            float x = Random.Range(-1f, 1f) * force;
            float y = Random.Range(-1f, 1f) * force;

            transform.localPosition = new Vector3(x, y, originalPos.z);


            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
