using UnityEngine;
using System.Collections;

public class sPared : MonoBehaviour {

	public static bool trigger=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "B1" || other.name == "B2" || other.name == "B3" || other.name == "B4"){
			if (!trigger) {

				if(other!=null && other.transform.parent!=null){
					sFigura sf= other.transform.parent.GetComponent<sClon>().figura.GetComponent<sFigura>();
					if(sf!=null){
						if(this.name == "ParedIzq")
							sf.chocaParedIzq=true;
						else if(this.name == "ParedDer")
							sf.chocaParedDer=true;
						sf.detenerLados();
						sf.redondearPosicionClon();
						sf.empezarCaida();
					}
				}
			}
			trigger=true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "B1" || other.name == "B2" || other.name == "B3" || other.name == "B4") {
				if (trigger) {
						sFigura sf = other.transform.parent.GetComponent<sClon> ().figura.GetComponent<sFigura> ();
						if (sf != null) {
								if (this.name == "ParedIzq")
										sf.chocaParedIzq = false;
								else if (this.name == "ParedDer")
										sf.chocaParedDer = false;
						}
						trigger = false;
				}
		}
	}
}
