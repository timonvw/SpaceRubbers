using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    private int xRotate;
    private int yRotate;
    private int zRotate;

    private void Start()
    {
        xRotate = Random.Range(10, 45);
        yRotate = Random.Range(20, 30);
        zRotate = Random.Range(10, 45);
    }
    // Update is called once per frame
    // Spin animation for pick ups
    void Update()
    {
        transform.Rotate(new Vector3(xRotate, yRotate, zRotate) * Time.deltaTime);
    }
}
