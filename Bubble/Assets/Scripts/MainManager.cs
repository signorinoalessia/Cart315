using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	public int TotalScore;

	// Use this for initialization
	void Start () {

//		StartCoroutine (CountDown ());

	}
	
	// Update is called once per frame
	void Update () {
		
//		IEnumerator CountDown() {
//			
//		while (Timeleft > 0) {
//		
//			yield return new WaitForSeconds (1);
//				Timeleft--;
//				//if (Timeleft=-5)
//		
//		}
//		}

		GameObject.Find("ScoreLabel").GetComponent<Text>().text = "Score: "+ TotalScore;

	}
}
