using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {
	public float speed = 1.0f;

	private Rigidbody rigidbody;
	private Renderer renderer;
	private bool IsWathced = false;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> () as Rigidbody;
		rigidbody.velocity = new Vector3 (speed, 0, 0);
		renderer = GetComponent<Renderer> () as Renderer;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 4.0f) {
			rigidbody.velocity = new Vector3 (-speed, 0, 0);
		} else if (transform.position.x < -4.0f) {
			rigidbody.velocity = new Vector3 (speed, 0, 0);
		}
		if (this.IsWathced) {
			renderer.material.color = Color.blue;
		} else {
			renderer.material.color = Color.white;
		}
	}
	public void Watched() {
		Debug.Log ("Watched");
		this.IsWathced = true;
	}
	public void NWatched() {
		this.IsWathced = false;
	}
	/*
	void OnTriggerEnter(Collider col) {
		Debug.Log ("enter");
		renderer.material.color = Color.blue;
	}
	void OnTriggerExit(Collider col) {
		Debug.Log ("exit");
		renderer.material.color = Color.white;
	}*/
}
