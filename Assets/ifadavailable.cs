using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class ifadavailable : MonoBehaviour {
	public GameObject coins;
	// Use this for initialization
	void Start () {
		if (Advertisement.IsReady ("rewardedVideo")) 
			coins.SetActive (true);
		else
			coins.SetActive (false);
			
	}
}
