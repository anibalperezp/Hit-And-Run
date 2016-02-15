using UnityEngine;
using System.Collections;

public class animNumeroValGolpe : MonoBehaviour
{

		private float tiempoDestruccion = 0;

		// Use this for initialization
		void Start ()
		{
				tiempoDestruccion = Time.time + 1;
		}
	
		// Update is called once per frame
		void Update ()
		{
				this.transform.Translate (new Vector3 (0, 0.01f, 0));
		        
				if (tiempoDestruccion < Time.time) {
						destruct ();
				}
		}


		public void destruct ()
		{
					
				
				Destroy (this.gameObject);	

				
		}
}
