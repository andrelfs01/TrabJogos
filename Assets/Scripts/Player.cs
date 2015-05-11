using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Speed;
	public bool pulando;
	public GameObject Flecha;
	private float anguloY;
	private float anguloX;
	private float forcaPulo;

	// Use this for initialization
	void Start () {
		Speed = 10;
		pulando = true;
		anguloY = 500;
		anguloX = 1000;
		forcaPulo = 40;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * Speed * Time.deltaTime);
	}

	public void jump() {
		if (!pulando) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * Speed * forcaPulo);
			pulando = true;
		}
	}

	public void atk() {
		GameObject flecha = GameObject.Instantiate(Flecha) as GameObject;
		flecha.GetComponent<Transform> ().position = this.transform.position;
		flecha.GetComponent<Rigidbody2D> ().AddForce (new Vector3(anguloX,anguloY,0));
	}

	public void UpAngulo() {
		anguloY += 100;
	}

	public void DonwAngulo() {
		anguloY -= 100;
	}

	public void SlowTime() {
		if (Time.timeScale == 1.0F) {
			Time.timeScale = 0.3F;
			anguloX = anguloX * 3.3F;
			anguloY = anguloY * 3.3F;
			forcaPulo = forcaPulo * 3.2F;
		} else {
			Time.timeScale = 1.0F;
			anguloX = anguloX / 3.3F;
			anguloY = anguloY / 3.3F;
			forcaPulo = forcaPulo / 3.2F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "terreno") {
			pulando=false;
		}
	}
}
