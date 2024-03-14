using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static Unity.VisualScripting.FlowStateWidget;

public class AI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;

    const float BOTTOM = -3.5f;
    const float TOP = 13.5f;
    const float LEFT = -10.5f;
    const float RIGHT = 31.5f;

    const float VERTICAL_OFFSET = 5.5f;
    const float HORIZONTAL_OFFSET = 12.65f;
    private GameObject spawner;
    private Enemy_AI spawnScript;

    private float health;
    private float healthMax;

    //List of cooldowns from gettnig hit
    private float basicAttackTime;
    private float tornadoAttackTime;
    private float pulseAttackTime;
    private float cycloneAttackTime;
    private float dashAttackTime;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        healthMax = 10; //if you want to scale the health of enemies as you get further in
        health = healthMax; 

        //List of cooldowns from gettnig hit
        basicAttackTime = Time.fixedTime;
        tornadoAttackTime = Time.fixedTime;
        pulseAttackTime = Time.fixedTime;
        cycloneAttackTime = Time.fixedTime;
        dashAttackTime = Time.fixedTime;

        spawn();
        agent.speed = 1f; //if you want to scale the movement of enemies as you get further in
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        spawnScript = spawner.GetComponent<Enemy_AI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(agent.transform.position, target.position) > 1) 
        {
            agent.SetDestination(target.position);
        }
    }

    public void hit(string damage)
    {
        switch(damage)
        {
            case "basic":
                if (Time.fixedTime >= basicAttackTime)
                {
                    health -= 3;
                    basicAttackTime = Time.fixedTime + 0.533f;
                    healthBar();
                }
                break;
            case "tornado":
                if (Time.fixedTime >= tornadoAttackTime)
                {
                    health -= 1;
                    tornadoAttackTime = Time.fixedTime + 0.2f;
                    healthBar();
                }
                break;
            case "pulse":
                if (Time.fixedTime >= pulseAttackTime)
                {
                    health -= 2;
                    pulseAttackTime = Time.fixedTime + 0.417f;
                    healthBar();
                }
                break;
            case "cyclone":
                if (Time.fixedTime >= cycloneAttackTime)
                {
                    health -= 1;
                    cycloneAttackTime = Time.fixedTime + 0.2f;
                    healthBar();
                }
                break;
            case "dash":
                if (Time.fixedTime >= dashAttackTime)
                {
                    health -= 3;
                    dashAttackTime = Time.fixedTime + 0.433f;
                    healthBar();
                }
                break;
        }
        if (health <= 0) die();
    }

    private void healthBar()
    {
        Health_Bar script = GetComponentInChildren<Health_Bar>();
        script.healthUpdate(health, healthMax);
    }
    public void die()
    {
        Destroy(gameObject);
    }

    private void spawn()
    {
        
        ArrayList directions = new ArrayList();
        //in bounds
        if (target.position.x - HORIZONTAL_OFFSET > LEFT)
        {
            directions.Add("left");
        }

        if (target.position.x + HORIZONTAL_OFFSET < RIGHT)
        {
            directions.Add("right");
        }

        if (target.position.y + VERTICAL_OFFSET < TOP)
        {
            directions.Add("top");
        }
        if (target.position.y - VERTICAL_OFFSET > BOTTOM)
        {
            directions.Add("bottom");
        }

        int num = UnityEngine.Random.Range(0, directions.Count);

        string obj = (string)directions[num];

        switch (obj)
        {
            case "left":
                agent.transform.position = new Vector2(
                target.position.x - HORIZONTAL_OFFSET,
                target.position.y + UnityEngine.Random.Range(leftWall(), rightWall()));
                break;
            case "right":
                agent.transform.position = new Vector2(
                target.position.x + HORIZONTAL_OFFSET,
                target.position.y + UnityEngine.Random.Range(leftWall(), rightWall()));
                break;
            case "top":
                agent.transform.position = new Vector2(
                target.position.x + UnityEngine.Random.Range(leftWall(), rightWall()),
                target.position.y + VERTICAL_OFFSET);
                break;
            case "bottom":
                agent.transform.position = new Vector2(
                target.position.x + UnityEngine.Random.Range(leftWall(), rightWall()),
                target.position.y - VERTICAL_OFFSET);
                break;
            default:
                Debug.Log("Spawn error");
                break;
        }
    }

    public float leftWall()
    {
        if (target.position.x - HORIZONTAL_OFFSET > LEFT) 
        {
            return -HORIZONTAL_OFFSET;
        } else
        {
            return LEFT - target.position.x;
        }
    }

    public float rightWall()
    {
        if (target.position.x + HORIZONTAL_OFFSET < RIGHT)
        {
            return HORIZONTAL_OFFSET;
        }
        else
        {
            return target.position.x - RIGHT;
        }
    }

    public float topWall()
    {
        if (target.position.y + VERTICAL_OFFSET < TOP)
        {
            return VERTICAL_OFFSET;
        }
        else
        {
            return TOP - target.position.y;
        }
    }

    public float bottomWall()
    {
        if (target.position.y - VERTICAL_OFFSET > BOTTOM)
        {
            return -VERTICAL_OFFSET;
        }
        else
        {
            return target.position.y - BOTTOM;
        }
    }
}
