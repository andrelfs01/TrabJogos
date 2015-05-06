using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Speed;
	public bool pulando;
	public GameObject soco;

	// Use this for initialization
	void Start () {
		Speed = 10;
		pulando = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * Speed * Time.deltaTime);
	}

	public void jump() {
		if (!pulando) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * Speed * 40);
			pulando = true;
		}
	}

	public void atk() {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "terreno") {
			pulando=false;
		}
	}
}
