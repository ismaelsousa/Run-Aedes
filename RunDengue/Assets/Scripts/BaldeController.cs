using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldeController : MonoBehaviour {

	public Animator anim;

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
			anim.SetBool ("bateu", true);
			pontuationController.pontuation += 3;
			contou = true;
		}
	}
}
