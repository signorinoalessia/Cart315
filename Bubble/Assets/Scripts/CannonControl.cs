using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour {

	public float RotateSpeed;
	public Transform BallPrefab;
	public Transform SpawnPoint;
	public Material[] mat;
	public Renderer CannonRenderer;

	public float ShootForce;


	// Use this for initialization
	void Start () {

		int chosenmaterial = Random.Range (0, mat.Length);
		CannonRenderer.material = mat [chosenmaterial] ;

		//*** chosen material will also be determined affected by space key input ***



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

			Vector3 DirectionVector = SpawnPoint.position - transform.position;
			//NewBall.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (0,ShootForce,0));
			DirectionVector = DirectionVector * ShootForce;
			NewBall.GetComponent<Rigidbody> ().AddForce(DirectionVector);

			ChangeColor ();
			GetComponent<AudioSource> ().Play();
		}
	}

//	minJumpForce = sqrt(2 * gravity * minJumpHeight)

	public void ChangeColor() {
	
		int chosenmaterial = Random.Range (0, mat.Length);
		CannonRenderer.material = mat [chosenmaterial];
	
	}

}
