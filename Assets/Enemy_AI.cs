using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject enemy;
    private float timer;

    const float SPAWN_CAP = 10;
    const float SPAWN_TIMER = 1f;

    public int count;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && count + 1 <= SPAWN_CAP) 
        { 
            timer = SPAWN_TIMER;
            Instantiate(enemy);
            //enemies[count].transform.position = Vector3.zero;
            count++;
        }
    }

    public void decreaseCount()
    {
        count--;
    }
}
