using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Player"){
		SceneManager.LoadScene ("Level_2");
		}
	}
}
