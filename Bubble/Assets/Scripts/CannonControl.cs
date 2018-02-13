using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public float RotateSpeed;
	public Transform BallPrefab;
	public Transform SpawnPoint;
	public Material[] mat;
	public Renderer CannonRenderer;

	//public float ShootForce;
	public float CurrentForce;
	public float MaxForce = 2f;

	public bool pressingSpace =false;

	// Use this for initialization
	void Start () {

		int chosenmaterial = (int)Random.Range (0, mat.Length);
		Debug.Log (chosenmaterial);
		CannonRenderer.material = mat [chosenmaterial] ;

	}

	// Update is called once per frame
	void Update() {

		if (Input.GetKey (KeyCode.RightArrow) == true) {
			transform.Rotate (new Vector3 (0, 0, -RotateSpeed));
		}
		if (Input.GetKey (KeyCode.LeftArrow) == true) {
			transform.Rotate (new Vector3 (0, 0, RotateSpeed));
		}
		// Reset Colour Material && Start CurrentForce
		if (Input.GetKeyDown("space"))
		{
			Debug.Log ("down");
			pressingSpace = true;

			int chosenmaterial = (int)Random.Range (0, mat.Length);
			Debug.Log (chosenmaterial);
			CannonRenderer.material = mat [chosenmaterial] ;
						
		}

		// Release Force (Transform) && Reset CurrentForce
		if (Input.GetKeyUp("space")) {
			Debug.Log ("up");
			pressingSpace = false;
			CurrentForce = 0;

			Transform NewBall.GetComponent<Rigidbody>;
			Vector3 DirectionVector = SpawnPoint.position - transform.position;
			DirectionVector = DirectionVector * CurrentForce;
			NewBall.GetComponent<Rigidbody> ().AddForce (DirectionVector);

		}

		// Increase Color Alpha && Increase CurrentForce
		if (pressingSpace == true) {
			//ChargeTime += ChargeRate;
			//CurrentForce = (float)CurrentForce;

			CurrentForce += Time.deltaTime;
			Debug.Log ("My force is increasing");

			// Calculate force and set alpha for chosen colour
			Transform NewBall = Instantiate (BallPrefab);
			NewBall.position = SpawnPoint.position;
			NewBall.rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CannonRenderer.material;

			//ChangeColor ();
			GetComponent<AudioSource> ().Play ();
		}
	}
}
