using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePopUp : MonoBehaviour {
	public float speed;
	public float poseDestroy;
	private float y;
	bool verify = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.localScale = new Vector3 (2f, 2f, 2f);
		y = transform.position.y;

		y += speed * Time.deltaTime;
		transform.position = new Vector3 (transform.position.x, y, transform.position.z);

		if (y > poseDestroy) {
			Destroy (transform.gameObject);
		}

		if (verify) {
			StartCoroutine ("treme");
			StartCoroutine ("scale");
			verify = false;
		}

	}

	IEnumerator scale() {
		for (float i = 0f; i < 1.6f; i += 0.1f) {
			transform.localScale = new Vector3 (i, i, i);
			yield return new WaitForSeconds (0.05f);
		}
	}

	IEnumerator treme() 
	{
		while (true) {
			for (float i = 1f; i < 5; i += 1f) {			
				transform.Rotate (0, 0, 1); 
				yield return new WaitForSeconds (0.05f);
			}

			for (float i = 5f; i > -5; i -= 1f) {
				transform.Rotate (0, 0, -1); 
				yield return new WaitForSeconds (0.05f);
			}
			for (float i = -4f; i < 2; i += 1f) {			
				transform.Rotate (0, 0, 1); 
				yield return new WaitForSeconds (0.05f);
			}		
			//yield return new WaitForSeconds (1f);

		}

	}

}
