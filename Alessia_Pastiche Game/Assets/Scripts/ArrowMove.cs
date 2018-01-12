using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {

//	public float speed;
//	public float JumpForce;
//	public bool OnGround = false;

	[Header("Attributes")]
	public float range = 15f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public float RotateSpeed = 30f;

	public GameObject bubblePrefab;
	public Transform firePoint;

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

		if (fireCountdown <= 0f) {
		
			Shoot ();
			fireCountdown = 1f / fireRate;
		
		}

		fireCountdown -= Time.deltaTime;

	}

	void Shoot() {
	
		Debug.Log ("Shoot!");
		GameObject bubbleGO = (GameObject)Instantiate (bubblePrefab, firePoint.position, firePoint.rotation);
		Bubble bubble = bubbleGO.GetComponent<Bubble> ();

		if (bubble != null)
			bubble.Seek (target);

	}

	void OnCollisionEnter(Collision collision){

		Debug.Log ("Collision!");
		OnGround = true;

	}
	void OnCollisionExit(Collision collision){


		OnGround = false;

	}
}
