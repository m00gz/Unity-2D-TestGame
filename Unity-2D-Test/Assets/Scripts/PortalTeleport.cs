using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour {

	public GameObject exitPortal;
	bool canTeleport = false;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			if (canTeleport) {
				Teleport ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			canTeleport = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			canTeleport = false;
		}
	}

	void Teleport () {
		player.transform.position = new Vector3 (exitPortal.transform.position.x, exitPortal.transform.position.y);
	}
}
