using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AI_Script : MonoBehaviour
{
    public int health;
    private float timer;
    private bool cooldown;

    private void Start()
    {
        health = 100000;
        timer = 0.5f;
        cooldown = false;

    }
    public void takeDamage(int damage)
    {
        if (cooldown == false)
        {
            health = health - damage;
            cooldown = true;
            timer = 0.5f;
            Debug.Log("Enemy took " + damage + " damage");
            Debug.Log(health);
        }
        if (health <= 0)
        {
            Debug.Log("Enemy is dead");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooldown == true)
        {
            cooldown = false;
        }
    }
    
}
