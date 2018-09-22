using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public  AudioSource audiosGame;
	public  AudioClip soundJump;
	public  AudioClip soundSlide;
	public  AudioClip soudTransition;
	public  AudioClip soudErr;

	public  void  PlayJump(){
		audiosGame.PlayOneShot(soundJump);
	}

	public  void  PlaySlide(){
		audiosGame.PlayOneShot(soundSlide);
	}

	public void PlayTransition(){
		audiosGame.PlayOneShot(soudTransition);
	}
	public void PlayErr(){
		audiosGame.PlayOneShot(soudErr);
	}


}
