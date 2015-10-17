using UnityEngine;
using System.Collections;

public class CharaCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")) {
			//transform.position += transform.forward * 0.01f;
			Vector3 vec = new Vector3(10,0,0);
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * 50);
		} 
		if (Input.GetKey("e")) {
			//transform.position += transform.forward * 0.01f;
			
            //Vector3 vec = new Vector3(10,0,0);
			//this.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 10);

            transform.position += transform.forward * 0.10f; // 移動
		} 
		if (Input.GetKey("d")) {
			//transform.position += transform.forward * 0.01f;
			Vector3 vec = new Vector3(10,0,0);
			this.GetComponent<Rigidbody> ().AddForce (Vector3.back * 10);
		} 
		if (Input.GetKey("f")) {
			//transform.position += transform.forward * 0.01f;
			Vector3 vec = new Vector3(10,0,0);
			this.GetComponent<Rigidbody> ().AddForce (Vector3.right * 10);
		} 
		if (Input.GetKey("s")) {
			//transform.position += transform.forward * 0.01f;
			Vector3 vec = new Vector3(10,0,0);
			this.GetComponent<Rigidbody> ().AddForce (Vector3.left * 10);
		} 
	}
}
