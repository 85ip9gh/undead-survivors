using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    private float endTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        gameObject.SetActive(false);
        endTime = float.PositiveInfinity;

        transform.localScale *= 2f;
        CircleCollider2D col = GetComponent<CircleCollider2D>();
        col.radius *= 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position;

        if (Time.fixedTime >= endTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void attack()
    {
        gameObject.SetActive(true);
        transform.position = player.transform.position;
        animator.PlayInFixedTime("Pulse");
        endTime = Time.fixedTime + 0.417f; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AI script = collision.GetComponent<AI>();
            script.hit("pulse");
        }
    }
}
