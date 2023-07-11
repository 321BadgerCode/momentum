using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private GameObject Player;
    private SpriteRenderer player;
    public GameObject Collide;
    public GameObject Gate;
    public GameObject Text;
    public GameObject Child;
    public GameObject Show;
    public GameObject Delete1;
    public GameObject Delete2;
    public GameObject Delete3;
    public Transform Transform;
    public BoxCollider2D Box;
    public BoxCollider2D GATE;
    public Vector3 collide;
    public Vector3 collider;
    public KeyCode Key;
    public string Tag;
    public bool Enter;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<SpriteRenderer>();
        Show.SetActive(false);
    }


    void Update()
    {
        if (collide.x - collider.x >= .05 && collide.y - collider.y >= .05 && collide.x - collider.x <= 2 && collide.y - collider.y <= 2)
        {
            if (Enter == true)
            {
                Show.SetActive(true);

                if (Input.GetKeyDown(Key))
                {
                    Child = transform.Find("Key").gameObject;

                    Destroy(Delete1.gameObject);
                    Destroy(Delete2.gameObject);
                    Destroy(Delete3.gameObject);
                    Destroy(Collide.gameObject);
                    Destroy(Text.gameObject);
                    Destroy(Gate.gameObject);
                    player.color = new Color(255, 255, 255);
                    Enter = false;

                    /*Delete1.SetActive(false);
                    Delete2.SetActive(false);
                    Delete3.SetActive(false);
                    Collide.SetActive(false);
                    Text.SetActive(false);
                    Gate.SetActive(false);
                    Gate.SetActive(false);*/
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (Enter == true)
        {
            Follow();
        }
    }

    public void OnTriggerEnter2D(Collider2D Collide)
    {
        if (Collide.CompareTag(Tag))
        {
            Enter = true;
            player.color = new Color(255, 255, 0);
        }
    }

    public void Follow()
    {
        collide = Collide.transform.position;
        collide.x = Transform.position.x;
        collide.y = Transform.position.y + 2f;
        Collide.transform.position = collide;
    }
}
