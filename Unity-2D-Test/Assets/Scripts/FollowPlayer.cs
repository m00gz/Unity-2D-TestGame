using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	Transform player;
	public Vector3 offset;
	public float minLimitY;

	void Start () {
		if (player == null) {
			player = GameObject.Find ("Player").GetComponent<Transform>();
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.position + offset;

		if (transform.position.y < minLimitY) {
			transform.position = new Vector3 (transform.position.x, minLimitY, transform.position.z);
		}
	}
}
