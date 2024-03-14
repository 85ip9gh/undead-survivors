using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject enemy;
    private float timer;

    private float spawnCap;
    private float spawnTimer;

    private bool waveOver;

    private GameObject[] count;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.fixedTime + 3f;
        waveOver = false;
        spawnCap = 10;
        spawnTimer = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy");

        if (Time.fixedTime >= timer && count.Length < spawnCap && waveOver == false && player.isAlive()) 
        { 
            timer = Time.fixedTime + spawnTimer;
            Instantiate(enemy);
        }
    }

    public void endWave()
    {
        waveOver = true;
    }

    public void nextWave()
    {
        waveOver = false;
        spawnCap += 5;
        if (spawnTimer > 0.1f)
        {
            spawnTimer -= 0.1f;
        }
    }

    public int getCount()
    {
        return count.Length;
    }

    public void restart()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < count.Length; i++)
        {
            Destroy(count[i]);
        }
        
        timer = Time.fixedTime + 3f;
        spawnCap = 10;
        waveOver = false;
        spawnTimer = 1f;
    }
}
