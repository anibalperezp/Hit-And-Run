using UnityEngine;
using System.Collections;
using _Logica;
public class movimientoBalon : MonoBehaviour
{       
			
		 
		private GameObject objetivoBalon;
		private Vector3 dir;
		private Vector3 posicionInicialBalon;
	    
		//posiciones del objetivo de disparo
		private Vector3 pos1 = new Vector3 (0.05349799f, 0.3504323f, -7.150169f);  
		private Vector3 pos2 = new Vector3 (0.05349799f, 0.5300978f, -7.150169f); 
		 
		// Use this for initialization
		void Start ()
		{
				objetivoBalon = GameObject.Find ("objetivoBalon");
				posicionInicialBalon = transform.position;
				int p = UnityEngine.Random.Range (0, 2);
				switch (p) {
				case 0:
						objetivoBalon.transform.position = pos1;
						break;
				case 1:
						objetivoBalon.transform.position = pos2;
						break;
				}

		}
	
		// Update is called once per frame
		void Update ()
		{
				dir = objetivoBalon.transform.position - posicionInicialBalon;
				this.gameObject.transform.Translate (dir * 0.06f);
		}


		public void OnTriggerEnter (Collider other)
		{           
				if (other.gameObject.name == "limitTrayectBalon") {

						Camera.main.GetComponent<GUI_Play> ().oportunidades += 1;
						print (this.gameObject.name);
						Destroy (this.gameObject);
			            
				}

		}
   
}
