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

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name.StartsWith ("B")) {
			if(!colision){
				Debug.Log (other.gameObject.transform.parent);
				Debug.Log ("unico-entro");
			}
			colision=true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name.StartsWith ("B")) {
			if(colision){
				Debug.Log ("unico-sale");
			}
			colision=false;
		}
	}
}
