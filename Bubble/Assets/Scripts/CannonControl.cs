// Reference for mapping values: https://forum.unity.com/threads/mapping-or-scaling-values-to-a-new-range.180090/
// Reference for alpha channel: https://docs.unity3d.com/ScriptReference/Color-a.html

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
	public float MaxForce = 100F;
	public bool pressingSpace = false;
	private int chosenmaterial;

	// Use this for initialization
	void Start () {

		int chosenmaterial = (int)Random.Range (0, mat.Length);
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
			//Debug.Log ("down");
			pressingSpace = true;

			//int chosenmaterial = (int)Random.Range (0, (mat.Length*colour.a));
			chosenmaterial = (int)Random.Range (0, mat.Length);
			//Debug.Log ("material:: "+chosenmaterial);
			CannonRenderer.material = mat [chosenmaterial] ;

			NewBall = Instantiate (BallPrefab);
			NewBall.GetComponent<Transform>().position = SpawnPoint.position;
			NewBall.GetComponent<Transform>().rotation = SpawnPoint.rotation;
			NewBall.GetComponent<Renderer> ().material = CannonRenderer.material;
						
		}
		// DURING: Increase Color Alpha && Increase CurrentForce
		if (pressingSpace == true) {

			CurrentForce += (Time.deltaTime*50);
			//Debug.Log(CannonRenderer.material.color);

			float MappedValue = scale(0.0F, (MaxForce/1.5F), 0.0F, 1.0F, CurrentForce);
			//Debug.Log ("Mapped: "+MappedValue);

			Color MaterialColour = CannonRenderer.material.color;
			MaterialColour.a = MappedValue;
			CannonRenderer.material.color = new Color (MaterialColour.r, MaterialColour.g, MaterialColour.b, MaterialColour.a);

			GetComponent<AudioSource> ().Play ();
		}
		// UP: Release Force (Transform) && Reset CurrentForce
		if (Input.GetKeyUp("space")) {
			//Debug.Log ("up");
			pressingSpace = false;

			Vector3 DirectionVector = SpawnPoint.position - transform.position;
			DirectionVector = DirectionVector * CurrentForce;
			if (NewBall != null) {
				NewBall.GetComponent<Rigidbody> ().AddForce (DirectionVector);
			}
			CurrentForce = 0;

		}
	}

	private float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}


}

