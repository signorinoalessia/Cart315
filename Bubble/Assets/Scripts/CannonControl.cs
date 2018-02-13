using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public float RotateSpeed;
	public GameObject BallPrefab;
	public Transform SpawnPoint;
	public Material[] mat;
	public Renderer CannonRenderer;

	GameObject NewBall; 
	//public float ShootForce;
	public float CurrentForce;
	public float MaxForce = 10f;
	public bool pressingSpace = false;
	private int chosenmaterial;

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
		// DOWN: Reset Colour Material && Start CurrentForce
		if (Input.GetKeyDown("space"))
		{
			Debug.Log ("down");
			pressingSpace = true;

			//int chosenmaterial = (int)Random.Range (0, (mat.Length*colour.a));

			Debug.Log (chosenmaterial);
			CannonRenderer.material = mat [chosenmaterial] ;

			NewBall = Instantiate (BallPrefab);
			NewBall.GetComponent<Transform>().position = SpawnPoint.position;
			NewBall.GetComponent<Transform>().rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CannonRenderer.material;
						
		}
		// DURING: Increase Color Alpha && Increase CurrentForce
		if (pressingSpace == true) {

			CurrentForce += (Time.deltaTime*10);
			Debug.Log ("My force is increasing");

			Debug.Log(CannonRenderer.material.color);
			Color MaterialColour = CannonRenderer.material.color;
			MaterialColour.a = CurrentForce;
			CannonRenderer.material.color = new Color (MaterialColour.r, MaterialColour.g, MaterialColour.b, MaterialColour.a);

			GetComponent<AudioSource> ().Play ();
		}
		// UP: Release Force (Transform) && Reset CurrentForce
		if (Input.GetKeyUp("space")) {
			Debug.Log ("up");
			pressingSpace = false;
			//CurrentForce = 0;

			Vector3 DirectionVector = SpawnPoint.position - transform.position;
			DirectionVector = DirectionVector * CurrentForce;
			NewBall.GetComponent<Rigidbody> ().AddForce (DirectionVector);

		}
	}
}
