using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {
	
	void Start(){
		
		Advertisement.Initialize ("2825519", false);
	}
	public void Mostrevideo (){
		if (Advertisement.isSupported) {
			Debug.Log ("é suportado");
		} else {
			Debug.Log ("n é");
		}
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
		}
	}

	public void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

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
	}
}
