using UnityEngine;
using System.Collections;

public class desapIndicUltraCombo : MonoBehaviour
{


		public float  tiempoEnEscana = 0.5f;
		float momentoAparicion = 0;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (momentoAparicion + tiempoEnEscana < Time.time && this.gameObject.renderer.enabled == true)
						this.gameObject.renderer.enabled = false;
		}

		public void setMomentoAparicion (float moment)
		{
		
				momentoAparicion = moment;
		
		
		}
}
