﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (new Vector3 (0, 1, 0));
		//transform.position = transform.position + new Vector3 (0, 1, 0);
	}

	void OnCollisionEnter (Collision col) {
	
		if (col.gameObject.name == "Walls") {
			transform.Translate (new Vector3 (0, -1, 0));

		}
	}
}
