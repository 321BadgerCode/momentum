using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    //Audio
    private AudioManager Audio;
    public Trigger trigger;
    public GameObject Player;
    public Rigidbody2D rb;
    public GameObject CAMERA;
    public Transform Triggers;
    public GameObject Particle;
    public ParticleSystem RespawnParticle;
    public Camera C;
    public Text text;
    public SpriteRenderer player;
    public PlayerMovement move;
    public Transform Pos;
    public BoxCollider2D box;
    public Death death;
    public BoxCollider2D boxer;
    public bool dead = false;
    public bool SpawnStop = false;
    public string Tag;
    public float zoom;
    public bool p;
    public List<GameObject> TypeOfKey;

    public Vector3 position;
    public Vector3 cPosition;
    public Vector2 PLAYER;
    public Vector2 Max;

    [HideInInspector]public float timer;
    [HideInInspector]public float time;
    private Vector3 PlayerSize;
    [SerializeField]private GameObject Key;
    [SerializeField]private Collision collision;

    private void Start()
    {
        //Audio
        Audio = FindObjectOfType<AudioManager>();

        //Position
        position = transform.position;

        //Rigidbody2D
        rb = Player.GetComponent<Rigidbody2D>();

        //Key
        TypeOfKey[0] = GameObject.FindGameObjectWithTag("Key");
        TypeOfKey[1] = GameObject.Find("Key (1)").gameObject;
        Key = TypeOfKey[1];
        collision = Key.GetComponent<Collision>();
    }

    public void LateUpdate()
    {
        // Boundaries
        if (PLAYER.x <= Max.x)
        {
            dead = true;
            player.color = new Color(255, 0, 0);
            move.enabled = false;
        }
        else if (PLAYER.y <= Max.y)
        {
            dead = true;
            player.color = new Color(255, 0, 0);
            move.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D Box)
    {
        //Detects if player collides with enemy
        if (Box.CompareTag(Tag))
        {
            //Add end screen or something here
            dead = true;
            player.color = new Color(255, 0, 0);
            move.enabled = false;
            if (p == false)
            {
                Instantiate(Particle, Player.transform.position, Player.transform.rotation);
                Audio.Play("Death1");
                Audio.Captions("I knew that would happen!");
                p = true;
                Destroy(Particle.gameObject);
            }
        }
    }
    private void Update()
    {

        // Boundaries
        if (PLAYER.x <= Max.x)
        {
            Audio.Play("Death2");
            Audio.Captions("I predicted that you would die from that!");
        }
        else if (PLAYER.y <= Max.y)
        {
            Audio.Play("Death2");
            Audio.Captions("I predicted that you would die from that!");
        }

        PLAYER = (Player.transform.position);

        if (dead == true)
        {

            timer += Time.deltaTime;
            time += Time.deltaTime;

            text.text = time.ToString();

            //Respawn
            if (timer >= 3)
            {
                //Changes Player Size:
                PlayerSize = transform.localScale;
                PlayerSize.y = 1f;

                transform.localScale = PlayerSize;
                //Checkpoint:
                if (trigger.checkpoint_checked == false)
                {
                    Player.transform.position = position;
                }
                //Softens the fall of the player when spawning:
                if (SpawnStop == true)
                {
                    rb.velocity = new Vector2(0, 0);
                }
                //Everything else:
                move.enabled = true;
                player.enabled = true;
                box.enabled = true;
                death.enabled = true;
                dead = false;
                timer = 0;
                text.fontSize = 15;
                time = 0;
                text.text = 0.ToString();
                CAMERA.transform.position = (cPosition);
                Zoom();
                text.fontSize = 48;
                Instantiate(RespawnParticle, Player.transform.position, Player.transform.rotation);
                Destroy(RespawnParticle.gameObject);
                if (collision.Enter == false)
                {
                    player.color = new Color(255, 255, 255);
                }
                else
                {
                    player.color = new Color(255, 255, 0);
                }
                On();
                p = false;
                Audio.Captions("");
            }
        }
    }
    //Specifies zoom of camera when respawnes
    public void Zoom()
    {
        C.fieldOfView = Mathf.Lerp(C.fieldOfView, zoom, zoom);
    }
    //IDK
    public void On()
    {
        if (collision.Enter == false)
        {
            player.color = new Color(255, 255, 255);
        }

        Transform[] children = Triggers.transform.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < children.Length; i++)
        {
            children[i].gameObject.SetActive(true);
        }
    }
}
