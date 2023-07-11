using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public BoxCollider2D box;
    public Rigidbody2D rb;
    public GameObject particle;
    public GameObject particle2;
    public float X;
    public float dampX;
    public float JumpHeight;
    public float jumpForce;
    public float jumps;
    private float jumps2;
    public bool jump;
    public bool grounded;

    public float timer;  

    public Vector3 temp;

    void Start()
    {
        jumps2 = jumps;
    }

    void Update()
    {
        //timer += Time.deltaTime;

        X = rb.velocity.x;
        X += Input.GetAxisRaw("Horizontal");
        X *= Mathf.Pow(1f - dampX, Time.deltaTime * 10f);
        rb.velocity = new Vector2(X, rb.velocity.y);

        if (jumps >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                jumps--;
                jump = true;

                Instantiate(particle, transform.transform.position, transform.transform.rotation);
                Destroy(particle.gameObject);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.velocity.y >= 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * JumpHeight);
                jump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            temp = transform.localScale;
            temp.y = .5f;

            transform.localScale = temp;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            temp = transform.localScale;
            temp.y = 1f;

            transform.localScale = temp;
        }

        if (grounded == false)
        {
            timer += Time.deltaTime;
        }

    }
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.CompareTag("Platform"))
        {
            grounded = true;
            jumps = jumps2;

            if (timer >= 2)
            {
                Instantiate(particle2, transform.transform.position, transform.transform.rotation);
                Destroy(particle2.gameObject);
            }
            timer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D box)
    {
        if (box.CompareTag("Platform"))
        {
            grounded = false;
        }
    }
}
