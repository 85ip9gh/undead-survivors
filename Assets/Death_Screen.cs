using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Death_Screen : MonoBehaviour
{
    public Canvas screen;
    public Enemy_AI enemyAI;
    public Timer_Time timer;
    public Player player;
    public PauseScreen pauseScreen;

    public Timer_Text timerText;

    private TextMeshProUGUI timerTextEnd;
    private TextMeshProUGUI timerTimeEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        screen.enabled = false;
        timerTextEnd = GameObject.Find("Timer Text End").GetComponent<TextMeshProUGUI>();
        timerTimeEnd = GameObject.Find("Timer Time End").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDeath()
    {
        timerTextEnd.text = timerText.getText();
        timerTimeEnd.text = timer.getTime() + " remaining";
        screen.enabled = true;
    }

    public void hideDeath()
    {
        screen.enabled = false;
    }

    public void restartMain()
    {
        enemyAI.restart();
        timer.restart();
        player.restart();
        pauseScreen.unpause();
        hideDeath();
    }

    public void returnToMainMenu()
    {
        hideDeath();
        //swap out with code that returns to main menu later
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
