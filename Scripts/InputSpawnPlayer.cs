using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSpawnPlayer : MonoBehaviour
{
    //The Legacy Unfolds
    private PauseMenu pause;
    private GameObject Player;
    private SpriteRenderer player;
    private PlayerMovement move;

    public GameObject Menu;
    public bool play;

    void Start()
    {
        //Player
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.GetComponent<SpriteRenderer>();
        move = Player.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Player.SetActive(true);
            player.enabled = true;
            move.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
        }
    }
    public void Play()
    {
        play = true;
    }
}
