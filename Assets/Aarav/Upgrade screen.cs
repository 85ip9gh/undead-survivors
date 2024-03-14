using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Upgradescreen : MonoBehaviour
{
    public Canvas upgradeScreen;
    //private bool isUpgradeScreenOpen;
    public static string specialAbility;
    //array of 5 Game objects

    public Text[] upgradeButtons;
    private string[] possibleUpgrades;

    public Timer_Time time;

    // Start is called before the first frame update
    void Start()
    {
        upgradeScreen.enabled = false;
        //isUpgradeScreenOpen = false;

        possibleUpgrades = new string[] {
            "BasicAttack", 
            "Movement",
            "Health",
            "Tornado",
            "Pulse",
            "Cyclone",
            "Dash"
        };
    }

    // Update is called once per frame
    void Update()
    {
        /**
        if (Input.GetKeyUp(KeyCode.U))
        {
            if (isUpgradeScreenOpen == true)
            {
                CloseUpgradeScreen();
            }
            else
            {
                OpenUpgradeScreen();
            }
        }
        **/
    }
    public void OpenUpgradeScreen()
    {

        upgradeScreen.enabled = true;
        //Debug.Log("Upgrade Screen Opened");
        //isUpgradeScreenOpen = true;
    }
    public void CloseUpgradeScreen()
    {
        upgradeScreen.enabled = false;
        //isUpgradeScreenOpen = false;
    }

    public void showUpgrades()
    {
        OpenUpgradeScreen();
        String[] upgradesChosen = RandomizeUpgrades(possibleUpgrades);
        upgradeButtons[0].text = upgradesChosen[0];
        upgradeButtons[1].text = upgradesChosen[1];
        upgradeButtons[2].text = upgradesChosen[2];
    }

    //this method takes an array as input and makes a list and selects 3
    //random upgrades from the list and pops it out of the list so no repetition return the new array
    public String[] RandomizeUpgrades(String[] upgrades)
    {
        List<String> upgradeList = new List<String>(upgrades);
        String[] newUpgrades = new String[3];
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, upgradeList.Count);
            newUpgrades[i] = upgradeList[randomIndex];
            upgradeList.RemoveAt(randomIndex);
        }
        return newUpgrades;
    }

    /**
    //instantitates the 3 objects in the array at the given 
    public void InstantiateUpgrades(GameObject[] upgrades, Vector3 position)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(upgrades[i], position, Quaternion.identity);
            position+= new Vector3(5, 0, 0);
        }
    }
    */

    public void upgradePressLeft()
    {
        upgrade(upgradeButtons[0].text);
        CloseUpgradeScreen();
        time.nextWave();
    }

    public void upgradePressMid()
    {
        upgrade(upgradeButtons[1].text);
        CloseUpgradeScreen();
        time.nextWave();
    }

    public void upgradePressRight()
    {
        upgrade(upgradeButtons[2].text);
        CloseUpgradeScreen();
        time.nextWave();
    }

    private void upgrade(string upgrade)
    {
        switch (upgrade)
        {
            case "BasicAttack":
                break;
            case "Movement":
                break;
            case "Health":
                break;
            case "Tornado":
                break;
            case "Pulse":
                break;
            case "Cyclone":
                break;
            case "Dash":
                break;
        }
    }

    private void upgradeText(string upgrade)
    {
        switch (upgrade)
        {
            case "BasicAttack":
                break;
            case "Movement":
                break;
            case "Health":
                break;
            case "Tornado":
                break;
            case "Pulse":
                break;
            case "Cyclone":
                break;
            case "Dash":
                break;
        }
    }


}