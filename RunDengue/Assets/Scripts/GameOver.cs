using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public UnityEngine.UI.Text pontos;
	public UnityEngine.UI.Text record;

	// Use this for initialization
	void Start () {
		pontos.text = PlayerPrefs.GetInt ("pontuation").ToString();
		record.text = PlayerPrefs.GetInt ("record").ToString ();

	}


	public void PlayAgain(){
		PlayerPrefs.SetInt("pontuation", 0);
		SceneManager.LoadScene ("Loading");
	}
		
	public void GoToMenu(){
		PlayerPrefs.SetInt("pontuation", 0);
		SceneManager.LoadScene ("Begin");
	}

	void Update() {
		//PARA SAIR
		if (Input.GetKey("escape"))
			Application.Quit();

	}

	

}
