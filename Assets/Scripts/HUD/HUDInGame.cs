using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDInGame : MonoBehaviour {
	public Text scoreText;
	public Text timeText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: 0";
		timeText.text = "Time: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
