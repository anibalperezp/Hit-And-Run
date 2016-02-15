
using UnityEngine;
using System.Collections;
using System;

namespace _Logica
{
		public class tiempoPuntuacion : MonoBehaviour
		{


				public int cont90seg;
				public GUI_Play[]  guiPlayScript;
				public float timeIniAplic;
				public int momentoPausa;
				public int momentofinPausa;
				public int timetranscurrido = 0;
				void Start ()
				{
						guiPlayScript = Camera.main.GetComponents<GUI_Play> ();
						timeIniAplic = Time.fixedTime;
				}

				void Update ()
				{
						contador90 ();
				}

				public void contador90 ()
				{
						int x = Convert.ToInt16 (Time.time - timeIniAplic);
						cont90seg = x - timetranscurrido;
						if (cont90seg <= 90)
								guiPlayScript [0].cont90seg = cont90seg;
						else {
								guiPlayScript [0].cont90seg = 90;
						}
				}

				public void setMomentoPausa (int x)
				{
						this.momentoPausa = x;
				}

				public void setMomentoFinPausa (int x)
				{
						this.momentofinPausa = x;
				}
				public void CalcTiempoResumen ()
				{
						timetranscurrido += this.momentofinPausa - this.momentoPausa;
						
						
				}

		}

}