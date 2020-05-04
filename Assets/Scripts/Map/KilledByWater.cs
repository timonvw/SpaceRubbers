using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByWater : MonoBehaviour
{
    // Water damage
    int damage = 300000000;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Instant dead by touching water
    void OnCollissionEnter(Collision c)
    {
        if (c.gameObject.tag == "water")
        {
            GameMaster.Instance.Damage(damage);
            //Debug.Log();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
