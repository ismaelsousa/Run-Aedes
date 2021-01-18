using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontuationController : MonoBehaviour {

	//pontuation
	public UnityEngine.UI.Text score;
	public static int pontuation = 0;
	public static int pontuationToQuestion = 0;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("video")==1) {// ele assistiu
			pontuation = PlayerPrefs.GetInt("pontuation");
			PlayerPrefs.SetInt ("video", 0);
			Time.timeScale = PlayerPrefs.GetFloat ("velocidade");		
			Time.timeScale = 1f;	
		}else{
		//toda vez que o jogo começar ela recebe 0
			PlayerPrefs.SetInt("pontuation", 0);
			pontuation = 0;
			pontuationToQuestion = 0;
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
		if(pontuationToQuestion>=10){
				pontuationToQuestion = 0;
				Debug.Log("Fez 10 ponto, Criar popup para perguntas");
				// Time.timeScale = 0f;

		}
	}

	public static void  CheckPontuation(){
		PlayerPrefs.SetInt("pontuation", pontuation);
		//
		if(pontuationController.pontuation > PlayerPrefs.GetInt("record")){
			PlayerPrefs.SetInt("record", pontuationController.pontuation);	

		}	
		PlayerPrefs.SetFloat ("velocidade",Time.timeScale);
	}
}
