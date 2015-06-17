using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Speed;
	public bool pulando;
	public GameObject Flecha;
	public GameObject FlechaGelo;
	private float anguloY;
	private float anguloX;
	private float forcaPulo;
	private int valorFlecha;
	private int pontuacao;
	public GameObject FlechaEscolhida;

	// Use this for initialization
	void Start () {
		FlechaEscolhida = Flecha;
		pontuacao = 500;
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
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 10 * forcaPulo);
			pulando = true;
		}
	}

	public void atk() {
		GameObject flecha = GameObject.Instantiate(FlechaEscolhida) as GameObject;
		flecha.GetComponent<Transform> ().position = this.transform.position;
		flecha.GetComponent<Rigidbody2D> ().AddForce (new Vector3(anguloX,anguloY,0));
		flecha.GetComponent<Collider2D> ().isTrigger = true;
		pontuacao = pontuacao - valorFlecha;
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
		if (collision.gameObject.tag == "guilhotina") {
			GameObject.Destroy(this.gameObject);
		}
	}

	public void MudarTipoFlecha(int valor) {
		if( valor == 1) {
			FlechaEscolhida = Flecha;
			valorFlecha = 1;
		}
		if (valor == 2) {
			FlechaEscolhida = FlechaGelo;
			valorFlecha = 3;
		}
	}
}
