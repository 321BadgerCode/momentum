using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Scene Manager
    private GameObject Actor;
    private Actor actor;

    //Boss
    [Header("Boss:")]
    public GameObject BOSS;
    public int bodyParts;
    [Tooltip("Shapes include(Square, Triangle, and Circle)")] public string shape;
    [Tooltip("Shapes include(1:Square, 2:Triangle,3: Circle)")] public string Shapez;
    [Tooltip("Shapes include(1:Square, 2:Triangle,3: Circle)")] public GameObject Shapez2;
    [Tooltip("Shapes include(1:Square, 2:Triangle,3: Circle)")] public SimpleMove s;
    [Tooltip("Shapes include(1:Square, 2:Triangle,3: Circle)")] public bool Shapez3;
    public List<Vector3> body;
    public List<float> BossStages;
    public int Stages;
    public bool Physics;
    [Tooltip("Type values for physics here:")] public List<float> physicValues;

    [Space(5)]

    [Header("Completed:")]
    public List<bool> Completed;

    [Space(5)]

    //Move
    [Header("Boss Move:")]
    public List<Vector3> MoveDistance;
    public List<float> Speed;

    [Space(5)]

    //Timer
    [Header("Timer:")]
    public float Timer;

    [Space(5)]

    //Loop
    public int i;
    public int j;

    //Physics
    private Rigidbody2D rb;

    //Shapes
    private bool Shape = false;
    public GameObject Square;

    void Start()
    {
        //Actor
        Actor = GameObject.FindGameObjectWithTag("SceneManager");
        actor = Actor.GetComponent<Actor>();

        //Shapes
        Square = actor.square;
        Shapez2 = actor.square;

        //Boss is the object with this script
        BOSS = this.gameObject;

        //Boss Components
        if (Physics == true)
        {
            rb = BOSS.AddComponent<Rigidbody2D>();
            rb.mass = physicValues[0];
            rb.angularDrag = physicValues[1];
            rb.gravityScale = physicValues[2];
        }

        //Change all of the lists to have the same length as the 'BossStages'
        i = BossStages.Capacity;
        Completed.Capacity = 3;
        MoveDistance.Capacity = 3;
        Speed.Capacity = 3;
        /*Completed.Capacity = i;
        MoveDistance.Capacity = i;
        Speed.Capacity = i;*/
    }

    void Update()
    {
        //Shape
        /*if (shape == "Square" && Shape == false)
        {
            for (int i = 0; i < bodyParts; i++)
            {
                if (Square != null)
                {
                    Instantiate(Square, BOSS.transform.position, Quaternion.identity);
                }
            }
            for (j = 0; j < body.Capacity; j++)
            {
                Square.transform.position = (body[j]);
            }
            Shape = true;
        }*/

        if (Shapez == "1" && Shapez3 == false)
        {
            if (Shapez2 != null)
            {
                Instantiate(Shapez2.gameObject, BOSS.transform.position, Quaternion.identity);
                Shapez3 = true;
            }
        }

        //Timer
        Timer += Time.deltaTime;

        //Action
        /*if (Completed[0] == false)
        {
            if (Timer >= BossStages[0])
            {
                BOSS.transform.position = (MoveDistance[0] * Speed[0] * Time.deltaTime);
                Completed[0] = true;
            }
        }
        if (Completed[1] == false)
        {
            if (Timer >= BossStages[1])
            {
                BOSS.transform.position = (MoveDistance[1] * Speed[1] * Time.deltaTime);
                Completed[1] = true;
            }
        }
        if (Completed[2] == false)
        {
            if (Timer >= BossStages[2])
            {
                BOSS.transform.position = (MoveDistance[2] * Speed[2] * Time.deltaTime);
                Completed[2] = true;
            }
        }*/
        for (j = 0; j < BossStages.Capacity; j++)
        {
            if (Completed[j] == false)
            {
                if (Timer >= BossStages[j])
                {
                    BOSS.transform.position = (MoveDistance[j] * Speed[i] * Time.deltaTime);
                }
            }
        }
    }
}
