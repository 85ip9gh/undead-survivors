using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{

    public GameObject StartScreen;
    public GameObject HelpScreen;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        HelpScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClick()
    {
        StartScreen.SetActive(false);
        
    }

    public void HelpButtonClick()
    {
        StartScreen.SetActive(false);
        HelpScreen.SetActive(true);
    }

    public void BackButtonClick()
    {
        HelpScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void MainMenuWinScreen()
    {
        WinScreen.SetActive(false);
        StartScreen.SetActive(true);
    }

    public void MainMenuLoseScreen()
    {
        LoseScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
}
