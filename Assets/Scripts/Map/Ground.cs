using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private BoxCollider collider;
    private MeshCollider colliderMesh;
    public bool isMesh = false;

    // Start is called before the first frame update
    void Start()
    {
        car.OnGroundChange += InvokeFriction;
        
        if(isMesh)
        {
            colliderMesh = this.gameObject.GetComponent<MeshCollider>();
        }
        else
        {
            collider = this.gameObject.GetComponent<BoxCollider>();
        }
    }

    //de frictie veranderen van de physics material in de grond collider
    /* public void InvokeFriction(bool b)
     {
         if(b)
         {
             if(isMesh)
             {
                 if (colliderMesh.material.dynamicFriction != 1f)
                 {
                     colliderMesh.material.dynamicFriction = 1f;
                     colliderMesh.material.staticFriction = 1f;
                 }
             }
             else
             {
                 if (collider.material.dynamicFriction != 1f)
                 {
                     collider.material.dynamicFriction = 1f;
                     collider.material.staticFriction = 1f;
                 }
             }
         }
         else
         {
             if(isMesh)
             {
                 if (colliderMesh.material.dynamicFriction != 0.6f)
                 {
                     colliderMesh.material.dynamicFriction = 0.6f;
                     colliderMesh.material.staticFriction = 0.6f;
                 }
             }
             else
             {
                 if (collider.material.dynamicFriction != 0.6f)
                 {
                     collider.material.dynamicFriction = 0.6f;
                     collider.material.staticFriction = 0.6f;
                 }
             } 
         }
     }*/

    //alleen voor test purpose only
    public float GetFriction()
    {
        if(isMesh)
        {
            return colliderMesh.material.dynamicFriction;
        }
        else
        {
            return collider.material.dynamicFriction;
        }
    }

    //physics veranderen van de grond material
    private void InvokeFriction(bool b)
    {
        if (b)
        {
            if (isMesh)
            {
                if (colliderMesh.material.dynamicFriction != 1f)
                {
                    colliderMesh.material.dynamicFriction = 1f;
                    colliderMesh.material.staticFriction = 1f;
                }
            }
            else
            {
                if (collider.material.dynamicFriction != 1f)
                {
                    collider.material.dynamicFriction = 1f;
                    collider.material.staticFriction = 1f;
                }
            }
        }
        else
        {
            if (isMesh)
            {
                if (colliderMesh.material.dynamicFriction != 0.6f)
                {
                    colliderMesh.material.dynamicFriction = 0.6f;
                    colliderMesh.material.staticFriction = 0.6f;
                }
            }
            else
            {
                if (collider.material.dynamicFriction != 0.6f)
                {
                    collider.material.dynamicFriction = 0.6f;
                    collider.material.staticFriction = 0.6f;
                }
            }
        }
    }

    //als dit object weggaat of er niet meer is unsubscribe voor de zekerheid
    private void OnDisable()
    {
        car.OnGroundChange -= InvokeFriction;
    }
}
