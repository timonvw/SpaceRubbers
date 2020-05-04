using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
   public int playerHealth = 30;
   int damage = 10;
    // Start is called before the first frame update
   
   void Start()
    {
        //print(playerHealth);
    }
    // Damage by touching cactus
   void OnCollissionEnter(Collision c)
    {
        if (c.gameObject.tag == "cactus")
        {
            GameMaster.Instance.Damage(damage);
            //Debug.Log();
        }
    }

    //Update is called once per frame
    void Update()
    {
        
    }
}
