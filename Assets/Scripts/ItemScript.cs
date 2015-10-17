using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider hit){
		if (hit.CompareTag ("Player")) { 
			if(this.tag=="ItemYakisoba"){
				//YouGot1000Pt!
				Debug.Log("Yakisoba Get!!!");
			}
			Destroy (gameObject); 
		}
	}
}
