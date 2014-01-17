using UnityEngine;
using System.Collections;

public class sControlSupremo : MonoBehaviour {

	public bool[] niveles;
	public static sControlSupremo instancia;

	// Use this for initialization
	void Start () {
		instancia = this;
		niveles = new bool[9];
		for(int i=0; i<9; i++)
			niveles[i] = false;
		niveles[0] = true;
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static sControlSupremo getInstancia{
		get{
			return instancia;	
		}
	}
}
