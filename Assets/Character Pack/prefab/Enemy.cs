using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float Range = 50.0f;
	public float angle = 40.0f;
	public float speed = 1.0f;
	public float walkDistance = 3.0f;
	
	private GameObject player;
	private LayerMask mLayerMask;
	private Rigidbody rigidbody;
	private Vector3 prevPosition;
	private float moveDistance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("UnityChan");
		mLayerMask = 1 << LayerMask.NameToLayer("Obstacle");
		rigidbody = GetComponent<Rigidbody> () as Rigidbody;
		rigidbody.velocity = transform.forward * speed;
		prevPosition = transform.position;
		moveDistance = walkDistance / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveDistance > walkDistance) {
			transform.Rotate (new Vector3(0, 180, 0));
			rigidbody.velocity = transform.forward * speed;
			moveDistance = 0;
		}
		moveDistance += Mathf.Sqrt ((prevPosition - transform.position).sqrMagnitude);
		prevPosition = transform.position;

		if (Mathf.Sqrt((transform.position - player.transform.position).sqrMagnitude) < this.Range
		    && Vector3.Angle (player.transform.position - transform.position, transform.forward) <= angle) {
			if (!Physics.Linecast (transform.position, player.transform.position, mLayerMask)) {
				//視界に入っている時
				player.SendMessage ("Watched");
			} else {
				//視界に入っていない時
				//player.SendMessage ("NWatched");
			}
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			player.SendMessage ("Watched");
		}
	}
}
