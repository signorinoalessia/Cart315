using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {


	// Use this for initialization
	void Start () {


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
		}

		//Have I collided with other bal?

		//Does this ball have the same material as me?

	}
	
}
