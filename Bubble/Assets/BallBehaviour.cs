using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	public bool IsExploding = false;
	public int CurrentlyCollidingSameColoredBalls = 0;
	public List<Transform> AllSameColoredBallsImCollidingWith = new List<Transform>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
}

	void OnCollisionEnter(Collision col) {
		
		//Debug.Log ("Ball has collided with" + col.transform.tag);
		//collider.rigidbody.velocity = new Vector3 (0, 0, 0);

		GetComponent<AudioSource> ().Play();

		if((col.transform.tag == "Wall")||(col.transform.tag == "Ball")) {
			
			//collider.transform.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			this.GetComponent<Rigidbody> ().isKinematic = true;

		}
		if(col.transform.tag == "Ball") {
			
			//Have I collided with other ball?
			//Does this ball have the same material as me?

			if(GetComponent<Renderer>().material.name == col.transform.GetComponent<Renderer>().material.name) {
				CurrentlyCollidingSameColoredBalls++;
				AllSameColoredBallsImCollidingWith.Add (col.transform);
				//Am I part of a 2+ same colored colliding ball chain?
				if (CurrentlyCollidingSameColoredBalls > 1) {
					Explode();
				}
				Debug.Log("This ball has the same material as me!");
			}
		}			
	}

	void Explode() {

		Debug.Log ("Time to explode!");
		//Tell my friends to explode
		IsExploding = true;
		foreach (Transform ball in AllSameColoredBallsImCollidingWith) {
			if (ball.GetComponent<BallBehaviour> ().IsExploding == false) {
				ball.GetComponent<BallBehaviour> ().Explode ();
			}
		
		}

		//Explode myself
		Destroy(gameObject);
	
	}
	
}
