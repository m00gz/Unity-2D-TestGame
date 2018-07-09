using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour {

	public GameObject playerToBounce;
	public Vector2 platVelocity;
	bool isOnTop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Jump() {
		playerToBounce.GetComponent<Rigidbody2D> ().velocity = platVelocity;
	}

	void OnCollisionStay2D(Collision2D other) {
		if (isOnTop) {
			playerToBounce = other.gameObject;
		}
	}

	void OnTriggerEnter2D () {
		isOnTop = true;
	}

	void OnTriggerStay2D () {
		isOnTop = true;
	}

	void OnTriggerExit2D() {
		isOnTop = false;
	}
}
