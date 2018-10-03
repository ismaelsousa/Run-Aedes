using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Begin : MonoBehaviour {

	public GameObject load;
	public GameObject botoes;
	void Start(){
			//PlayerPrefs.SetInt("pontuacao", 0);
			//PlayerPrefs.SetInt("record", 0);
		    //PlayerPrefs.SetInt ("video", 0);
		Time.timeScale = 1f;
	}

	public void loadMain(){
		SceneManager.LoadScene ("Loading");
	}
	public void Exit(){
		Application.Quit();
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
		botoes.SetActive (false);
		SceneManager.LoadSceneAsync ("Tutorial");
	}


	void Update() {
		//PARA SAIR
		if (Input.GetKey("escape"))
			Application.Quit();
	}

}
