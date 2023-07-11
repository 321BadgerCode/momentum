using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Boss boss;
    public int number;
    public int i;
    public bool loop;
    public GameObject[] Editor;
    public SimpleMove editor;
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;

    /*public GameObject[] Square;
    public GameObject[] Triangle;
    public GameObject[] Circle;*/

    void Start()
    {
        Time.timeScale = 1f;
        Editor = GameObject.FindGameObjectsWithTag("Editor");
        //Simple Move
        for (i = 0; i < Editor.Length; i++)
        {
            editor = Editor[i].AddComponent<SimpleMove>();
        }
    }


    void Update()
    {
        /*if (loop == false) {
            for (int a = 0; a < Square.Length; a++)
            {
                Square[a] = square;
            }
            for (int b = 0; b < Triangle.Length; b++)
            {
                Triangle[b] = triangle;
            }
            for (int c = 0; c < Circle.Length; c++)
            {
                Circle[c] = circle;
            }
        }
        loop = true;*/
    }
}
