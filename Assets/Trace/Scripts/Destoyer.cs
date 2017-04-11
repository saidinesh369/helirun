using UnityEngine;
using System.Collections;

public class Destoyer : MonoBehaviour {
	
	private Controller GameController;
	private Transform thisTransform;
	private superpower sp;
	private ParticleSystem missilebreak;

	void Start()
	{
		//Cache the transform
		thisTransform=transform;
		//Get the Game Controller
		GameController=(Controller)FindObjectOfType(typeof(Controller));
		sp = GameObject.FindObjectOfType<superpower> ();
		missilebreak = GameObject.FindObjectOfType<ParticleSystem> ();
		sp.starpower = false;
		print (sp.starpower);
	}

	void Update () 
	{
		//Enable if this weight is spawned after the spawner reaches a position past x 
		if (thisTransform.position.x > 49) 
			this.gameObject.SetActive (true);
		else
			this.gameObject.SetActive (false);
		
		//Get all the objects in a radius tagged Line
		Collider2D[] colliders = Physics2D.OverlapCircleAll (thisTransform.position,0.7f);

		//Dispawn the lines hit
		foreach(Collider2D col in colliders){
			if (col.tag == "Line")
				ObjectsPool.Despawn(col.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		print (sp.starpower);
		//If the weight hits the player, despawn it and remove one life
		if (coll.gameObject.tag == "Player" && sp.starpower.Equals(false))
		{
			//shield.SetActive (true);
			ObjectsPool.Despawn(this.gameObject);
			GameController.Damage(1);
		}

		if (coll.gameObject.tag == "Player" && sp.starpower.Equals(true))
		{
			ObjectsPool.Despawn(this.gameObject);
			missilebreak.Play ();
			if(GameController.healthLevel<5)
			GameController.Damage(-1);
		}
	}

}