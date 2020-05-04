using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionalBullet : MonoBehaviour
{
    public float speed { private get; set; }
    public float Xas;
    public float Yas;
    public float Zas;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Xas,Yas,Zas);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(Xas,Yas,Zas) * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Car")
        {
            if (GameMaster.Instance.Shielded == false)
            {
                //GameMaster.Instance.SpaceDollars -= 1f;
                //play animation
                GameMaster.Instance.ShakeCamera(0.5f, 0.2f);
                GameMaster.Instance.Damage(400000);
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
