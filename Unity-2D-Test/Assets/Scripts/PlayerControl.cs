﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	// Variables //
	public float moveSpeed;
	public float jumpForce;
	public float chkRadius;
	public int jumpCount;
	public Transform chkOnGround;
	public Transform respawnPoint;
	public LayerMask groundName;

	int extraJump;
	float moveInput;
	Rigidbody2D rb;

	bool lookRight = true;
	bool isOnGround;


	// Methods //
	void Start () {
		extraJump = jumpCount;
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {

		isOnGround = Physics2D.OverlapCircle (chkOnGround.position, chkRadius, groundName);

		moveInput = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector3 (moveInput * moveSpeed, rb.velocity.y);

		if (lookRight == false && moveInput > 0) {
			FlipSprite ();
		} 

		else if (lookRight == true && moveInput < 0) {
			FlipSprite ();
		}
	}

	void Update(){

		if (isOnGround == true) {
			extraJump = jumpCount;
		}

		if (Input.GetKeyDown (KeyCode.Space) && extraJump > 0) {
			rb.velocity = Vector2.up * jumpForce;
			extraJump--;
		}

		else if (Input.GetKeyDown (KeyCode.Space) && extraJump == 0 && isOnGround == true) {
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void FlipSprite(){
		lookRight = !lookRight;
		Vector3 scaleVal = transform.localScale;
		scaleVal.x *= -1;
		transform.localScale = scaleVal;
	}

	void OnTriggerEnter2D (Collider2D other) {

		// Spawn back to spawnPoint location (or maybe try to do some deaths)
		if (other.tag == "Falls") {
			//Destroy (this.gameObject);
			this.transform.position = respawnPoint.position;
		}

		if (other.tag == "JumpPad") {
			rb.velocity = Vector2.up * jumpForce * 2;
		}

		if (other.tag == "JumpPad_Side") {
			rb.velocity = Vector2.left * jumpForce * 2;
		}
	}
}
