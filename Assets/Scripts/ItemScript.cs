using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
	GameObject mc;

	// Use this for initialization
	void Start () {
		mc = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider hit){
		if (hit.CompareTag ("Player")) { 
			if(this.tag=="ItemYakisoba"){
				//YouGot1000Pt!
				mc.SendMessage("addYakisobaScore");
				Debug.Log("Yakisoba Get!!!");
			}
			if(this.tag=="ItemSonota"){
				mc.SendMessage("goal");
				Debug.Log ("Goal!!");
			}
			Destroy (gameObject); 
		}
	}
}
