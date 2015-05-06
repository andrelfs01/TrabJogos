using UnityEngine;
using System.Collections;

public class InicioFase : MonoBehaviour {
	public GerenciadorJogo gameManager;
	// Use this for initialization
	void Start () {
		gameManager = (GerenciadorJogo)FindObjectOfType(typeof(GerenciadorJogo));
		if (gameManager != null) {
			Debug.Log ("peguei");
		} else {
			Debug.Log("nao peguei");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager == null) {
			gameManager = (GerenciadorJogo)FindObjectOfType(typeof(GerenciadorJogo));
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag.Equals("Player")) {
			gameManager.AtualizarGame();
		}
	
	}

	//void OnTriggerExit2D(Collider2D other);
}
