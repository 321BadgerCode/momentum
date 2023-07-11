using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float distanceRay;
    public GameObject enemy;
    public GameObject Player;
    public Transform player;

    public Vector2 ENEMY;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Transform>();
        ENEMY = enemy.transform.position;

        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D check_right = Physics2D.Raycast(transform.position, Vector2.right, distanceRay);
            RaycastHit2D check_left = Physics2D.Raycast(transform.position, Vector2.left, distanceRay);
            if (check_right.collider != null)
            {
                Debug.DrawLine(transform.position, ENEMY, Color.green);
                if (check_right.collider.CompareTag("Enemy"))
                {
                    Destroy(enemy.gameObject);
                }
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * distanceRay, Color.red);
            }
            if (check_left.collider != null)
            {
                Debug.DrawLine(transform.position, ENEMY, Color.green);
                if (check_left.collider.CompareTag("Enemy"))
                {
                    Destroy(enemy.gameObject);
                }
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * distanceRay, Color.red);
            }
        }
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float distanceRay;
    public GameObject enemy;
    public GameObject Player;
    public Transform player;

    public Vector2 ENEMY;
    public Vector2 PLAYER;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<Transform>();

        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            for (int j = 0; j < ENEMY.Length; j++)
            {
                ENEMY[j] = enemy[i].transform.position;
            }
        }
        GroundPound();
    }
    public void GroundPound()
    {
        RaycastHit2D check_right = Physics2D.Raycast(player.position, Vector2.right, distanceRay);
        RaycastHit2D check_left = Physics2D.Raycast(player.position, Vector2.left, distanceRay);
        Debug.DrawLine(player.position, check_right.point, Color.red);
        //Debug.DrawLine(player.position, check_left.point, Color.red);
        Debug.DrawLine(player.position, ENEMY, Color.green);
        Debug.DrawLine(player.position, Vector2.left, Color.blue);
        if (check_right.collider != null)
        {
            Destroy(enemy);
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        /*if (check_left.collider != null)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        if (check_right.collider != null)
        {
            //Debug.DrawLine(transform.position, ENEMY, Color.green);
            if (check_right.collider.CompareTag("Enemy"))
            {
                Destroy(enemy);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, check_right.point, Color.red);
        }
        if (check_left.collider != null)
        {
            //Debug.DrawLine(transform.position, ENEMY, Color.green);
            if (check_left.collider.CompareTag("Enemy"))
            {
                Destroy(enemy);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, check_left.point, Color.red);
        }
    }
}*/

