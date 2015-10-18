using UnityEngine;
using System.Collections;

public class GameOverCtrl : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			FadeManager.Instance.LoadLevel ("inGame", 0.5f);
		}
	}
}