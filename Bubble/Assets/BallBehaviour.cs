using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {


	// Use this for initialization
	void Start () {

		AudioSource audioSource = GetComponent<AudioBall>();
		AudioSource audioSource2 = GetComponent<AudioWall>();

	}
	
	// Update is called once per frame
	void Update () {
		
}

	void OnCollisionEnter(Collision col) {
		
		//Debug.Log ("Ball has collided with" + col.transform.tag);
		//collider.rigidbody.velocity = new Vector3 (0, 0, 0);

		if((col.transform.tag == "Wall")||(col.transform.tag == "Ball")) {
			
			//collider.transform.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			this.GetComponent<Rigidbody> ().isKinematic = true;
			audioSource.Play();
		}
		if(col.transform.tag == "Ball") {

			if(GetComponent<Renderer>().material.name == col.transform.GetComponent<Renderer>().material.name) {
				Debug.Log("This ball has the same material as me!");
				audioSource2.Play();
			}

		}

		//Have I collided with other ball?

		//Does this ball have the same material as me?

	}
	
}
