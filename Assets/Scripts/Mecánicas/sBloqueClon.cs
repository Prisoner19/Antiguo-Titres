using UnityEngine;
using System.Collections;

public class sBloqueClon : MonoBehaviour {

	public bool colision;
	// Use this for initialization
	void Start () {
		colision = transform.parent.GetComponent<sClon> ().colision;	
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
		if(coll.collider.name == "Bloque" ){
			if (!colision ) {
				StartCoroutine("cambiarFlagEnClonPadre");
			}
			colision=true;
		}
	}
	
	void OnCollisionExit2D(Collision2D coll) {
		if(coll.collider.name == "Bloque"){
			if (colision) {
					if(this!=null)
						this.transform.parent.GetComponent<sClon>().figura.GetComponent<sFigura>().chocaBase=false;
				}
			colision=false;
		}
	}

	IEnumerator cambiarFlagEnClonPadre(){
		if (this != null) {
			sFigura temp = (sFigura)this.transform.parent.GetComponent<sClon> ().figura.GetComponent<sFigura> ();

			yield return new WaitForSeconds (0.3f);
			temp.chocaBase = true;
			sPared.trigger = false;
			temp.chocaParedDer = false;
			temp.chocaParedIzq = false;
		}
	}

	void Destroy(){
		StopAllCoroutines ();
	}
}
