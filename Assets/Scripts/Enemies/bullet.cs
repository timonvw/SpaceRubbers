using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private GameObject car;
    public float bSpeed { private get; set; }

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("hitPoint");
        transform.LookAt(car.transform);
        StartCoroutine(timerDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bSpeed * Time.deltaTime;
    }

    //Destroy bullet
    private IEnumerator timerDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "Car")
        {
            if (GameMaster.Instance.Shielded == false)
            {
                //GameMaster.Instance.SpaceDollars -= 1f;
                //play animation
                GameMaster.Instance.ShakeCamera(0.5f, 0.2f);
                GameMaster.Instance.Damage(300000);
                UIManager.Instance.ShowDamage();
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            
        }
    }
}
