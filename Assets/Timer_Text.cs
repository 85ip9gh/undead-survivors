using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_Text : MonoBehaviour
{
    private TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateWave(int wave)
    {
        TimerText.text = "Wave " + wave.ToString();
    }

    public string getText()
    {
        return TimerText.text;
    }
}
