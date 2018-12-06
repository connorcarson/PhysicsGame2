﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class TinyGameCtrl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey("escape"))
        { 
         Application.Quit();
        }
    }
}