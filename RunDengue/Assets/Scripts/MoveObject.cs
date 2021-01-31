using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObject : MonoBehaviour {
	private float max= 1.25f;
	private bool subindo = true;
	//public GameObject Load;

	//criar um componente de audio
	//pega um script do gerenciador e a partir disso posso solicitar para tocar 
	//public AudioManager audioManagerScenes;

	//usado para mover
	public float speed;
	private float x;


	//pega o objeto player na cena
	public GameObject player;
	//public GameObject Gameaudio;


	//uso para não continuar add pontos
	private bool pontuado;


	// Use this for initialization
	void Start () {
		//pega o objeto player
		player = GameObject.Find ("Player") as GameObject;
		//Gameaudio = GameObject.Find ("audioManager") as GameObject;
		//audioManagerScenes = Gameaudio.GetComponent<AudioManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		x = transform.position.x;

		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= -7) {
			Destroy (transform.gameObject);
		}

		if (x < player.transform.position.x && pontuado == false) {
			pontuado = true;
			//add pontos
			pontuationController.pontuation += 1;
			pontuationController.pontuationToQuestion += 1;
		}
	}

	/*/função para verificar colisão
	void OnTriggerEnter2D(Collider2D outher){		
		//se colidir com player morreu
		if(outher.tag == "Player"){		
			audioManagerScenes.PlayErr();

			//changer color after die
			player.GetComponent<SpriteRenderer> ().color = new Color (255f, 0f, 0f,255f);
			pontuationController.CheckPontuation ();

			SceneManager.LoadScene("lost");



			/*PlayerPrefs.SetInt("pontuation", pontuationController.pontuation);
			//
			if(pontuationController.pontuation > PlayerPrefs.GetInt("record")){
				PlayerPrefs.SetInt("record", pontuationController.pontuation);	
			}

	 	}



	}*/


}

