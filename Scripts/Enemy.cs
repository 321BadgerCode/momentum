using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Type of enemy(1:Patrolling enemy)")] public int enemyType;
    [Tooltip("Check this if you want to allow the enemy to respawn when player dies")] public bool Respawns;
    public float speed;
    private bool right = true;
    public Transform GroundCheck;

    private GameObject Player;
    private Death death;
    private Vector3 enemyPos;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        death = Player.GetComponent<Death>();
        enemyPos = this.transform.position;
    }

    void Update()
    {
        //Dead
        if (death.dead == true && Respawns == true)
        {
            this.transform.position = (enemyPos);
            right = true;
        }
        if (enemyType == 1)
        {
            PatrolEnemy();
        }
    }
    public void PatrolEnemy()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundCheck.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                right = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                right = true;
            }
        }
    }
}
