using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    private int amount = 0;
    public int Amount = 0;
    private float timer;
    public float Max;
    public GameObject Load;

    public void Start()
    {
        //Amount = PlayerPrefs.GetInt("amount", amount);
        if (Amount == 0)
        {
            Load.SetActive(false);
            Amount++;
        }
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Max)
        {
            Load.SetActive(true);
        }
    }
}
