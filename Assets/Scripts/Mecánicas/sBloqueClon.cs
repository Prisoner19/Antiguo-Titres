using UnityEngine;
using System.Collections;

public class sBloqueClon : MonoBehaviour {

	public static bool colision=false;

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
				StartCoroutine("cambiarFlagEnClonPadre");
				Debug.Log("bloque");
			}
			colision=true;
		}
	}
	
	void OnCollisionExit2D(Collision2D coll) {
		if (colision) {
			if(coll.collider.name == "Bloque"){
				this.transform.parent.GetComponent<sClon>().figura.GetComponent<sFigura>().chocaBase=false;
			}
			colision=false;
		}
	}

	IEnumerator cambiarFlagEnClonPadre(){
		yield return new WaitForSeconds (0.5f);
		this.transform.parent.GetComponent<sClon>().figura.GetComponent<sFigura>().chocaBase=true;
	}
}
