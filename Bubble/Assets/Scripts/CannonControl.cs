//Examples: https://answers.unity.com/questions/175356/holding-button-down-to-launch-object-further.html
// More exs: https://answers.unity.com/questions/1072683/increase-jumpheight-while-holding-down-a-key.html
// Ref: https://answers.unity.com/questions/1396024/coding-a-megaman-like-charge-shot.html

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

//	public float ChargeTime = 0F;
//	public float ChargeRate = 2F;
//	public float FireRate1;
//	public float FireRate2;


	// Use this for initialization
	void Start () {

//		int chosenmaterial = Random.Range (0, mat.Length);
//		CannonRenderer.material = mat [chosenmaterial] ;

		//*** chosen material will also be determined affected by space key input ***

		//CurrentForce = (int)CurrentForce;

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
		// Release Force (Transform) && reset CurrentForce
		if (Input.GetKeyUp("space"))
		{
			Debug.Log ("up");
			pressingSpace = false;
			CurrentForce = 0;

		}
		// Increase Color Alpha && Increase CurrentForce
		if (pressingSpace ==true && Time.time > 2f) {
			//ChargeTime += ChargeRate;
			//CurrentForce = (float)CurrentForce;

			CurrentForce += Time.deltaTime;
			Debug.Log ("My force is increasing");

			//calculate force and set alpha for chosen colour
			Transform NewBall = Instantiate (BallPrefab);
			NewBall.position = SpawnPoint.position;
			NewBall.rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CannonRenderer.material;


			Vector3 DirectionVector = SpawnPoint.position - transform.position;
			DirectionVector = DirectionVector * CurrentForce;
			NewBall.GetComponent<Rigidbody> ().AddForce (DirectionVector);

			//ChangeColor ();
			GetComponent<AudioSource> ().Play ();
		}
	}
}
