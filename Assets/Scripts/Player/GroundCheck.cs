using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public car carScript;

    private bool speedOnce = true;

    private void OnTriggerStay(Collider c)
    {
        //Debug.Log(c.gameObject.layer);
        //Debug.Log(carScript.grounded);

        if (c.gameObject.layer == 10)
        {
            carScript.grounded = true;
        }
        if(c.gameObject.tag == "speedUp")
        {
            carScript.ActivateSpeed();
        }
    }

    private void OnTriggerExit(Collider c)
    {
        carScript.grounded = false;
    }
}
