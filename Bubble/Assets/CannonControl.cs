using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public float RotateSpeed;
	public Transform BallPrefab;
	public Transform SpawnPoint;
	public float ShootForce;
	public Material[] mat;
	public Renderer CannonRenderer;

	// Use this for initialization
	void Start () {

		int chosenmaterial = Random.Range (0, mat.Length);
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
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			Transform NewBall = Instantiate (BallPrefab);
			NewBall.position = SpawnPoint.position;
			NewBall.rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CannonRenderer.material;
			NewBall.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (0,ShootForce,0));
			ChangeColor ();
		}
	}

	public void ChangeColor() {
	
		int chosenmaterial = Random.Range (0, mat.Length);
		CannonRenderer.material = mat [chosenmaterial];
	
	}

}
