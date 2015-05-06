﻿using UnityEngine;
using System.Collections;

public class TouchATK : MonoBehaviour {
	public Touch touch;
	public Ray ray;
	//public RaycastHit hit;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("lololol");
		for(int i=0;i<Input.touches.Length;i++) {
			touch = Input.touches[i];
			ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
			Vector3 aux =  ray.origin;
			aux.z=0;
			ray.origin = aux;
			RaycastHit hit = new RaycastHit();
			
			if(Physics.Raycast(ray,out hit,100)) {
				if(hit.collider.gameObject.tag == "atk") {
					
					switch(touch.phase) {
					case TouchPhase.Began:
						GameObject.Find("Player").GetComponent("Player").SendMessage("atk");
						break;
						
					case TouchPhase.Ended:
						break;
					}
				}
			}
			
		}
		
		if(Input.GetMouseButton(0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 aux =  ray.origin;
			aux.z=0;
			ray.origin = aux;
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(ray,out hit,100)) {
				if(hit.collider.gameObject.tag == "atk") {
					Debug.Log("entrei" + ray.ToString());
					GameObject.Find("Player").GetComponent("Player").SendMessage("atk");
				}
			}
		}
	}
}
