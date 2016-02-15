using UnityEngine;
using System.Collections;

public class MoviendoSelector : MonoBehaviour
{
		public Animator anim ;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void AnimacionDerecha ()
		{
				anim.SetBool ("poderirderecha", true);
				anim.SetBool ("poderirizquierda", false);
		}

		public void AnimacionIzquierda ()
		{
				anim.SetBool ("poderirizquierda", true);
				anim.SetBool ("poderirderecha", false);
		}
}
