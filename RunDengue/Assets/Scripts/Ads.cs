using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour {

	void Start(){
		Advertisement.Initialize ("2825519", false);
	}


	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			//
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
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

	public void Mostrevideo (){
		if (Advertisement.isSupported) {
			Debug.Log ("é suportado");
		} else {
			Debug.Log ("n é");
		}
		if (Advertisement.IsReady ()) {
			ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	public void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
		Advertisement.Show("rewardedVideo", options);

	}

	public void ShowVideo()
	{
		if (Advertisement.isSupported) {
			Debug.Log ("é suportado");
		} else {
			Debug.Log ("n é");
		}
		if (Advertisement.IsReady ()) {
			ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show();
		}
	}

	/*
	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			// Reward your player here.
			PlayerPrefs.SetInt ("video", 1);
		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
			PlayerPrefs.SetInt ("video", 0);

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}*/

}
