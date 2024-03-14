using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    private float endTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        endTime = float.PositiveInfinity;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= endTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AI script = collision.GetComponent<AI>();
            script.hit("dash");
        }
    }

    public void attack()
    {
        gameObject.SetActive(true);
        animator.PlayInFixedTime("Dash");
        gameObject.transform.position = player.transform.position;
        endTime = Time.fixedTime + 0.433f;
    }
}
