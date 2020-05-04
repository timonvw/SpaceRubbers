using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedboost : MonoBehaviour
{
    public float speedTime = 2.0f;
    public float currentBoostTime;
    public bool boosting = false;
    public float time;

    public float baseSpeed = 1.0f;
    public float speedBoost = 2.0f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        currentBoostTime = 0f;
        speed = baseSpeed;
        
    }


    // Update is called once per frame
    void Update()
    {

        time = Time.time;

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "speedBoost")
        {
            speed = speedBoost;
            time = speedTime;
        }
    }
}
