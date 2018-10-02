using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour {





	public void MostrevideoPremiado (){
		AdsController.instancia.MostrevideoPremiado ();
	}



	public void MostreVideoNormal()
	{
		AdsController.instancia.Mostrevideo ();
	}


}
