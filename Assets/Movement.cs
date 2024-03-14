using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    private int health;
    private float immunity;

    public PauseScreen script;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 5;
        immunity = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        immunity -= Time.fixedDeltaTime;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        direction = new Vector2(inputX, inputY);
        if (Mathf.Abs(direction.x) == 1 || Mathf.Abs(direction.y) == 1)
        {
            direction.Normalize();
        }

        rb.MovePosition(rb.position + (direction * Time.fixedDeltaTime * speed));

        if (Input.GetKey(KeyCode.Escape))
        {
            script.showPause();
        }
    }
    public void OnHit()
    {
        if (health > 0 && immunity < 0)
        {
            health--;
            immunity = 2f;
        }

        if (health == 0)
        {
            Debug.Log("L");

            script.pause();
        }
    }

    
}
