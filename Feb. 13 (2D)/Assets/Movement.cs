using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        //movement *= Time.deltaTime;

        //transform.Translate(movement);

        direction = new Vector2(inputX, inputY);
        if (Mathf.Abs(direction.x) == 1 || Mathf.Abs(direction.y) == 1)
        {
            direction.Normalize();
        }

        rb.MovePosition(rb.position + (direction * Time.fixedDeltaTime * speed));
    }
}
