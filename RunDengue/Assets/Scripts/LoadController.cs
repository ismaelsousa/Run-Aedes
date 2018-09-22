using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Load", 1f);
	}
	
	void Load(){		
			SceneManager.LoadSceneAsync ("Main");
	}
}
