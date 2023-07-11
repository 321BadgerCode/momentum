using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public GameObject Object;
    public SpriteRenderer Object2;
    public GameObject Player;
    public bool Bool;
    public bool time;
    public float Timer;

    public Cursor cursor;

    void Start()
    {
        Object = this.gameObject;
        Object2 = Object.GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Object2.color = new Color(90, 255, 0);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(Object, Player.transform.position, Quaternion.identity);
        }
        if (Object != null && Bool == false && Object2.color == new Color(90, 255, 0))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Object.transform.Translate(0, 2, 0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Object.transform.Translate(0, -2, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Object.transform.Translate(-2, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Object.transform.Translate(2, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bool = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            time = true;
        }
        if (time == true)
        {
            Timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Bool = false;
            }
        }
        if (Timer >= .5f)
        {
            Timer = 0;
            time = false;
        }

        if (Bool == true)
        {
            Object2.color = new Color(255, 255, 255);
        }
    }
}
