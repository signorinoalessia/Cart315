﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public float RotateSpeed;
	public Transform BallPrefab;
	public Transform SpawnPoint;
	public float ShootForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow) == true) {
			transform.Rotate (new Vector3 (0, 0, -RotateSpeed));
		}
		if (Input.GetKey (KeyCode.LeftArrow) == true) {
			transform.Rotate (new Vector3 (0, 0, RotateSpeed));
		}
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			Transform NewBall = Instantiate (BallPrefab);
			NewBall.position = SpawnPoint.position;
			NewBall.rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (0,ShootForce,0));

		}

	}
}