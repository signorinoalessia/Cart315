using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {

	public float speed;
	public float JumpForce;
	public bool OnGround = false;
	public float RotateSpeed = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow) == true) {

			//Debug.Log ("Right Arrow is pressed");
			transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);

		}
		if (Input.GetKey (KeyCode.LeftArrow) == true) {

			//Debug.Log ("Right Arrow is pressed");
			//UnityEngine.Transform.Rotate(0,-0.5,0);
			transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);

		}

//		if (Input.GetKey (KeyCode.RightArrow) == true) {
//
//			//Debug.Log ("Right Arrow is pressed");
//			transform.position = transform.position + new Vector3(speed,0,0);
//
//		}
//		if (Input.GetKey (KeyCode.LeftArrow) == true) {
//
//			//Debug.Log ("Right Arrow is pressed");
//			transform.position = transform.position + new Vector3(-speed,0,0);
//
//		}


	}

	void OnCollisionEnter(Collision collision){

		Debug.Log ("Collision!");
		OnGround = true;

	}
	void OnCollisionExit(Collision collision){


		OnGround = false;

	}
}
