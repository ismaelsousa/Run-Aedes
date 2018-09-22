using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	//objeto que vai ser Spawnado
	public GameObject mosquito;
	public GameObject balde;
	public GameObject pneu;
	public GameObject garrafa;
	//intervalo que vai ser criado
	public float rateSpawn; 
	//posicao para criar o objeto
	float posicao;
	float y;
	//vai receber as posições para ser criado o mosquito
	public float posA;
	public float posB;
	public float posC;
	public float posD;


	public float currenteTime;
	// Use this for initialization
	void Start () {
		currenteTime = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {		
		//atualiza o tempo para que o objeto(mosquito) possa ser criado
		currenteTime += Time.deltaTime;


		if (currenteTime >= rateSpawn) {


			
			posicao = Random.Range (1, 100);

			if (posicao > 75 && pontuationController.pontuation >=0) {
				y = posA;
				//cria novo objeto
				GameObject tempPrefab = Instantiate (mosquito) as GameObject; 
				//pega o objeto criado e coloca ele no local que esta o spawn
				tempPrefab.transform.position = new Vector3 (transform.position.x, y, transform.position.z);

			} else if (posicao <= 75 && posicao >= 50 && pontuationController.pontuation >= 0) {
				y = posB;
				//cria novo objeto
				GameObject tempPrefab = Instantiate (mosquito) as GameObject; 
				//pega o objeto criado e coloca ele no local que esta o spawn
				tempPrefab.transform.position = new Vector3 (transform.position.x, y, transform.position.z);

			} else if (posicao >= 1 && posicao <= 15 && pontuationController.pontuation >= 7) {
				y = posC;
				//cria novo objeto
				GameObject tempPrefab = Instantiate (balde) as GameObject; 
				//pega o objeto criado e coloca ele no local que esta o spawn
				tempPrefab.transform.position = new Vector3 (transform.position.x, y, transform.position.z);

			} else if (posicao > 15 && posicao <= 40 && pontuationController.pontuation >= 30) {
				y = posD;
				//cria novo objeto
				GameObject tempPrefab = Instantiate (pneu) as GameObject; 
				//pega o objeto criado e coloca ele no local que esta o spawn
				tempPrefab.transform.position = new Vector3 (transform.position.x, y, transform.position.z);

			} else if (posicao > 40 && posicao < 50 && pontuationController.pontuation >=  12) {
				y = posC;
				//cria novo objeto
				GameObject tempPrefab = Instantiate (garrafa) as GameObject; 
				//pega o objeto criado e coloca ele no local que esta o spawn
				tempPrefab.transform.position = new Vector3 (transform.position.x, y, transform.position.z);
			}



			//zera o tempo
			currenteTime = 0f;




		}
		
	}
}
