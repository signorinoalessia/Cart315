using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

	public int TotalScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GameObject.Find("ScoreLabel").GetComponent<Text>().text = "Score: "+ TotalScore;

	}
}
