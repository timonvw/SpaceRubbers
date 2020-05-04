using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCar : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private Transform firePoint;
    [SerializeField]private GameObject[] bullets;
    private bool shoot = true;
    public GameObject shield;
    public Transform carPoint;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = carPoint.transform.position;

        //Debug.Log(transform.localEulerAngles.y);
        if ((Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal2") == 1) /*&& (transform.localEulerAngles.y >= 300f || (transform.localEulerAngles.y <= 63 && transform.localEulerAngles.y >= -5f))*/)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + speed, transform.localEulerAngles.z);
        }

        //de geweer naar rechts bewegen
        if ((Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal2") == -1) /*&& (transform.localEulerAngles.y <= 60f || (transform.localEulerAngles.y <= 360 && transform.localEulerAngles.y >= 299))*/)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + -speed, transform.localEulerAngles.z);
        }

        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Joystick2Button0)) && shoot)
        {
            var b = Instantiate(bullets[0], new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), transform.rotation);
            StartCoroutine(recoilTimer());
            MuiscManager.Instance.PlayShotFireBullet();
        }

        /*if(transform.localEulerAngles.y >= 63 && transform.localEulerAngles.y  <= 299)
        {
            transform.localEulerAngles = new Vector3(0,0,0);
        }*/

        if((Input.GetKey(KeyCode.Joystick2Button2) && Input.GetKey(KeyCode.Joystick1Button2)) || (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.Z)))
        {
            if(GameMaster.Instance.CurrentAbility != "")
            {
                switch(GameMaster.Instance.CurrentAbility)
                {
                    case "shield":
                        activateShield();
                        UIManager.Instance.SetAbilitySlot("empty");
                        GameMaster.Instance.SetCurrentAbility("");
                        break;
                }
            }
        }
    }

    private IEnumerator recoilTimer()
    {
        shoot = false;
        yield return new WaitForSeconds(GameMaster.Instance.BulletRecoil);
        shoot = true;
    }

    private void activateShield()
    {
        StartCoroutine(ShieldCountdown());
    }

    private IEnumerator ShieldCountdown()
    {
        MuiscManager.Instance.PlayShieldSound();
        GameMaster.Instance.Shielded = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(3f);
        MuiscManager.Instance.StopEffectsLoopSound();
        GameMaster.Instance.Shielded = false;
        shield.SetActive(false);
    }

    //a = 300
    //d = 60
}
