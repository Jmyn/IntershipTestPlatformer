using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
    public static string HIGHSCORE = "highscore";
    public static GameControl current;
    public EnemySpawnScript enemySpawner;
    public PickupSpawn pickupSpawner;
    public ComponentHealth playerHp;
    public ScreenFade fader;
    public GUIDisplay gui;
    public float pickupsSpawnInterval = 15f;
    public float enemySpawnInterval = 10f;
    public float difficultyIncreaseInterval = 60f;
    public int killCnt = 0;

    public int maxEnemy = 3;
    public int enemyCnt = 0;
    public int gameDuration = 180;

    private int highScore = 0;
    private float startTime;
    private float elaspedTime;
    private bool spawnedPickup = false;
    private bool increasedDiff = false;
    void Awake()
    {
        current = this;
    }
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        if (PlayerPrefs.HasKey(HIGHSCORE))
        {
            highScore = PlayerPrefs.GetInt(HIGHSCORE);
        }
	}
	
	// Update is called once per frame
	void Update () {
        elaspedTime = Time.time - startTime;

        if(IsGameOver()) {
            fader.EndScene();
            gui.showEndGUI("GAMEOVER!");
        }

        if(IsWin()) {
            if(killCnt > highScore) {
                PlayerPrefs.SetInt(HIGHSCORE, killCnt);
                highScore = killCnt;
            }
            fader.EndScene();
            gui.showEndGUI("YOU WIN!");
        }

        if (TimetoSpawnEnemy())
        {
            if (enemyCnt < maxEnemy)
            {
                enemySpawner.SpawnEnemy();
            }
        }
        if(TimetoSpawnPickups()) {
            if(!spawnedPickup) {
                pickupSpawner.SpawnPickup();
                spawnedPickup = true;
                Invoke("resetPickup",1f);
            }
        }
        if(TimetoIncreaseDifficulty()) {
            if (!increasedDiff)
            {
                maxEnemy++;
                enemySpawner.increaseDifficulty(1);
                pickupSpawner.IncreasePickupPerSpawn(1);
                increasedDiff = true;
                Invoke("resetIncreasedDiff", 1f);
            }
        }
	}

    void resetPickup() { spawnedPickup = false; }
    void resetIncreasedDiff() { increasedDiff = false; }

    bool TimetoSpawnEnemy()
    {
        if (GetElaspedTime() % enemySpawnInterval == 0  )
        {
            return true;
        }
        return false;
    }

    bool TimetoSpawnPickups()
    {
        if (GetElaspedTime() % pickupsSpawnInterval == 0 && GetElaspedTime() != 0)
        {
            return true;
        }
        return false;
    }

    bool TimetoIncreaseDifficulty()
    {
        if (GetElaspedTime() % difficultyIncreaseInterval == 0 && GetElaspedTime() != 0)
        {
            return true;
        }
        return false;
    }

    public int GetElaspedTime()
    {
        return (int)elaspedTime;
    }

    bool IsGameOver()
    {
        return playerHp.CurrHP <= 0 ? true : false;
    }

    bool IsWin()
    {
        return GetElaspedTime() == gameDuration ? true : false;
    }

    public void EnemyDied()
    {
        killCnt++;
        enemyCnt = Mathf.Max(0,enemyCnt - 1);
    }

    public int GetHighScore() { return highScore; }

    public int GetPlayerMaxHp() { return playerHp.MaxHP; }
    public int GetPlayerCurrHp() { return playerHp.CurrHP; }
}
