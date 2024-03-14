using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Time : MonoBehaviour
{
    private TextMeshProUGUI TimerTime;
    private float timer;
    private int wave;

    public GameObject spawner;
    private Enemy_AI spawnScript;
    public TextMeshProUGUI timerText;
    private Timer_Text timerTextScript;

    const float TEMP_TIME = 30f;

    public Player player;
    public Upgradescreen upgradeScreen;
    public PauseScreen pauseScreen;

    private void Start()
    {
        TimerTime = GetComponent<TextMeshProUGUI>();
        timer = TEMP_TIME;
        wave = 1;

        spawnScript = spawner.GetComponent<Enemy_AI>();
        timerTextScript = timerText.GetComponent<Timer_Text>();
    }

    void FixedUpdate()
    {
        if (player.isAlive())
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(timer / 60f);
                int seconds = Mathf.FloorToInt(timer % 60f);
                TimerTime.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            else
            {
                int minutes = 0;
                int seconds = 0;
                TimerTime.text = minutes.ToString("00") + ":" + seconds.ToString("00");
                spawnScript.endWave();
                if (spawnScript.getCount() == 0)
                {
                    pauseScreen.pause();
                    upgradeScreen.showUpgrades();
                }
            }
        }
    }

    public void nextWave()
    {
        pauseScreen.unpause();
        wave++;
        spawnScript.nextWave();
        timerTextScript.updateWave(wave);
        timer = TEMP_TIME + TEMP_TIME * (wave - 1) * 0.5f;
    }

    public void restart()
    {
        timer = TEMP_TIME;
        wave = 1;
        timerTextScript.updateWave(wave);
    }

    public string getTime()
    {
        return TimerTime.text;
    }
}
