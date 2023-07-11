using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public GameObject[] powers;
    public Pickup pickup;
    public bool X;
    public float Distance;
    public float Distance2;
    public Vector2 player;
    public Vector2 ENEMY;

    void Start()
    {
        
    }


    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        ENEMY = enemy.transform.position;
        player = Player.transform.position;

        if (X == true)
        {
            if (Input.GetKey(KeyCode.X))
            {
                rb.velocity = Vector2.down;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 20f);
                //rb.gravityScale = 0f;
                Player.transform.Rotate(0, 0, 50);
            }
        }
    }

    public void PowerUps(int power)
    {
        if (power == 0)
        {
            if (pickup.currency >= 1000)
            {
                pickup.currency -= 1000;

                X = true;
            }
            else
            {
                pickup.currency += 100;
            }
        }
    }
}
