using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private bool reset;
    private float timer;
    void Start()
    {
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.enabled = false;
        reset = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && timer <= 0)
        {
            this.boxCollider.enabled = true;
            timer = 5f;
            reset = true;

        }

        if (reset == true && timer <= 4.9f)
        {
            reset = false;
            this.boxCollider.enabled = false;
        }

        /**
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.boxCollider.enabled = !this.boxCollider.enabled;
        } **/
    }
    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<AI_Script>().takeDamage(1);
        }
    }

    // Start is called before the first frame update
}
