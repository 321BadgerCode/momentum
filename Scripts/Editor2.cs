using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor2 : MonoBehaviour
{
    private GameObject SceneManager;
    private InputSpawnPlayer spawn;
    private GameObject Object;
    private SpriteRenderer color;
    private Color color2;
    private bool Bool;

    void Start()
    {
        //This gameObject
        Object = this.gameObject;
        color = Object.GetComponent<SpriteRenderer>();
        color2 = new Color(0, 0, 0);
        color2.a = 255f;

        //Spawn
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        spawn = SceneManager.GetComponent<InputSpawnPlayer>();
    }

    
    void Update()
    {
        if (spawn.play == true && Object.tag != ("Platform"))
        {
            Bool = true;
        }
        if (Bool == true)
        {
            Object.SetActive(false);
            Object.transform.localScale = new Vector3(1.2f, 1.4f, 1f);
        }
    }

    void OnMouseDown()
    {
        Object.tag = ("Platform");
        Object.AddComponent<BoxCollider2D>();
        color.color = color2;
        Object.transform.localScale = new Vector3(1.2f, 1f, 1f);
    }
}
