using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotandoRuedaIzquierda : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	 
	}

	// Update is called once per frame
	void Update () {

		this.transform.Rotate(Vector3.down, Time.deltaTime*18,Space.Self);
		
	}
}
