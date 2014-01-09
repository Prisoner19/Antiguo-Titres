using UnityEngine;
using System.Collections;

public class sPrueba : MonoBehaviour {

	private bool colision=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log("En clon");
	}
	/*
	void OnTriggerEnter2D(Collider2D other) {
		if (!other.name.StartsWith ("B")) {
			if(!colision){
				Debug.Log (other.name);
			}
			colision=true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (!other.name.StartsWith ("B")) {
			if(colision){
				Debug.Log (other.name);
			}
			colision=false;
		}
	}*/

	void OnCollisionEnter2D(Collision2D coll) {
		if (!colision) {
			if(coll.collider.name == "Bloque"){
				this.transform.parent.GetComponent<sClon>().figura.GetComponent<sFigura>().chocaPared=true;
				Debug.Log("bloque");
			}
			colision=true;
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (colision) {
			if(coll.collider.name == "Bloque"){
				this.transform.parent.GetComponent<sClon>().figura.GetComponent<sFigura>().chocaPared=false;
			}
			colision=false;
		}
	}
}
