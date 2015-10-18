using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	public Transform move_target;

	void Start() {

	}

	void Update () {
		transform.position = move_target.position;
	}
}
