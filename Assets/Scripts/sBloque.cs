using UnityEngine;
using System.Collections;

public class sBloque : MonoBehaviour {

	public sFigura figuraPadre;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		seleccionarBloque();
	}

	void seleccionarBloque(){
		if(figuraPadre.estado == 0){
			if(figuraPadre.bloqueActivo == null){
				transform.localScale += new Vector3(0.2f,0.2f,0);
				figuraPadre.bloqueActivo = this;
			}
			else{
				figuraPadre.bloqueActivo.transform.localScale -= new Vector3(0.2f,0.2f,0);
				if(figuraPadre.bloqueActivo != this){
					figuraPadre.bloqueActivo = this;
					transform.localScale += new Vector3(0.2f,0.2f,0);
				}
				else{
					figuraPadre.bloqueActivo = null;
				}
			}
		}
	}

}
