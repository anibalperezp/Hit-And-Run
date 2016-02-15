using UnityEngine;
using System.Collections;

public class AudioLevelManager : MonoBehaviour
{

		// Use this for initialization
		public AudioClip[] audioClipBackEscenario;



		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}


		public void audioHabanaPlay ()
		{
				audio.clip = audioClipBackEscenario [0];
				audio.Play ();
		}
		public void audioEstadio ()
		{
				audio.clip = audioClipBackEscenario [1];
				audio.Play ();
		}

		public void audioPasillo ()
		{
				audio.clip = audioClipBackEscenario [2];
				audio.Play ();
		}
		public void audioJungla ()
		{
				audio.clip = audioClipBackEscenario [3];
				audio.Play ();
		}

		public void audioCasillero ()
		{
				audio.clip = audioClipBackEscenario [4];
				audio.Play ();
		}
		public void stopBackLevel ()
		{
				audio.Stop ();
		}

		public void pauseBackLevel ()
		{
				audio.Pause ();
		}

		public void playBackLevel ()
		{
				audio.Play ();
		}

}
