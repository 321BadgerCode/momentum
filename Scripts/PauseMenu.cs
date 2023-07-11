using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Audio
    private AudioManager Audio;

    //Pause Menu
    public GameObject pause;

    [HideInInspector] public bool paused = false;

    void Start()
    {
        //Audio
        Audio = FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        //Shows pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Audio.Play("Pause1");
                Pause();
            }
        }
        if (paused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Audio.Play("Resume1");
        Audio.Captions("Resume");
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Quit()
    {
        //Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = (true);
        Time.timeScale = 1f;
    }
}
