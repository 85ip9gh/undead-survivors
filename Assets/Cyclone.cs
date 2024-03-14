using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclone : MonoBehaviour
{
    public GameObject player;
    private Animator animator;

    private float rotationSpeed;
    private float orbitOffset;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rotationSpeed = 1f; //change to make the object orbit faster
        orbitOffset = 2f; //change to make the object orbit father away

        //If you want to increase the size with upgrades
        //transform.localScale *= 2f;
        //CircleCollider2D col = GetComponent<CircleCollider2D>();
        //col.radius *= 2f;
    }

    void FixedUpdate()
    {
        //transform.position = player.transform.position + offset;


        float angle = Time.fixedTime * rotationSpeed;
        var positionCenterObject = player.transform.position;

        var x = positionCenterObject.x + Mathf.Cos(angle) * orbitOffset;
        var y = positionCenterObject.y + Mathf.Sin(angle) * orbitOffset;
        transform.position = new Vector3(x, y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AI script = collision.GetComponent<AI>();
            script.hit("cyclone");
        }
    }
}
