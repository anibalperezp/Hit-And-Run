using UnityEngine;
using System.Collections;

public class Combos : MonoBehaviour
{

		private int[] combo20 = new int[3];
		private int[] combo30 = new int[3];
		private int[] combo50 = new int[3];
		private int[] combo100 = new int[3];
		private int[] combo120 = new int[3];
		private int[] combo150 = new int[3];


		// Use this for initialization
		void Start ()
		{

				combo20 [0] = 5;
				combo20 [1] = 3;
				combo20 [2] = 1;

				combo30 [0] = 1;
				combo30 [1] = 3;
				combo30 [2] = 5;
		 
				combo50 [0] = 5;
				combo50 [1] = 1;
				combo50 [2] = 3;

				combo100 [0] = 50;
				combo100 [1] = 30;
				combo100 [2] = 20;

				combo120 [0] = 20;
				combo120 [1] = 30;
				combo120 [2] = 50;

				combo150 [0] = 30;
				combo150 [1] = 20;
				combo150 [2] = 50;

	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public ArrayList hayCombo (int[] patronCombo)
		{
				// result es un arreglo que en el primer elemento guarda 1 si existe combo o 0 si no, 
				// y en el segundo elemento guarda el valor del combo

				ArrayList result = new ArrayList ();
				result.Add (0);
				result.Add (0);

				if (patronCombo [0] == combo20 [0] && patronCombo [1] == combo20 [1] && patronCombo [2] == combo20 [2]) {
						result [0] = 1;
						result [1] = 20;
				}
				if (patronCombo [0] == combo30 [0] && patronCombo [1] == combo30 [1] && patronCombo [2] == combo30 [2]) {
						result [0] = 1;
						result [1] = 30;
				}
				if (patronCombo [0] == combo50 [0] && patronCombo [1] == combo50 [1] && patronCombo [2] == combo50 [2]) {
						result [0] = 1;
						result [1] = 50;
				}
				

				return result;

		}

		public ArrayList hayUltra (int[] patronUltra)
		{


				ArrayList result = new ArrayList ();
				result.Add (0);
				result.Add (0);

				if (patronUltra [0] == combo100 [0] && patronUltra [1] == combo100 [1] && patronUltra [2] == combo100 [2]) {
						result [0] = 1;
						result [1] = 100;
				}
		
				if (patronUltra [0] == combo120 [0] && patronUltra [1] == combo120 [1] && patronUltra [2] == combo120 [2]) {
						result [0] = 1;
						result [1] = 120;
			
				}
		
				if (patronUltra [0] == combo150 [0] && patronUltra [1] == combo150 [1] && patronUltra [2] == combo150 [2]) {
						result [0] = 1;
						result [1] = 150;
			
				}
				return result;

		}







}
