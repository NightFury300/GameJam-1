using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Player"){
            {
                FindObjectOfType<AudioManager>().Play("levelclear");
                if(SceneManager.GetActiveScene().buildIndex == 3)
                {
                    SceneManager.LoadScene(0);
                    return;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
		}
	}
}
