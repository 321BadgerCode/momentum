using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    //Audio
    private AudioManager audio;
    private float timez = 0f;
    private bool time = false;

    public Death death;
    public GameObject player;
    public BoxCollider2D Player;
    public GameObject CAMERA;
    public BoxCollider2D box;
    public Camera C;
    public GameObject Move;
    public Transform Target;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject[] stopfollow;
    public float speed;
    public Vector3 position;
    public Vector3 position2;
    public float zoom;
    public bool In;
    public bool Enter;
    public bool follow;
    public bool StopFollow;
    public bool MultipleUse;
    public bool move;
    public bool dead;
    public bool shake;
    public bool checkpoint;
    public bool checkpoint_checked;
    public bool SpawnEnemy;
    public float ShakeX;
    public float Shakey;
    public float timer;
    public float Shake;

    [System.Serializable]
    public class AudioClip
    {
        public bool AddAudio;
        public string audioName;
        public string caption;
    }

    public AudioClip audioClip;

    public Vector3 ShakeC;

    private Vector3 pos;

    private bool follows;
    private bool followz;

    void Start()
    {
        //Audio
        audio = FindObjectOfType<AudioManager>();
        position.z = -10;
        box = this.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Player = player.GetComponent<BoxCollider2D>();
        stopfollow = GameObject.FindGameObjectsWithTag("Follow");
        if (follow == true)
        {
            follows = true;
        }
    }

    private void LateUpdate()
    {
        if (follow == true && Enter == true)
        {
            Follow();
        }
    }

    public void Update()
    {
        //Audio
        if (time == true)
        {
            timez += Time.deltaTime;
        }
        if (timez >= 3)
        {
            audio.Captions("");
            time = false;
            timez = 0f;
        }
        //StopFollow
        if (this.gameObject.tag == ("Follow"))
        {
            Enter = false;
            follow = true;
        }
        if (followz == true)
        {
            for (int i = 0; i < stopfollow.Length; i++)
            {
                stopfollow[i].tag = ("Follow");
                followz = false;
            }
        }
        if (follows == true)
        {
            this.transform.name = ("Follow");
        }
        else
        {
            this.transform.name = ("Trigger");
        }

        if (this.gameObject.tag == ("Trigger"))
        {
            if (dead == true)
            {
                follow = false;
            }
        }

        if (box.CompareTag("Player"))
        {
            if (shake == true)
            {
                ScreenShake();
            }
        }
        //Checkpoint:
        if (checkpoint == true)
        {
            MultipleUse = true;
        }
        if (checkpoint == true)
        {
            if (Enter == true)
            {
                checkpoint_checked = true;
            }
        }
        //Death detection:
        if (death.dead == true)
        {
            dead = true;
            if (followz == true)
            {
                followz = false;
            }
        }
        if (timer >= 3)
        {
            timer = 0f;
            dead = false;
            Checkpoint();
            if (follows == true)
            {
                this.gameObject.tag = ("Follow");
            }
        }
        if (dead == true)
        {
            if (timer <= 3)
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (In == true)
        {
            if (follow == true)
            {
                this.gameObject.tag = ("Trigger");
            }
        }
        if (In == true)
        {
            if (collision.CompareTag("Player"))
            {
                Enter = true;
                CAMERA.transform.position = (position);
                Zoom();
                ScreenShake();
                if (audioClip.AddAudio == true)
                {
                    Audio();
                }
                if (move == true)
                {
                    Moves();
                }
                if (collision.CompareTag("Follow"))
                {
                    follow = true;
                }
                if (follow == true)
                {
                    Follow();
                }
                else if (StopFollow == true)
                {
                    followz = true;
                }
                if (MultipleUse == false)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (In == false)
        {
            if (follow == true)
            {
                this.gameObject.tag = ("Trigger");
            }
        }
        if (In == false)
        {
            if (collision.CompareTag("Player"))
            {
                Enter = false;
                CAMERA.transform.position = (position);
                Zoom();
                ScreenShake();
                if (audioClip.AddAudio == true)
                {
                    Audio();
                }
                if (move == true)
                {
                    Moves();
                }
                if (collision.CompareTag("Follow"))
                {
                    follow = true;
                }
                if (follow == true)
                {
                    Follow();
                }
                else if (StopFollow == true)
                {
                    followz = true;
                }
                if (MultipleUse == false)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void Zoom()
    {
        C.fieldOfView = Mathf.Lerp(C.fieldOfView, zoom, zoom);
    }

    public void Moves()
    {
        Move.transform.position = (position2);
    }

    public void Follow()
    {
        if (follow == true)
        {
            pos = CAMERA.transform.position;
            pos.x = Target.position.x;
            pos.y = Target.position.y;
            CAMERA.transform.position = pos;
        }
    }

    public void ScreenShake()
    {
        if (shake == true)
        {
            float ShakeX = Random.value * Shake;
            float Shakey = Random.value * Shake;
            CAMERA.transform.position = new Vector3(ShakeX, Shakey, position.z);
            ShakeC = CAMERA.transform.position;
}
    }

    public void Checkpoint()
    {
        if (checkpoint == true)
        {
            if (Enter == true)
            {
                Player.transform.position = (this.transform.position);
            }
        }
    }

    public void Audio()
    {
        time = true;
        audio.Play(audioClip.audioName);
        audio.Captions(audioClip.caption);
    }

    public void EnemySpawn()
    {
        if (SpawnEnemy == true)
        {
            if (Enter == true)
            {
                
            }
        }
    }
}
