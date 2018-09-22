using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Begin : MonoBehaviour {

	public GameObject load;



	public void loadMain(){
		SceneManager.LoadScene ("Loading");
	}

	//load scene curiosity
	public void loadCuriosity(){
		SceneManager.LoadScene ("Curiosidade");
	}

	//Load scene credits
	public void loadCredits(){
		SceneManager.LoadScene ("Creditos");
	}

	//Load scene credits
	public void loadTutorial(){
		GameObject tempPrefab = Instantiate (load) as GameObject;
		SceneManager.LoadScene ("Tutorial");
	}


	void Update() {
		//PARA SAIR
		if (Input.GetKey("escape"))
			Application.Quit();
	}

}
