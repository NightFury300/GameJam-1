using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public int CurrentLevel = 1;
	void OnTriggerEnter2D (Collider2D col){
		if(col.tag == "Player"){
			switch(CurrentLevel){
			case 1:
            FindObjectOfType<AudioManager>().Play("levelclear");
		SceneManager.LoadScene ("Level_2");
			CurrentLevel++;
				break;
			case 2:
				FindObjectOfType<AudioManager>().Play("levelclear");
				SceneManager.LoadScene ("Level_3");
				CurrentLevel++;
				break;
			}
		}
	}
}
