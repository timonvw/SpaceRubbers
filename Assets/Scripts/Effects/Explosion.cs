﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deleteTimer());
    }

    private IEnumerator deleteTimer()
    {
        yield return new WaitForSeconds(1.3f);
        Destroy(this.gameObject);
    }
}
