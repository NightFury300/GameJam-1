﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("HI0;");
            Application.Quit();
        }
    }
}
