using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement move;
    public Rigidbody2D rb;
    public Collider2D box;
    public SpriteRenderer PlayerColor;
    public bool collided;

    GameObject[] water;

    void Start()
    {
        //Player
        Player = GameObject.FindGameObjectWithTag("Player");

        //PlayerMove
        move = Player.GetComponent<PlayerMovement>();

        //Collider
        box = this.gameObject.GetComponent<BoxCollider2D>();

        //SpriteRenderer
        PlayerColor = Player.GetComponent<SpriteRenderer>();
    }

    /*void Update()
    {
        water = GameObject.FindGameObjectsWithTag("Water");

        foreach (GameObject w in water)
        {

        }
    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerColor.color = new Color(0, 255, 255);
            move.rb.gravityScale = .1f;
            move.rb.velocity = rb.velocity = new Vector2(0, 0);
            collided = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            PlayerColor.color = new Color(255, 255, 255);
            move.rb.gravityScale = 1f;
            collided = false;
        }
    }
}
