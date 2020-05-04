using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameObject car;
    public GameObject gun;
    public float gunTime { get; set; }
    private float movementSpeed;
    public float bulletCap { get; set; }
    public float oldBulletCap { get; set; }
    private float bulletSpeed;
    private int rBullet;

    private float thrust;
    public Rigidbody rb;

    [SerializeField]private GameObject[] bullets;
    public GameObject[] abilities;
    private bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("hitPoint");
        rBullet = Random.Range(0, bullets.Length);
        StartCoroutine(fireBullet());
        gunTime = Random.Range(GameMaster.Instance.GunTimeMin, GameMaster.Instance.GunTimeMax);
        bulletSpeed = Random.Range(GameMaster.Instance.BulletSpeedEnemyMin, GameMaster.Instance.BulletSpeedEnemyMax);
        //movementSpeed = Random.Range(GameMaster.Instance.ThrustEnemyMin, GameMaster.Instance.ThrustEnemyMax);
        thrust = Random.Range(GameMaster.Instance.ThrustEnemyMin, GameMaster.Instance.ThrustEnemyMax);

        rb = GetComponent<Rigidbody>();

        if (bulletSpeed <= movementSpeed)
        {
            bulletSpeed = movementSpeed + 1f;
        }

        Physics.IgnoreLayerCollision(11, 12);

        //transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {
        moveToPlayer();

        //kijken hoe groot de afstand tussen de enemy en de speler is, als dichtbij dan pas schieten
        if(Vector2.Distance(car.transform.position, transform.position) <= 25)
        {
            shoot = true;
        }
        else
        {
            shoot = false;
        }
    }

    private IEnumerator fireBullet()
    {
        yield return new WaitForSeconds(gunTime);

        if(shoot)
        {
            var b = Instantiate(bullets[rBullet], new Vector3(gun.transform.position.x,gun.transform.position.y,gun.transform.position.z), transform.rotation);
        
            switch(rBullet)
            {
                case 0:
                    b.GetComponent<bullet>().bSpeed = bulletSpeed;
                    break;
                case 1:
                    b.GetComponent<trippleBullet>().bSpeed = bulletSpeed;
                    break;
                case 2:
                    b.GetComponent<trippleBullet>().bSpeed = bulletSpeed;
                    break;
                case 3:
                    b.GetComponent<trippleBullet>().bSpeed = bulletSpeed;
                    break;
            }
        }

        StartCoroutine(fireBullet());
    }

    //look at player and transform forward
    private void moveToPlayer()
    {
        transform.LookAt(car.transform);
        //transform.position += transform.forward * movementSpeed * Time.deltaTime;
        rb.AddForce(transform.forward * thrust);

    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "Car")
        {
            if(GameMaster.Instance.Shielded == false)
            {
                GameMaster.Instance.Damage(300000);
                GameMaster.Instance.ShakeCamera(0.5f, 0.2f);
                UIManager.Instance.ShowDamage();
                Destroy();
            }
            else
            {
                Destroy();
            }
            
        }

        if (c.gameObject.tag == "pBullet")
        {
            Destroy(c.gameObject);
            Destroy();

            GameMaster.Instance.ShakeCamera(0.3f, 0.1f);
            //explode animatie
        }
    }

    public void Destroy()
    {
        var r = Random.Range(0, 10);

        switch (r)
        {
            case 2:
                Instantiate(abilities[0], new Vector3(transform.position.x, 1f, transform.position.z), transform.rotation);
                break;
            case 6:
                Instantiate(abilities[1], new Vector3(transform.position.x, 1f, transform.position.z), transform.rotation);
                break;
            case 8:
                Instantiate(abilities[2], new Vector3(transform.position.x, 1f, transform.position.z), transform.rotation);
                break;
        }

        MuiscManager.Instance.PlayShotExplosion();
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        GameMaster.Instance.EnemyDead();
    }
}
