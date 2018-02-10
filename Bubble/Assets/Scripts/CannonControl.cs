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

	public float ShootForce;
//	private bool Grounded;
//	private bool TimeHeld;

	public float ChargeTime = 0F;
	public float ChargeRate = 2F;
	public float FireRate1;
	public float FireRate2;


	// Use this for initialization
	void Start () {

		int chosenmaterial = Random.Range (0, mat.Length);
		CannonRenderer.material = mat [chosenmaterial] ;

		//*** chosen material will also be determined affected by space key input ***

		StartCoroutine (TimerRoutine());

	}

	IEnumerator TimerRoutine() {

		if (Input.GetKeyDown (KeyCode.Space) == true) {
			yield return new WaitForSeconds(2f);
			ChargeTime += ChargeRate;
		}
		if ((Input.GetKeyUp (KeyCode.Space) == true) && Time.time > 2f) {
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

	// Update is called once per frame
	void Update() {

		if (Input.GetKey (KeyCode.RightArrow) == true) {
			transform.Rotate (new Vector3 (0, 0, -RotateSpeed));
		}
		if (Input.GetKey (KeyCode.LeftArrow) == true) {
			transform.Rotate (new Vector3 (0, 0, RotateSpeed));
		}
	}

//	minJumpForce = sqrt(2 * gravity * minJumpHeight)

	public void ChangeColor() {
	
		int chosenmaterial = Random.Range (0, mat.Length);
		CannonRenderer.material = mat [chosenmaterial];
	
	}

}
