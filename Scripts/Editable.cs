using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editable : MonoBehaviour
{
    public bool Clicked;
    private SpriteRenderer color;
    public Slider scale;

    void Start()
    {
        color = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Clicked == true)
        {
            color.color = new Color(0, 255, 0);
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1, this.gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 1, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 1, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }
        }
        else
        {
            color.color = new Color(0, 0, 0);
        }
    }

    private void OnMouseDown()
    {
        Clicked = !Clicked;
    }

    public void Size(float input)
    {
        float scale = input;
        this.gameObject.transform.localScale = new Vector3(scale * 10, scale * 10, scale * 10);
    }
}
