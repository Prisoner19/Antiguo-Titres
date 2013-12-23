using UnityEngine;
using System.Collections;

public class sControl : MonoBehaviour {

	private static sControl instancia; 
	public bool finalSentado;
	
	// Use this for initialization
	void Start () {
		instancia = this;
		crearFigura();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public static sControl getInstancia{
		get{
			return instancia;	
		}
	}

	
	public void crearFigura(){
		
		Vector3 posInicio = new Vector3(0.25f,6.25f,0);
		
		int rand_fig = UnityEngine.Random.Range (1,6);
		GameObject figura = Instantiate(Resources.Load("Prefabs/Figura"+rand_fig), posInicio, transform.rotation) as GameObject;
		figura.name = "Figura"+rand_fig;
		//Instantiate(Resources.Load("Prefabs/Figura"+ rand_fig), posInicio, transform.rotation);
		//Instantiate(Resources.Load("Prefabs/CuadF"+ rand_fig), posInicio, transform.rotation);
	}
}
