using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrafaController : MonoBehaviour {
	//pega da garrafa
	public Transform transformes;
	//usado para mover
	public float speed;
	private float x;

	//para n ficar decrementando
	private bool contou;

	// Update is called once per frame
	void Update () {
		x = transform.position.x;

		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= -7) {
			Destroy (transform.gameObject);
		}

	}


	void OnTriggerEnter2D(Collider2D outher){
		if (outher.tag == "Player" && contou == false) {
			transformes.Rotate(0, 0, 180f);
			pontuationController.pontuation += 5;
			contou = true;
		}
	}
}
