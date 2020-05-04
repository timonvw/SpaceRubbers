using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    #region Singleton
    private static GameMaster _instance;
    public static GameMaster Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("GameMaster");
                //go.AddComponent<GameMaster>();
            }

            return _instance;
        }
    }
    #endregion

    //public get setters

    //player
    public float SpaceDollars { get; private set; }
    public int Wave { get; private set; }
    public float CarSpeed { get; private set; }
    public float BulletSpeed { get; private set; }
    public float BulletRecoil { get; private set; }
    public float TotalTime { get; private set; }
    public float Seconds { get; private set; }
    public bool Shielded { get; set; }

    public int EnemiesWaveTotal { get; private set; }
    public int EnemiesLeftWave { get; private set; }
    public int EnemieSpawnCount { get; private set; }
    public string CurrentAbility { get; private set; }

    public CameraShake camShake;
    public Transform[] EnemieSpawns;
    public bool[] enemieSpawnsTaken;
    public GameObject enemyPrefab;
    public GameObject gameOver;

    //enemy
    public float BulletSpeedEnemyMin { get; private set; }
    public float BulletSpeedEnemyMax { get; private set; }
    public float ThrustEnemyMin { get; private set; }
    public float ThrustEnemyMax { get; private set; }
    public float GunTimeMin { get; private set; }
    public float GunTimeMax { get; private set; }

    // Use this for initialization
    void Awake()
    {
        //start values
        _instance = this;
        GameStart();
    }

    public void GameStart()
    {
        //level
        SpaceDollars = 6000000f;
        Wave = 1;
        TotalTime = 0f;
        EnemiesWaveTotal = 0;
        EnemiesLeftWave = 0;
        EnemieSpawnCount = 5;

        //player
        CarSpeed = 40f;
        BulletSpeed = 40f;
        BulletRecoil = 0.3f;
        CurrentAbility = "";

        //enemies
        BulletSpeedEnemyMin = 8f;
        BulletSpeedEnemyMax = 10f;
        ThrustEnemyMin = 20f;
        ThrustEnemyMax = 25f;
        GunTimeMin = 2f;
        GunTimeMax = 3f;

        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;
        Seconds += Time.deltaTime;

        if(Seconds >= 60f)
        {
            Seconds = 0;
        }

        #region input yostick knoppen
        /*if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("j0");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log("j1");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("j2");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Debug.Log("j3");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            Debug.Log("j4");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            Debug.Log("j5");
        }*/
        #endregion

        if(SpaceDollars <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if(EnemiesLeftWave <= 0)
        {
            Wave++;
            EnemieSpawnCount += 2;

            BulletSpeedEnemyMin++;
            BulletSpeedEnemyMax++;
            ThrustEnemyMin++;
            ThrustEnemyMax++;
            GunTimeMin += 0.2f;
            GunTimeMax += 0.2f;

            SpawnEnemies();
        }
    }

    //camera shake, kan vanaf overal aangeroepen worden
    public void ShakeCamera(float duration, float force)
    {
        StartCoroutine(camShake.cameraShake(duration, force));
    }

    public void SetCarSpeed(float speed)
    {
        CarSpeed = speed;
    }

    public void AddBulletSpeed(float speed)
    {
        BulletSpeed += speed;
    }

    public void ReduceBulletRecoil(float time)
    {
        BulletRecoil -= time;
    }

    public void Damage(int amount)
    {
        SpaceDollars -= amount;
    }

    public void EnemyDead()
    {
        EnemiesLeftWave -= 1;
    }

    public void SetCurrentAbility(string name)
    {
        CurrentAbility = name;
        //UI dingen hier aanspreken xoxo timon
    }

    //enemies in spawnen op random plaats
    public void SpawnEnemies()
    {
        EnemiesWaveTotal = 0;

        while(EnemiesWaveTotal < EnemieSpawnCount)
        {
            var randomPos = Random.Range(0, EnemieSpawns.Length);

            if (enemieSpawnsTaken[randomPos] == false)
            {
                var enemy = Instantiate(enemyPrefab, EnemieSpawns[randomPos].position, transform.rotation);
                enemieSpawnsTaken[randomPos] = true;
                EnemiesWaveTotal++;
            }
        }

        //alle spawn punten resetten
        for(int i = 0; i < enemieSpawnsTaken.Length; i++)
        {
            enemieSpawnsTaken[i] = false;
        }

        EnemiesLeftWave = EnemiesWaveTotal;
        UIManager.Instance.UpdateMaxEnemies();
    }
}
