using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    private Rigidbody rb;
    private bool steer;

    [SerializeField]private float speed;
    [SerializeField]private float steeringSpeed;
    //[SerializeField]private Ground ground;
    [SerializeField]private GameObject cam;

    public bool grounded;
    private bool isSpeeding;

    //delegate event callback ground physics edit
    public delegate void ChangeGroundPhysics(bool b);
    public static event ChangeGroundPhysics OnGroundChange;

    // Start is called before the first frame update
    void Start()
    {
        addComponents();
        Physics.IgnoreLayerCollision(8, 9);

        //sound
        //MuiscManager.Instance.PlayCarSound();
    }

    void addComponents()
    {
        rb = GetComponent<Rigidbody>();
        //ground = GameObject.Find("Groundnew").GetComponent<Ground>();
        SetSpeed();
    }

    public void SetSpeed()
    {
        speed = GameMaster.Instance.CarSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(grounded)
        {
            //sturen vooruit en achteruit + frictie van grond veranderen
            if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.UpArrow) /*|| Input.GetAxis("Vertical1") == -1*/)
            {
                rb.AddForce(transform.forward * speed);
                changeGroundPhysics(false);
                //Debug.Log("RIJDEN");
            }
            if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.DownArrow) /*|| Input.GetAxis("Vertical1") == 1*/)
            {
                rb.AddForce(transform.forward * -speed);
                changeGroundPhysics(false);
            }
        }

        //kijken of de auto beweegt
        if (rb.velocity.magnitude < 0.01)
        {
            steer = false;
        }
        else
        {
            steer = true;
        }

        //Debug.Log(rb.velocity.magnitude);
    }

    void Update()
    {
        //sturen links en rechts
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal1") == -1) && steer)
        {
            //rotate auto hier
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + -steeringSpeed, transform.localEulerAngles.z);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal1") == 1) && steer)
        {
            //rotate auto hier
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + steeringSpeed, transform.localEulerAngles.z);
        }

        //Kijken of vooruit en lings en rechts arror tegelijk worden ingedrukt, zo ja de frictie van de grond veranderen
        if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
            || (Input.GetKey(KeyCode.Joystick1Button0) && Input.GetAxis("Horizontal1") == -1) || (Input.GetKey(KeyCode.Joystick1Button0) && Input.GetAxis("Horizontal1") == 1))
        {
            //ground.InvokeFriction(true);
            changeGroundPhysics(true);
        }

        //Debug.Log(ground.GetFriction());

        if(transform.position.y < 0.04f)
        {
            GetComponent<BoxCollider>().enabled = false;
            //rb.constraints = RigidbodyConstraints.None;
            //rb.AddForceAtPosition(Vector3.up, Vector3.right * rb.velocity.magnitude);
            speed = 0f;
            

            if (transform.position.y < -6f)
            {
                transform.position = new Vector3(0,0.7f,0);
                //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                //transform.eulerAngles = new Vector3(0, 0, 0);
                cam.transform.position = new Vector3(transform.position.x,cam.transform.position.y,transform.position.z);
                GameMaster.Instance.Damage(300);
                GetComponent<BoxCollider>().enabled = true;
                speed = GameMaster.Instance.CarSpeed;
            }
        }

        //sound op basus van je snelheid
        MuiscManager.Instance.SetCarPitch(rb.velocity.magnitude);
    }

    public void ActivateSpeed()
    {
        if(!isSpeeding)
        {
            StartCoroutine(speedTimer());
        }
    }

    private IEnumerator speedTimer()
    {
        isSpeeding = true;
        speed = speed + 25f;
        yield return new WaitForSeconds(2f);
        SetSpeed();
        isSpeeding = false;
    }

    //alle subscribde events uitvoeren
    private void changeGroundPhysics(bool b)
    {
        if(OnGroundChange != null)
        {
            OnGroundChange(b);
        }
    }
}
