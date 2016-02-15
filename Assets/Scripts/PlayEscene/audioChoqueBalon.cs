using UnityEngine;
using System.Collections;

public class audioChoqueBalon : MonoBehaviour
{
		private int count ;
		public AudioClip cristales;
		public AudioClip golpeFinalGameOver;
		private GameObject contenedor;
		// Use this for initialization
		void Start ()
		{
				contenedor = GameObject.Find ("Contenedor");
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		public void OnTriggerEnter (Collider other)
		{           
				if (other.gameObject.name == "balon(Clone)") {
						count ++;
						if (count == 1 || count == 2) {
								audio.clip = cristales;
								audio.Play ();
						}
						if (count == 3) {
								audio.clip = golpeFinalGameOver;
								audio.Play ();
								contenedor.audio.Stop ();
						}
				}
		
		}
}
