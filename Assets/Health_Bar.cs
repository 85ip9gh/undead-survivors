using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar : MonoBehaviour
{
    Vector3 scale;

    private void Awake()
    {
        scale = transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void healthUpdate(float health, float healthMax)
    {
        scale.x = health / healthMax;
        transform.localScale = scale;
    }
}
