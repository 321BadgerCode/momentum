using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float time;
    public float number;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            time = number;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (time <= 0)
            {
                effector.rotationalOffset = 180f;
                time = number;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
}
