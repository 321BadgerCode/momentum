using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    private GameObject SceneManager;
    private Actor actor;
    public GameObject Object;
    public GameObject Square;
    //public GameObject[] EDITOR;
    //public SimpleMove editor;

    private Vector3 ObjectPos;
    private Vector3 ObjectScale;

    void Start()
    {
        //Defaults
        ObjectPos = Object.transform.position;
        ObjectScale = Object.transform.localScale;
        //SceneManager
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        actor = SceneManager.GetComponent<Actor>();
        //Editor
        /*EDITOR = GameObject.FindGameObjectsWithTag("Editor");
        //Simple Move
        for (int i = 0; i < EDITOR.Length; i++)
        {
            editor = EDITOR[i].AddComponent<SimpleMove>();
        }*/
    }


    void Update()
    {
        
    }

    public void Add()
    {
        Instantiate(Square, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void Default()
    {
        Object.transform.position = (ObjectPos);
        Object.transform.localScale = (ObjectScale);
    }

    public void Scale(float input)
    {
        float scale = input;
        Object.transform.localScale = new Vector3(scale * 10, scale * 10, scale * 10);
    }
}
