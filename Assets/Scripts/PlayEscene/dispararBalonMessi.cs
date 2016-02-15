using UnityEngine;
using System.Collections;

public class dispararBalonMessi : MonoBehaviour
{



		public GameObject balonFutbol;		 
		private GameObject objBalonInstanciado;
		private bool unDisparo = false;
		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		public void OnCollisionEnter (Collision collision)
		{
				if (collision.gameObject.name == "c_puntaPieIzq") {
						ContactPoint contact = collision.contacts [0];
						Vector3 pos = contact.point;
						Instantiate (balonFutbol, pos, Quaternion.identity);
						//	unDisparo = true;
				}
		
		}


}
