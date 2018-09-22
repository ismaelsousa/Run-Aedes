using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : MonoBehaviour {
	bool diminui = true;
	public GameObject[] popUp;
	public int pos = 0;

	// Use this for initialization
	void Start () {
		//transform.Rotate (0, 0, -20); 
		//transform.Rotate (0, 0, -20); 
	}
	
	// Update is called once per frame
	void Update () {
		if (diminui) {
			StartCoroutine ("treme");
			diminui = false;		
		}
	}

	IEnumerator treme() 
	{
		while (true) {
			for (float i = 1f; i < 5; i += 1f) {			
				transform.Rotate (0, 0, 1); 
				yield return new WaitForSeconds (0.01f);
			}

			for (float i = 5f; i > -5; i -= 1f) {
				transform.Rotate (0, 0, -1); 
				yield return new WaitForSeconds (0.01f);
			}
			for (float i = -4f; i < 2; i += 1f) {			
				transform.Rotate (0, 0, 1); 
				yield return new WaitForSeconds (0.01f);
			}
			if (pos < popUp.Length) {
				GameObject tempPrefab = Instantiate (popUp [pos]) as GameObject;
				pos++;
			} else {
				pos = 0;
				GameObject tempPrefab = Instantiate (popUp [pos]) as GameObject;
				pos++;
			}
		
			yield return new WaitForSeconds (7f);
		
		}

	}


}
