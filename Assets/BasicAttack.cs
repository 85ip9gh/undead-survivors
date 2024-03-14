using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BasicAttack : MonoBehaviour
{

    public GameObject player;
    private SpriteRenderer playerSprite;
    private SpriteRenderer attackSprite;
    private Animator animator;

    private bool right;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        attackSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        right = false;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (right)
        {
            transform.position = player.transform.position + new Vector3(1, 0, 0);
        } else
        {
            transform.position = player.transform.position + new Vector3(-1, 0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AI script = collision.GetComponent<AI>();
            script.hit("basic");
        }
    }

    public void attack()
    {
        gameObject.SetActive(true);

        if (playerSprite.flipX == false)
        {
            attackSprite.flipX = true;
            right = true;
            transform.position = player.transform.position + new Vector3(1, 0, 0);
        }
        else
        {
            attackSprite.flipX = false;
            right = false;
            transform.position = player.transform.position + new Vector3(-1, 0, 0);
        }

        animator.PlayInFixedTime("Basic Attack");
    }
    public void finished()
    {
        animator.PlayInFixedTime("Idle Attack");
        gameObject.SetActive(false);
    }
}
