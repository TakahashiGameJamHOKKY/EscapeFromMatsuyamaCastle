using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x+4f, player.transform.position.y+2.8f, player.transform.position.z - 1.5f);
		//transform.rotation = player.transform.rotation;

        //var forward = Quaternion.LookRotation(new Vector3(11, 309, 0));
        //transform.rotation

        var forward = Quaternion.LookRotation(new Vector3(-5f,-5f,5f));
        transform.rotation = forward;
    }
}
