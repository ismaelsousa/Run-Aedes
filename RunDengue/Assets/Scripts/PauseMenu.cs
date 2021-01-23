using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject butaoPause;
	public GameObject butaoPlay;
	public GameObject painel;
    public GameObject question;

    public static float velocidadeJogo;

	void Start(){
		butaoPlay.SetActive (false);
		painel.SetActive (false);
	}
	
	public void play(){
		butaoPause.SetActive (true);
		butaoPlay.SetActive (false);
		painel.SetActive (false);
		Time.timeScale = velocidadeJogo;
		GameIsPaused = false;
	}

	public void pause(){
		painel.SetActive (true);
        butaoPause.SetActive (false);
		butaoPlay.SetActive (true);
		velocidadeJogo = Time.timeScale;
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
}
