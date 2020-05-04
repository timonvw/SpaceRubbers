using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timerNextScene());
    }

    private IEnumerator timerNextScene()
    {
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadScene("Menu");
    }
}
