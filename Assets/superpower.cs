using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superpower : MonoBehaviour {
	public bool starpower =  false;
	public int coincounter = 0;
	public GameObject shield;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "coin" && starpower == false) {
			coincounter = coincounter + 1;
			if (coincounter == 5) {
				coincounter = 0;
				StartCoroutine ("starpowerup");
			}
	
		}
	}
	IEnumerator starpowerup()
	{
		starpower = true;
		shield.SetActive (true);
		yield return new WaitForSeconds (20f);
		shield.SetActive (false);
		starpower = false;
	}
}
		