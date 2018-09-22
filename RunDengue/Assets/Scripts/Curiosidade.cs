using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Curiosidade : MonoBehaviour {

	private int cont = 0;
	public UnityEngine.UI.Text[] placas;
	public SpriteRenderer render;
	public UnityEngine.UI.Text textBoard;
	public GameObject[] lista;
	public GameObject gameObj;

	void Start () {
		//render.sprite = placas [cont];
		//cont++;
		//textBoard.text = placas[cont].text;
		gameObj = Instantiate (lista[cont]) as GameObject; 
		//tempPrefab.transform.position = new Vector3 (gameObj.transform.position.x, gameObj.transform.position.y, gameObj.transform.position.z);
	}
	public void chamaGo(){		
		Invoke ("GoToMenu", 0.1f);
	}
	public void GoToMenu(){
		SceneManager.LoadScene ("Begin");
	}


	public void Next(){
		if (cont == lista.Length - 1) {
			cont = lista.Length - 1;

		} else {
			cont++;

		}
		DestroyObject (gameObj);
		gameObj = Instantiate (lista[cont]) as GameObject; 
//render.sprite = placas [cont];		
	}

	public void Before(){
		if (cont == 0) {
			cont = 0;		
		} else {
			cont--;

		}
		DestroyObject (gameObj);
		gameObj = Instantiate (lista[cont]) as GameObject; 
		//render.sprite = placas [cont];		

		
	}

	void Update() {
		//PARA SAIR
		if (Input.GetKey("escape"))
			Application.Quit();

	}
}
