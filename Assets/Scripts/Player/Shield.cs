using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Update()
    {
        transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);
    }
}
