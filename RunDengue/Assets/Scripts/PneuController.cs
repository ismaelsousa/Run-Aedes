using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PneuController : MonoBehaviour {
	public Transform transformes;
	public float speedGiro;
	public Rigidbody2D rigid;
	public CircleCollider2D colider;
	
	// Update is called once per frame

	//usado para mover
	public float speed;
	public float forcaColisao;
	private float x;

	//verifica se já contou
	private bool contou;

	// Update is called once per frame
	void Update () {
		//faz o pneu girar
		transformes.Rotate(0, 0, Time.deltaTime*speedGiro);

		//pega a posicao de x
		x = transform.position.x;

		//incrementa x
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		//verifica se saiu da tela e destroi
		if (x <= -7 || transformes.position.y < -4) {
			Destroy (transform.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D outher){
		if (outher.tag == "Player"&& contou == false) {
			pontuationController.pontuation -= 3;
			contou = true;
			rigid.AddForce(new Vector2(forcaColisao, 400));
			rigid.bodyType = RigidbodyType2D.Dynamic;
			colider.enabled = false;
		}
	}



}
