﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Creditos : MonoBehaviour {

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
