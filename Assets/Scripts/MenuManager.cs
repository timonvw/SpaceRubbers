using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        MuiscManager.Instance.PlayBackgroundSound("menu");
    }

    /*// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("j0");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("j1");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("j2");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("j3");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Debug.Log("j4");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Debug.Log("j5");
        }
        
        float vertical = Input.GetAxis("Vertical1");
        float horizontal = Input.GetAxis("Horizontal1");
        float horizontal2 = Input.GetAxis("Horizontal2");

        Debug.Log("vertical1 = " + vertical);
        Debug.Log("horizontal = " + horizontal);
        Debug.Log("horizontal2 = " + horizontal2);


    }*/

    public void OnClickToGame()
    {
        SceneManager.LoadScene("Story");
    }

    public void OnClickToControls()
    {
        SceneManager.LoadScene("Controls");
    }
}
