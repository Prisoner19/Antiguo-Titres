using UnityEngine;
using System.Collections;

public class sControl : MonoBehaviour {

	private static sControl instancia; 
	public GameObject[] lineas;
	public bool finalSentado;
	public int numBloques;
	
	// Use this for initialization

	void Awake(){
		instancia = this;
		lineas = new GameObject[12];
		for(int i=0; i<12;i++){
			lineas[i] = new GameObject("Linea"+i);
			lineas[i].transform.parent = GameObject.Find("Base").transform;
		}
	}

	void Start () {
		crearFigura();
	}
	
	// Update is called once per frame
	void Update () {
		if(finalSentado){
			for(int i=10; i>=0; i--){
				verificarLinea(i);
			}
			crearFigura();
		}
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
	}

	public void verificarLinea(int linea){
		Transform row = GameObject.Find("Linea"+linea).transform;
		
		if(row.childCount == 12){
			Debug.Log("Linea "+linea+" llena");
			destruirLinea(row);
			actualizarLineas(linea);
		}
	}

	public void destruirLinea(Transform row){
		for(int i=row.childCount-1; i>=0; i--){
			Destroy(row.GetChild(i).gameObject);
		}
	}

	public void actualizarLineas(int linea){

		Vector3 posNueva;
		Transform lineaArriba;
		Transform bloqueArriba;

		for(int posLinea = linea; posLinea < 11; posLinea++){
			lineaArriba = GameObject.Find("Linea"+(posLinea+1)).transform;
			for(int i=lineaArriba.childCount-1; i>=0; i--){
				bloqueArriba = lineaArriba.GetChild(i);
				posNueva = bloqueArriba.position;
				posNueva.y -= 0.5f;
				bloqueArriba.position = posNueva;
				bloqueArriba.parent = GameObject.Find("Linea"+(posLinea)).transform;
			}
		}

	}

}
