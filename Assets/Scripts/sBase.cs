using UnityEngine;
using System.Collections;

public class sBase : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y + 0.25f >= GameObject.Find("Limite").transform.position.y){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
