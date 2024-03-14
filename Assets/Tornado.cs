using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Tornado : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    private bool timeStart;
    private float timer;
    private Vector2 direction;

    private void Awake()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();

        timeStart = false;
        timer = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeStart) {
            timer -= Time.fixedDeltaTime;
            gameObject.transform.position += new Vector3(direction.x, direction.y, 0) * Time.fixedDeltaTime;
        }

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AI script = collision.GetComponent<AI>();
            script.hit("tornado");
        }
    }

    public void attack()
    {
        animator.PlayInFixedTime("Tornado");
        timeStart = true;

        gameObject.transform.position = player.transform.position;

        Vector2 mousePos = Input.mousePosition;
        Vector2 relativePlayer = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        direction = new Vector2(mousePos.x - relativePlayer.x, 
                                mousePos.y - relativePlayer.y);
        direction.Normalize();
        direction *= 1.25f;

        gameObject.transform.position += new Vector3(direction.x, direction.y, 0);
    }
}
