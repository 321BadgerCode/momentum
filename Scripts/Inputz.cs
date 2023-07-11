using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputz : MonoBehaviour
{
    private AudioManager Audio;
    private string reply;
    public float TypeSpeed;
    public Text text;
    public InputField input;
    private int letters;

    void Start()
    {
        Audio = GameObject.FindObjectOfType<AudioManager>();
    }

    IEnumerator Type()
    {
        foreach (char letter in reply.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(TypeSpeed);
        }
    }

    public void Click()
    {
        if (input.text == "Who are you" || input.text == "Who are you?" || input.text == "who are you" || input.text == "who are you?")
        {
            reply = " I am an artificial intelligence";
            StartCoroutine(Type());
            Audio.Play("Death1");
            Audio.Captions("I predicted that you would die from that!");
            text.text = "";
        }
        else if (input.text == "Banana" || input.text == "banana")
        {
            reply = " Bananas are cool. Do you agree? I personally like their flavor and texture, do you? Banana banana banana banana banana banana banana banana banana banana!!!...";
            StartCoroutine(Type());
            text.text = "";
        }
    }
}
