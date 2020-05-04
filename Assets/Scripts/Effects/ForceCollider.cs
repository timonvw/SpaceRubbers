using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCollider : MonoBehaviour
{
    public bool explode = false;

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.name == "Car")
        {
            if(explode)
            {
                //hier player explode en game over
            }
            else
            {
                GameMaster.Instance.ShakeCamera(0.3f, c.gameObject.GetComponent<Rigidbody>().velocity.magnitude * 0.01f);
                //MuiscManager.Instance.PlayShotHitObject();
            }
        }
    }
}
