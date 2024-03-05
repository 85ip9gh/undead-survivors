using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;

    const float BOTTOM = -3.5f;
    const float TOP = 13.5f;
    const float LEFT = -10.5f;
    const float RIGHT = 31.5f;

    const float VERTICAL_OFFSET = 5.5f;
    const float HORIZONTAL_OFFSET = 12.65f;
    //private bool moving;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Druid Warforged Token").GetComponent<Transform>();
        //moving = true;
        spawn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(agent.transform.position, target.position) > 1) 
        {
            agent.SetDestination(target.position);
        } else
        {
            agent.SetDestination(agent.transform.position);

            GameObject spawner = GameObject.FindWithTag("Spawner");
            Enemy_AI spawnScript = spawner.GetComponent<Enemy_AI>();
            spawnScript.decreaseCount();

            Destroy(this.gameObject);
        }

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


        /**
        if (target.position.y + VERTICAL_OFFSET < TOP)
        {
            agent.transform.position = new Vector2(
                target.position.x + UnityEngine.Random.Range(-HORIZONTAL_OFFSET,HORIZONTAL_OFFSET), 
                target.position.y + VERTICAL_OFFSET);
                
        }
        */
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
