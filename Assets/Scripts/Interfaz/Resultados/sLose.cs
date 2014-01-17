using UnityEngine;
using System.Collections;

public class sLose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(-5,0,-1);
		iTween.MoveTo(gameObject, iTween.Hash("x", 0, "easeType", "easeInOutExpo", "delay", .1));
		Destroy (GameObject.Find("Control"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
