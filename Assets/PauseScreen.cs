using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public Canvas HUD;
    // Start is called before the first frame update
    void Start()
    {
        hidePause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hidePause()
    {
        HUD.enabled = true;
        this.gameObject.SetActive(false);
        unpause();
    }

    public void showPause()
    {
        HUD.enabled = false;
        this.gameObject.SetActive(true);
        pause();
    }

    public void pause()
    {
        Time.timeScale = 0f;
    }

    public void unpause()
    {
        Time.timeScale = 1.0f;
    }

    public void quit()
    {
        //swap out with code that returns to main menu later
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
