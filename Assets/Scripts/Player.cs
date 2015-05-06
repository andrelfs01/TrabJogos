using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Speed;
	public bool pulando;
	public GameObject Flecha;
	private int anguloY;

	// Use this for initialization
	void Start () {
		Speed = 10;
		pulando = true;
		anguloY = 500;
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
		GameObject flecha = GameObject.Instantiate(Flecha) as GameObject;
		flecha.GetComponent<Transform> ().position = this.transform.position;
		flecha.GetComponent<Rigidbody2D> ().AddForce (this.transform.position + new Vector3(1000,anguloY,0));
	}

	public void UpAngulo() {
		anguloY += 100;
	}

	public void DonwAngulo() {
		anguloY -= 100;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "terreno") {
			pulando=false;
		}
	}
}
