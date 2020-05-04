using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trippleBullet : MonoBehaviour
{
    public float bSpeed { private get; set; }
    [SerializeField] private List<GameObject> bullets; 

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject bullet in bullets)
        {
            bullet.GetComponent<directionalBullet>().speed = bSpeed;
        }
        
        StartCoroutine(timerDestroy());
    }

    //Destroy bullet
    private IEnumerator timerDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "playerBullet")
        {
            Destroy(this.gameObject);
            //explode animatie
        }
        if(c.gameObject.name == "Car")
        {
            if (GameMaster.Instance.Shielded == false)
            {
                 Destroy(this.gameObject);

                //Levens van speler af
                GameMaster.Instance.Damage(300000);
                UIManager.Instance.ShowDamage();
                //explode animatie
            }
            else
            {
                Destroy(this.gameObject);
            }

           
        }
    }
}
