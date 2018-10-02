using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {
	public SpriteRenderer backBlack;

	void Start(){
		Time.timeScale = 1f;
	}
	public void transition(){
		Invoke ("isEnable", 0.2f);
	}

	void isEnable(){
		backBlack.enabled = false;
	}
}
