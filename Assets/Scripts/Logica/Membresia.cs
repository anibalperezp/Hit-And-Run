using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class Membresia
    {

        private string nombre;
        private int min;
        private int max;
        private float scoreRequerido;
//	private string nombrePersonaje;
        private bool obtenida;

        public Membresia()
        {		
        }
        public Membresia(string nombre, int min, int max, float scoreRequerido, bool obtenida)
        {
            this.nombre = nombre;
            this.min = min;
            this.max = max;
            this.scoreRequerido = scoreRequerido;
            this.obtenida = obtenida;
        }
        
        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public int GetMin()
        {
            return this.min;
        }
        public void SetMin(int min)
        {
            this.min = min;
        }
        public int GetMax()
        {
            return this.max;
        }
        public void SetMax(int max)
        {
            this.max = max;
        }
        public float GetScoreRequerido()
        {
            return this.scoreRequerido;
        }
        public void SetScoreRequerido(float scoreRequerido)
        {
            this.scoreRequerido = scoreRequerido;
        }
        public bool GetObtenida()
        {
            return this.obtenida;
        }
        public void SetObtenida(bool obtenida)
        {
            this.obtenida = obtenida;
        }

//	public string GetNombrePersonaje() {
//		return this.nombrePersonaje;
//	}
//	public void SetNombrePersonaje( string nombrePersonaje) {
//		this.nombrePersonaje = nombrePersonaje;
//	}

    }

}
