using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour {

	void Start(){
		Time.timeScale = 1f;
	}



	public void chamaGo(){	
		Invoke ("GoToMenu", 0.2f);
	}

	public void GoToMenu(){
		SceneManager.LoadScene ("Begin");
	}

	void Update() {
		//PARA SAIR
		if (Input.GetKey("escape"))
			Application.Quit();
		
	}



}
