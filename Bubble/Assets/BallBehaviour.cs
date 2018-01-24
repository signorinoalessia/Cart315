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
		
		Debug.Log ("Ball has collided with" + col.transform.tag);
		//collider.rigidbody.velocity = new Vector3 (0, 0, 0);

		if(col.transform.tag == "wall") {

			collider.transform.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);

		}

	}
	
}
