using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontuationController : MonoBehaviour {

	//pontuation
	public UnityEngine.UI.Text score;
	public static int pontuation = 0;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("video")==1) {// ele assistiu
			pontuation = PlayerPrefs.GetInt("pontuation");
			PlayerPrefs.SetInt ("video", 0);
			Time.timeScale = PlayerPrefs.GetFloat ("velocidade");		
		}else{
		//toda vez que o jogo começar ela recebe 0
			PlayerPrefs.SetInt("pontuation", 0);
			pontuation = 0;
			PlayerPrefs.SetInt("video",0);
			Time.timeScale = 1f;
		}			
	    //PlayerPrefs.SetInt("record", 0);
		GameObject tran = GameObject.Find ("transition") as GameObject;
		tran.GetComponent<Transition> ().transition ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = pontuation.ToString ();
	}

	public static void  CheckPontuation(){
		PlayerPrefs.SetInt("pontuation", pontuation);
		//
		if(pontuationController.pontuation > PlayerPrefs.GetInt("record")){
			PlayerPrefs.SetInt("record", pontuationController.pontuation);	

		}	
		Debug.Log ("Salvei a veloci");
		PlayerPrefs.SetFloat ("velocidade",Time.timeScale);
	}
}
