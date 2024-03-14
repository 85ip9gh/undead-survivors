using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives_Text : MonoBehaviour
{
    private TextMeshProUGUI LivesText;

    // Start is called before the first frame update
    void Start()
    {
        LivesText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealth(int health)
    {
        LivesText.text = "Lives: " + health.ToString();
    }
}
