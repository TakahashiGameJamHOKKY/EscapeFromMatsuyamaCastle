using UnityEngine;
using System.Collections;

public class RoundEnemy : MonoBehaviour {

	public float Range = 50.0f;
	public float angle = 40.0f;
	public float speed = 1.0f;
	public bool roundClockwise = false;

	private GameObject player;
	private LayerMask mLayerMask;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		mLayerMask = 1 << LayerMask.NameToLayer("Obstacle");
		rigidbody = GetComponent<Rigidbody> () as Rigidbody;
		rigidbody.velocity = transform.forward * speed;
	}

	// Update is called once per frame
	void Update () {
		if (Mathf.Sqrt ((transform.position - player.transform.position).sqrMagnitude) < Range
			&& Vector3.Angle (player.transform.position - transform.position, transform.forward) <= angle) {
			if (!Physics.Linecast (transform.position, player.transform.position, mLayerMask)) {
				//視界に入っている時
				player.SendMessage ("Watched");
			} else {
				//視界に入っていない時
				player.SendMessage ("NWatched");
			}
		} else {
			player.SendMessage ("NWatched");
		}
	}

	void OnTriggerEnter(Collider col) {
		if (!(col.gameObject.tag == "RotatePoint")) {
			return;
		}

		float rotAngle = 90.0f;
		if (!this.roundClockwise) {
			rotAngle *= -1f;
		}

		transform.Rotate (new Vector3 (0, rotAngle, 0));
		rigidbody.velocity = transform.forward * speed;
	}
}
