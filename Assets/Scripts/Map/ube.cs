using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ube : MonoBehaviour
{
    public bool Destroyable;

    private void OnTriggerEnter(Collider c)
    {
        if(Destroyable)
        {
            if (c.gameObject.name == "Car")
            {
                GameMaster.Instance.ShakeCamera(0.4f, 0.1f);
                Destroy(this.gameObject);
                MuiscManager.Instance.PlayShotHitObject();
            }
            if(c.gameObject.name == "playerBullet(Clone)")
            {
                GameMaster.Instance.ShakeCamera(0.3f, 0.1f);
                Destroy(this.gameObject);
                //MuiscManager.Instance.PlayShotHitObject();
            }
        }
    }
}
