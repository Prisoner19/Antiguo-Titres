using UnityEngine;
using System.Collections;

public class sFigura : MonoBehaviour {

	private GameObject clon;
	private Vector3 pos;
	private Vector3 velocidad;
	private Vector3 posInicioCuad;
	private bool finalSentado;

	public int velX;
	public int velY;

	private int fase;
	private const int ARMADO = 0;
	private const int ACOPLADO = 1;
	
	private int estado;
	private const int CONGELADO = 0;
	private const int CAYENDO = 1;
	private const int MOVIENDOSE = 2;

	private GameObject cuadricula;
	public sBloque bloqueActivo;

	// Use this for initialization
	void Start () {
		velY *= -1;
		fase = ARMADO;
		finalSentado = false;
		crearClonMovimiento();
		posInicioCuad = new Vector3(0.25f,6.25f,-1);
		cuadricula = null;
		Cuadricular();
		empezarCaida();
		bloqueActivo = null;
	}

	void Awake(){

	}
	
	// Update is called once per frame
	void Update () {
	
		cuadricula.transform.position = transform.position - posInicioCuad;
	
		if(fase == ARMADO && Input.GetButtonDown("Jump")){
			if(estado != CONGELADO){
				detenerLados();
				detenerCaida();
				mostrarCuadricula();
				Debug.Log(estado);
			}
			else{
				empezarCaida();
				ocultarCuadricula();
			}
		}

		if(transform.position.y < GameObject.Find("Limite").transform.position.y){
			fase = ACOPLADO;
		}
		 
		if(Input.GetKey("a") && estado != CONGELADO){
			Debug.Log(estado);
			moverIzquierda();
		}
		else if(Input.GetKey("d") && estado != CONGELADO){
			moverDerecha();
		}
		else if(Input.GetKeyUp("a") || Input.GetKeyUp("d")){
			if(estado != CONGELADO)
				detenerLados();
		}

		if(Input.GetKeyDown("s") && estado != CONGELADO ){
			acelerarCaida();
		}
		else if(Input.GetKeyUp("s") && estado != CONGELADO){
			desacelerarCaida();
		}

		pos = clon.transform.position; 
		pos.x = Mathf.Round((pos.x - 0.25f)*2) /2 + 0.25f;
		pos.z = 0;
		//pos.y = Mathf.Round((pos.y - 0.25f)*2) /2 + 0.25f;
		transform.position = pos;
		/*
		if(clon.rigidbody2D.velocity.y == 0){
			//Debug.Log("Ejecutado");
			clon.transform.position = pos;
			clon.rigidbody2D.velocity = Vector3.down * 5;
			StartCoroutine("verificarFijo");
		}*/

	}

	void detenerCaida(){
		velocidad.y = 0;
		clon.rigidbody2D.velocity = velocidad;
		estado = CONGELADO;
	}

	void moverIzquierda(){
		velocidad.x = -1*velX;
		clon.rigidbody2D.velocity = velocidad;
		estado = MOVIENDOSE;
	}

	void moverDerecha(){
		velocidad.x = velX;
		clon.rigidbody2D.velocity = velocidad;
		estado = MOVIENDOSE;
	}

	void detenerLados(){
		velocidad.x = 0;
		clon.rigidbody2D.velocity = velocidad;
		estado = CAYENDO;
	}

	void acelerarCaida(){
		velocidad.y = velY * 2.5f;
		clon.rigidbody2D.velocity = velocidad;
	}

	void desacelerarCaida(){
		velocidad.y = velocidad.y / 2.5f;
		clon.rigidbody2D.velocity = velocidad;
	}

	void empezarCaida(){
		velocidad.x = 0;
		velocidad.y = velY;
		clon.rigidbody2D.velocity = velocidad;
		estado = CAYENDO;
	}

	void crearClonMovimiento(){

		Vector3 posClon = transform.position;
		posClon.z = 1;

		clon = Instantiate(Resources.Load("Prefabs/"+name), posClon, transform.rotation) as GameObject;
		clon.name = "Clon";
		Destroy(clon.GetComponent("sFigura"));
		clon.AddComponent("Rigidbody2D");
		clon.rigidbody2D.gravityScale = 0;
		clon.rigidbody2D.fixedAngle = true;
		clon.rigidbody2D.angularDrag = 0;
		clon.rigidbody2D.velocity = velocidad;

		BoxCollider2D col;

		for(int i=0; i<clon.transform.childCount; i++){
			clon.transform.GetChild(i).renderer.enabled = false;
			clon.transform.GetChild(i).collider2D.isTrigger = false;
			Destroy(clon.transform.GetChild(i).GetComponent("sBloque"));
			col = clon.transform.GetChild(i).GetComponent("BoxCollider2D") as BoxCollider2D;
			col.size = new Vector2(0.45f,0.45f);
		}
	}

	public void actualizarPosicionClon(){

		Vector3 posAux;

		for(int i=0; i<transform.childCount; i++){
			posAux = transform.GetChild(i).transform.position;
			posAux.z = 1;
			clon.transform.GetChild(i).transform.position = posAux;
		}
	}

	IEnumerator verificarFijo(){
		yield return new WaitForSeconds(0.5f);
		//clon.rigidbody2D.velocity = Vector3.down * 5;
		if(clon.transform.position == transform.position){
			finalSentado = true;
			asentar();
		}
		else
			finalSentado = false;
	}

	public void asentar(){
		Destroy(clon);
		pos = transform.position;
		pos.y = Mathf.Round((pos.y - 0.25f)*2) /2 + 0.25f;
		transform.position = pos;
		sControl.getInstancia.crearFigura();
		for(int i=0; i<transform.childCount; i++){
			transform.GetChild(i).collider2D.isTrigger = false;
		}
		Destroy(gameObject.GetComponent("sFigura"));
	}

	
	public void Cuadricular(){
		
		Vector3 posNueva;
		bool mismaPos;

		eliminarCuadricula();
		cuadricula = new GameObject("Cuadricula");
		//Debug.Log(cuadricula.transform.position.ToString("F2")+" / "+ transform.position.ToString("F2"));
		posInicioCuad = new Vector3(transform.position.x, transform.position.y, -1);

		for(int i=0; i<transform.childCount; i++){
			for(int j=0; j<4; j++){
				mismaPos = false;
				posNueva = transform.GetChild(i).transform.position;
				switch(j){
				case 0: posNueva.x += 0.5f; break;
				case 1: posNueva.x -= 0.5f; break;
				case 2: posNueva.y += 0.5f; break;
				case 3: posNueva.y -= 0.5f; break;
				}
				
				for(int k=0; k<transform.childCount; k++){
					if(posNueva == transform.GetChild(k).transform.position){
						mismaPos = true;
						break;
					}
				}
				
				if(!mismaPos){
					GameObject cuad = Instantiate(Resources.Load("Prefabs/BCuad"), posNueva, transform.rotation) as GameObject;
					cuad.name = "BCuad";
					cuad.transform.parent = cuadricula.transform;
					cuad.renderer.enabled = false;
				}
			}
		}
	}

	public void mostrarCuadricula(){

		Transform t = cuadricula.transform;

		for(int i=0; i<t.childCount; i++){
			t.GetChild(i).renderer.enabled = true;
		}

		cuadricula.transform.position = transform.position - posInicioCuad;
	}

	public void ocultarCuadricula(){
		Transform t = cuadricula.transform;
		
		for(int i=0; i<t.childCount; i++){
			t.GetChild(i).renderer.enabled = false;
		}
	}

	public void eliminarCuadricula(){
		if(cuadricula!=null){
			Destroy(cuadricula);
		}
	}

}
