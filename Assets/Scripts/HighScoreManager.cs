using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public GameObject[] Boxes;
    public int[] BoxCounters;

    public GameObject Frame1;
    public GameObject Frame2;
    public GameObject Frame3;

    public string[] LetterArray;
    public int SelectedBoxCounter;

    // Start is called before the first frame update
    void Start()
    {
        BoxCounters[1] = 0;
        BoxCounters[2] = 0;
        BoxCounters[3] = 0;
        SelectedBoxCounter = 1;
        Frame1.SetActive(true);
        Frame2.SetActive(false);
        Frame3.SetActive(false);
    }

    private void SetBoxLetter(int box)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetAxis("Vertical1") == -1)
        {
            Boxes[box].transform.position = new Vector3(Boxes[box].transform.position.x, Boxes[box].transform.position.y + 100, Boxes[box].transform.position.z);
            BoxCounters[box]++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical1") == 1)
        {
            Boxes[box].transform.position = new Vector3(Boxes[box].transform.position.x, Boxes[box].transform.position.y + -100, Boxes[box].transform.position.z);
            BoxCounters[box]--;
        }

        if (Boxes[box].GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            Boxes[box].GetComponent<RectTransform>().anchoredPosition = new Vector3(Boxes[box].GetComponent<RectTransform>().anchoredPosition.x, 2500);
            BoxCounters[box] = 25;
        }

        if (Boxes[box].GetComponent<RectTransform>().anchoredPosition.y > 2500)
        {
            Boxes[box].GetComponent<RectTransform>().anchoredPosition = new Vector3(Boxes[box].GetComponent<RectTransform>().anchoredPosition.x, 0);
            BoxCounters[box] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Box 1
        if (SelectedBoxCounter == 1)
        {
            Frame1.SetActive(true);
            SetBoxLetter(1);
        }

        //Box 2
        if (SelectedBoxCounter == 2)
        {
            Frame1.SetActive(false);
            Frame2.SetActive(true);
            SetBoxLetter(2);
        }

        //Box 3
        if (SelectedBoxCounter == 3)
        {
            SetBoxLetter(3);
            Frame2.SetActive(false);
            Frame3.SetActive(true);
        }

        if (SelectedBoxCounter == 4)
        {
            Frame3.SetActive(false);

            //Opslaan in playerPrefs
            PlayerPrefs.SetInt(LetterArray[BoxCounters[1]] + LetterArray[BoxCounters[2]] + LetterArray[BoxCounters[3]], 34587);

        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            SelectedBoxCounter++;
        }
    }
}
