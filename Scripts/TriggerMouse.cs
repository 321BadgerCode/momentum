using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerMouse : MonoBehaviour
{
    
     public void SceneLoader(int scene)
    {
            SceneManager.LoadScene(scene);
    }

}

