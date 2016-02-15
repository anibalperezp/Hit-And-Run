using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotandoRuedaDerecha : MonoBehaviour {

	public GameObject rueda1;
	public GameObject rueda2;
	// Use this for initialization
	void Start () {
	 
	}

	// Update is called once per frame
	void Update () {
		// Slowly rotate the object around its X axis at 1 degree/second.
		//sun.transform.Rotate(Vector3.right, Time.deltaTime);
		
		// ... at the same time as spinning it relative to the global 
		// Y axis at the same speed.
		this.transform.Rotate(Vector3.up, Time.deltaTime*9, Space.Self);
	}
}
