using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beachball : MonoBehaviour
{
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        var randomScale = Random.Range(3,6);
        transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.04f)
        {
            transform.position = startPos;
        }
    }
}
