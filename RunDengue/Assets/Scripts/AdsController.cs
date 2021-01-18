using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public class AdsController : MonoBehaviour {

	public static AdsController instancia;
	// Use this for initialization
	void Awake () {
		

		if (instancia == null) {
			instancia = this;
		} else {
			Destroy (instancia);
		}
		DontDestroyOnLoad(instancia);

	}
	void Start(){

		//Advertisement.Initialize ("2825519", true);
		Advertisement.Initialize ("2823805", false);
	}
	public bool estaPronto(){
		if (Advertisement.IsReady ()) {
			return true;
		} else {
			return false;
		}
	}


	public void Mostrevideo(){
		
		Debug.Log ("Aguardadando");
		if (Advertisement.IsReady ()) {
			Debug.Log ("Está prontinho");
			Advertisement.Show ("video");
		} else {
			Debug.Log ("não esta pronto");
		}				
	}

	public void MostrevideoPremiado (){
		
		if (Advertisement.IsReady ()) {
			Debug.Log ("Está prontinho");
			ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show ("rewardedVideo", options);
		} else {
			GameObject.FindWithTag ("butao").SetActive(false);
			//GameObject.FindWithTag ("butao").GetComponentInChildren<UnityEngine.UI.Text>().text = "Carregando" ;
		}
	}
		
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			PlayerPrefs.SetInt ("video", 1);
			SceneManager.LoadScene ("Main");
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			PlayerPrefs.SetInt ("video", 0);
			break;
		case ShowResult.Failed:
			Debug.Log ("The ad failed to be shown.");
			GameObject.FindWithTag ("butao").GetComponentInChildren<UnityEngine.UI.Text>().text = "Desconectado" ;
			break;
		}
	}


}
