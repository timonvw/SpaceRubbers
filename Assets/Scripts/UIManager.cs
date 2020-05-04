using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("UIManager");
                //go.AddComponent<UIManager>();
            }

            return _instance;
        }
    }
    #endregion

    public Slider money;
    public Text moneyText;
    public Slider enemies;
    public Text enemiesText;
    public Slider timeSlider;
    public Text Wave;
    public Text Time;
    public GameObject damage;

    public GameObject speedText;
    public GameObject fireRateText;
    public GameObject shieldRate;

    public Image abilitySlot;
    public Sprite shieldSprite;
    public Sprite emptySprite;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    { 
        money.maxValue = GameMaster.Instance.SpaceDollars;
        enemies.maxValue = GameMaster.Instance.EnemiesWaveTotal;
        //timeSlider.maxValue = 60;
        damage.SetActive(false);

        speedText.SetActive(false);
        fireRateText.SetActive(false);
        shieldRate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //velden zetten text update
        Wave.text = GameMaster.Instance.Wave.ToString();
        Time.text = GameMaster.Instance.TotalTime.ToString("0:00");

        moneyText.text = money.value.ToString();
        enemiesText.text = enemies.value.ToString();

        //velden zetten slider update
        money.value = GameMaster.Instance.SpaceDollars;
        enemies.value = GameMaster.Instance.EnemiesLeftWave;
        //timeSlider.value = GameMaster.Instance.Seconds;
    }

    public void UpdateMaxEnemies()
    {
        enemies.maxValue = GameMaster.Instance.EnemiesWaveTotal;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowDamage()
    {
        StartCoroutine(DamageTimer());
    }

    private IEnumerator DamageTimer()
    {
        damage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damage.SetActive(false);
    }

    public void ActivateAbilityText(string name)
    {
        StartCoroutine(timerAbilityText(name));
    }

    public void SetAbilitySlot(string name)
    {
        switch(name)
        {
            case "shield":
                abilitySlot.sprite = shieldSprite;
                break;
            case "empty":
                abilitySlot.sprite = emptySprite;
                break;
        }
    }

    //ability timer text in beeld laten zien
    private IEnumerator timerAbilityText(string name)
    {
        switch (name)
        {
            case "speed":
                speedText.SetActive(true);
                break;
            case "firespeed":
                fireRateText.SetActive(true);
                break;
            case "shield":
                shieldRate.SetActive(true);
                break;
        }
        yield return new WaitForSeconds(1.45f);
        switch (name)
        {
            case "speed":
                speedText.SetActive(false);
                break;
            case "firespeed":
                fireRateText.SetActive(false);
                break;
            case "shield":
                shieldRate.SetActive(false);
                break;
        }
    }
}
