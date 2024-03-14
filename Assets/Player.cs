using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public PauseScreen script;
    private int health;
    private float immunity;
    private float attackCooldown;
    private const float ATTACK_COOLDOWN = 0.533f;

    private bool attacked;
    public BasicAttack attackScript;
    public GameObject attackTornado;

    public Pulse pulseScript;
    private float pulseCooldown;

    private float dashCooldown;
    private bool dash;
    public Dash dashScript;
    private int dashCount;

    public Lives_Text livesScript;

    private bool alive;
    private float deathPopup;
    public Death_Screen deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.position = new Vector3(-7.5f, 0.5f, 0f);
        health = 5;
        immunity = Time.fixedTime;
        attackCooldown = Time.fixedTime;
        attacked = false;

        pulseCooldown = Time.fixedTime + 5f;
        dashCooldown = Time.fixedTime;
        dash = false;
        dashCount = 0;

        alive = true;
        deathPopup = float.PositiveInfinity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            direction = new Vector2(inputX, inputY);

            if (Time.fixedTime >= pulseCooldown)
            {
                pulseCooldown = Time.fixedTime + 5f;
                pulse();
            }

            if (Mathf.Abs(direction.x) == 1 || Mathf.Abs(direction.y) == 1)
            {
                direction.Normalize();
            }

            direction *= 1f; //if you want to increase/decrease the speed with upgrades

            if (Time.fixedTime > attackCooldown)
            {
                attacked = false;
            }

            if (Input.GetKey(KeyCode.Space) && Time.fixedTime > dashCooldown)
            {
                dash = true;
                dashCount = 0;
                dashScript.attack();
                dashCooldown = Time.fixedTime + 1f;
            }

            if (Input.GetMouseButton(0) && Time.fixedTime > attackCooldown || attacked == true)
            {
                if (attacked == false)
                {
                    if (isMouseRight())
                    {
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
                    attacked = true;
                    attackCooldown = Time.fixedTime + ATTACK_COOLDOWN;
                    attackScript.attack();
                    tornado();
                }
                animator.PlayInFixedTime("Attack");
            }
            else
            {
                attacked = false;
                if (inputX == 0 && inputY == 0)
                {
                    animator.PlayInFixedTime("Player");
                }
                else
                {
                    animator.PlayInFixedTime("Moving");
                }
            }

            if (inputX > 0 && attacked == false)
            {
                spriteRenderer.flipX = false;
            }
            if (inputX < 0 && attacked == false)
            {
                spriteRenderer.flipX = true;
            }

            if (dash)
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 relativePlayer = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

                Vector2 mouseDirection = new Vector2(mousePos.x - relativePlayer.x,
                                        mousePos.y - relativePlayer.y);
                mouseDirection.Normalize();

                rb.MovePosition(rb.position + mouseDirection * Time.fixedDeltaTime * 15f);

                if (dashCount < 8)
                {
                    ++dashCount;
                }
                else
                {
                    dash = false;
                    dashCount = 0;
                }
            }
            else
            {
                rb.MovePosition(rb.position + (direction * Time.fixedDeltaTime * speed));
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                script.showPause();
            }
        }

        if (Time.fixedTime >= deathPopup)
        {
            deathScreen.showDeath();
            script.pause();
        }
    }

    private bool isMouseRight()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 relativePlayer = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        return mousePos.x - relativePlayer.x > 0;
    }

    private void tornado()
    {
        GameObject tempTornado = Instantiate(attackTornado);
        Tornado tornadoScript = tempTornado.GetComponent<Tornado>();
        tornadoScript.attack();
    }

    private void pulse()
    {
        pulseScript.attack();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (alive)
        {
            if (Time.fixedTime >= immunity && collision.gameObject.CompareTag("Enemy"))
            {
                immunity = Time.fixedTime + 2f;
                health--;
                livesScript.updateHealth(health);
            }

            if (health <= 0)
            {
                alive = false;
                animator.PlayInFixedTime("Death");
                deathPopup = Time.fixedTime + 3f;
                //Debug.Log("L");

                //script.pause();
            }
        }
    }

    public bool isAlive()
    {
        return alive;
    }

    public void restart()
    {
        transform.position = new Vector3(-7.5f, 0.5f, 0f);
        health = 5;
        immunity = Time.fixedTime;
        attackCooldown = Time.fixedTime;
        attacked = false;

        pulseCooldown = Time.fixedTime + 5f;
        dashCooldown = Time.fixedTime;
        dash = false;
        dashCount = 0;
        livesScript.updateHealth(health);

        alive = true;
        deathPopup = float.PositiveInfinity;
    }
}
