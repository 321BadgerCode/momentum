using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public GameObject particle;
    public Text text;
    public float currency;
    public float Loot;
    public float Chest;

    void Start()
    {
        
    }


    void Update()
    {
        text.text = PlayerPrefs.GetFloat("currency", currency).ToString();
        PlayerPrefs.Save();
    }

    public void OnTriggerEnter2D(Collider2D Collide)
    {
        if (Collide.CompareTag("Loot"))
        {
            //PlayerPrefs.SetFloat("currency", currency += Loot);
            PlayerPrefs.GetFloat("currency", currency += Loot).ToString();
            PlayerPrefs.SetFloat("currency", currency);
            PlayerPrefs.Save();
            GameObject loot = GameObject.FindGameObjectWithTag("Loot");
            Destroy(loot.gameObject);
        }
        if (Collide.CompareTag("Chest"))
        {
            //PlayerPrefs.SetFloat("currency", currency += Chest);
            PlayerPrefs.GetFloat("currency", currency += Chest).ToString();
            PlayerPrefs.SetFloat("currency", currency);
            PlayerPrefs.Save();
            GameObject chest = GameObject.FindGameObjectWithTag("Chest");
            Destroy(chest.gameObject);
            Instantiate(particle, chest.transform.position, transform.transform.rotation);
            Destroy(particle.gameObject);
        }
    }
}
