﻿using UnityEngine;
using System.Collections;

public class CordaSustenta : MonoBehaviour, Default {

	public GameObject pedra;

	// Use this for initialization
	void Start () {
		pedra.GetComponent<Collider2D> ().isTrigger = true;
		pedra.GetComponent<Rigidbody2D> ().gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sendDefault() {
		pedra.GetComponent<Rigidbody2D> ().gravityScale = 0;
		pedra.GetComponent<Transform> ().position = this.transform.position + new Vector3(0,-1,0);
		pedra.GetComponent<Collider2D> ().isTrigger = true;
		this.gameObject.GetComponent<MeshRenderer>().enabled = true;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Flecha") {
			pedra.GetComponent<Collider2D> ().isTrigger = false;
			pedra.GetComponent<Rigidbody2D> ().gravityScale = 4;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		} else {
		}
	}
}
