using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChange : MonoBehaviour
{
    //Paused
    private PauseMenu pause;
    private GameObject sceneManager;
    private PlatformChange change;
    private bool Bool;
    //Dead
    [Header("Player Death:")]
    [Tooltip("Player character")] public GameObject Player;
    [Tooltip("Script for player death")] public Death death;

    //Platform
    [Header("Platform Stuff:")]
    [Tooltip("Platform")]public GameObject Platform;
    [Tooltip("Platform's collider")] public Collider2D box;
    [Tooltip("Platform's rigidbody2D")] public Rigidbody2D rb;
    [Tooltip("Check if your platform has physics/rigidbody2D")] public bool physics;
    [Tooltip("Type values for physics here:")] public List<float> physicValues;
    [Tooltip("Specify the number that you want to use(1:Disable this object when done, 2:Make object disappear when done)")] public int disable;
    [Tooltip("Specify the amount of time that will go on before this object gets disabled")] public float disableTime;
    [Tooltip("Check if you want reset timer when max value has been reached")] public bool resetTimer;
    [Tooltip("Check if you want reset the color of the platform when respawned")] public bool resetColor;
    [Tooltip("Check if you want reset the rotation of the platform when respawned")] public bool resetRotation;
    [Tooltip("Check if you want to keep collision detected when respawning")] public bool STOP;
    [Tooltip("Check if you want to reset the properties of the platform when respawned")] public bool resetProperties;
    private float count;
    private bool collision;

    //Move
    [Header("Move:")]
    [Tooltip("Platform to move")] public GameObject Move;
    [Tooltip("Speed of platform's movement")] public float speed;
    [Tooltip("Check if you want to have the gameobject be itself")] public bool This = false;
    [Tooltip("Check if you want to have the gameobject move when touched")] public bool OnTouch = false;
    [Tooltip("Check if you want to have the gameobject to move when the delay is finished")] public bool delay = false;
    [Tooltip("Time of delay")] public float Delay;
    [Tooltip("The delay will wait for as long as the max value")] public float Max;
    [Tooltip("Checks if object has been collided with")] public bool Compared;
    [Tooltip("Check if you want to have the gameobject stop performing the action when the player has stopped colliding with it")] public bool StopWhenOff;
    [Tooltip("Decides where platform moves to")]public Vector3 PlatformMove;

    [Space(10)]

    //Rotation
    [Header("Rotation:")]
    [Tooltip("Platform to rotate")] public GameObject Rotate;
    [Tooltip("Speed of platform's rotation")] public float speed2;
    [Tooltip("Check if you want to have the gameobject be itself")] public bool This2 = false;
    [Tooltip("Check if you want to have the gameobject rotate when touched")] public bool OnTouch2 = false;
    [Tooltip("Check if you want to have the gameobject to rotate when the delay is finished")] public bool delay2 = false;
    [Tooltip("Time of delay")] public float Delay2;
    [Tooltip("The delay will wait for as long as the max value")] public float Max2;
    [Tooltip("Checks if object has been collided with")] public bool Compared2;
    [Tooltip("Check if you want to have the gameobject stop performing the action when the player has stopped colliding with it")] public bool StopWhenOff2;
    [Tooltip("Decides the rotating values for the platform")] public Vector3 PlatformRotate;

    [Space(10)]

    //Color
    [Header("Color:")]
    [Tooltip("Platform to change color")] public SpriteRenderer Color;
    [Tooltip("Check if you want to have the gameobject be itself")] public bool This3 = false;
    [Tooltip("Check if you want to have the gameobject change color when touched")] public bool OnTouch3 = false;
    [Tooltip("Check if you want to have the gameobject change color when the delay is finished")] public bool delay3 = false;
    [Tooltip("Time of delay")] public float Delay3;
    [Tooltip("The delay will wait for as long as the max value")] public float Max3;
    [Tooltip("Checks if object has been collided with")] public bool Compared3;
    [Tooltip("Check if you want to have the gameobject stop performing the action when the player has stopped colliding with it")] public bool StopWhenOff3;
    [Tooltip("Color to replace platform's previous color")] public Color color;

    private Vector3 DEFAULT;
    private Vector3 DEFAULT2;
    private Color DEFAULT3;

    void Start()
    {
        //Pause
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        pause = sceneManager.GetComponent<PauseMenu>();
        //Player
        Player = GameObject.FindGameObjectWithTag("Player");
        //Dead
        death = Player.GetComponent<Death>();
        //Platform Stuff
        Platform = this.gameObject;
        box = Platform.GetComponent<Collider2D>();
        change = Platform.GetComponent<PlatformChange>();
        if (physics == true)
        {
            rb = Platform.AddComponent<Rigidbody2D>();
            rb.mass = physicValues[0];
            rb.angularDrag = physicValues[1];
            rb.gravityScale = physicValues[2];
        }
        DEFAULT = this.transform.position;
        DEFAULT2 = new Vector3(0, 0, 0);
        DEFAULT3 = new Color(0f, 0f, 0f);
        DEFAULT3.a = 255f;
        //Move
        if (This == true)
        {
            Move = Platform;
        }
        //Rotate
        if (This2 == true)
        {
            Rotate = Platform;
        }
        //Color
        if (This3 == true)
        {
            Color = Platform.GetComponent<SpriteRenderer>();
        }
        if (color.a <= 0f)
        {
            color.a = 255f;
        }
    }

    void Update()
    {
        //Paused
        if (pause.paused == true)
        {
            Bool = true;
        }
        else if (pause.paused == false)
        {
            Bool = false;
        }
        if (Bool == false)
        {
            //Dead
            if (death.dead == true)
            {
                //Resests position
                this.transform.position = (DEFAULT);
                //Resests rotation
                if (resetProperties == true || resetRotation == true)
                {
                    Player.transform.rotation = Quaternion.identity;
                }
                //Resests Velocity
                if (physics == true)
                {
                    rb.velocity = new Vector2(0, 0);
                }
                //Resets Delays
                Delay = 0f;
                Delay2 = 0f;
                Delay3 = 0f;
                //Changes booleans to be inactive
                if (STOP == false)
                {
                    Compared = false;
                    Compared2 = false;
                    Compared3 = false;
                }
                //Changes color back to default
                if (resetProperties == true || resetColor == true)
                {
                    Color.color = (DEFAULT3);
                }
            }

            //Collision
            if (Compared == true || Compared2 == true || Compared3 == true)
            {
                if (disable == 1)
                {
                    collision = true;
                    if (count >= disableTime)
                    {
                        this.gameObject.SetActive(false);
                    }
                }
                else if (disable == 2)
                {
                    collision = true;
                    if (count >= disableTime)
                    {
                        color.a = 0f;
                        box.enabled = false;
                    }
                }
            }
            if (collision == true)
            {
                count += Time.deltaTime;
            }

            //Move delay
            if (delay == true)
            {
                if (OnTouch == true && Compared == true)
                {
                    Delay += Time.deltaTime;
                }
                else if (OnTouch == false)
                {
                    Delay += Time.deltaTime;
                }

                if (Delay >= Max)
                {
                    Move.transform.Translate(PlatformMove * speed);
                }

                if (Delay >= Max * 2 && resetTimer == true || Delay >= Max * 2 && resetProperties == true)
                {
                    Delay = 0f;
                }
            }

            //Rotate delay
            if (delay2 == true)
            {
                if (OnTouch2 == true && Compared2 == true)
                {
                    Delay2 += Time.deltaTime;
                }
                else if (OnTouch2 == false)
                {
                    Delay2 += Time.deltaTime;
                }

                if (Delay2 >= Max2)
                {
                    Rotate.transform.Rotate(PlatformRotate * speed);
                }

                if (Delay2 >= Max2 * 2 && resetTimer == true || Delay2 >= Max2 * 2 && resetProperties == true)
                {
                    Delay2 = 0f;
                }
            }

            //Color delay
            if (delay3 == true)
            {
                if (OnTouch3 == true && Compared3 == true)
                {
                    Delay3 += Time.deltaTime;
                }
                else if (OnTouch3 == false)
                {
                    Delay3 += Time.deltaTime;
                }

                if (Delay3 >= Max3)
                {
                    Color.color = (color);

                }

                if (Delay3 >= Max3 * 2 && resetTimer == true || Delay3 >= Max3 * 2 && resetProperties == true)
                {
                    Delay3 = 0f;
                }
            }

            //Move
            if (delay == false)
            {
                if (This == true || OnTouch == true || Compared == true || StopWhenOff == true)
                {
                    if (OnTouch == false)
                    {
                        Move.transform.Translate(PlatformMove * speed);
                    }

                    if (Compared == true)
                    {
                        Move.transform.Translate(PlatformMove * speed);
                    }
                }
            }
            //Rotate
            if (delay2 == false)
            {
                if (This2 == true || OnTouch2 == true || Compared2 == true || StopWhenOff2 == true)
                {
                    if (OnTouch2 == false)
                    {
                        Rotate.transform.Rotate(PlatformRotate * speed);
                    }

                    if (Compared == true)
                    {
                        Rotate.transform.Rotate(PlatformRotate * speed);
                    }
                }
            }
            //Color
            if (delay3 == false)
            {
                if (OnTouch3 == false)
                {
                    Color.color = (color);
                }

                if (Compared3 == true)
                {
                    Color.color = (color);
                }

                if (StopWhenOff3 == true && Compared3 == false)
                {
                    Color.color = (DEFAULT3);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Move
        if (OnTouch == true)
        {
            if (collision.CompareTag("Player"))
            {
                Compared = true;
            }
        }
        //Rotate
        if (OnTouch2 == true)
        {
            if (collision.CompareTag("Player"))
            {
                Compared2 = true;
            }
        }
        //Color
        if (OnTouch3 == true)
        {
            if (collision.CompareTag("Player"))
            {
                Compared3 = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Move
        if (StopWhenOff == true)
        {
            if (OnTouch == true)
            {
                if (collision.CompareTag("Player"))
                {
                    Compared = false;
                }
            }
        }
        //Rotate
        if (StopWhenOff2 == true)
        {
            if (OnTouch2 == true)
            {
                if (collision.CompareTag("Player"))
                {
                    Compared2 = false;
                }
            }
        }
        //Color
        if (StopWhenOff3 == true)
        {
            if (OnTouch3 == true)
            {
                if (collision.CompareTag("Player"))
                {
                    Compared3 = false;
                }
            }
        }
    }
}
