using System;
using System.Collections.Generic;
using System.Collections;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace _Logica
{        
    [Serializable]
    public class Puntuacion
    {
        private int tarjetas;
        private int mejorPuntuacion;
        private ArrayList listTrofeos;


        public Puntuacion()
        {

        }

        public Puntuacion(int tarjetas, int mejorPuntuacion)
        {
            this.tarjetas = tarjetas;
            this.mejorPuntuacion = mejorPuntuacion;
        }
        

        public int GetTarjetas()
        {
            return this.tarjetas;
        }

        public void SetTarjetas(int tarjetas)
        {
            this.tarjetas = tarjetas;
        }

        public int GetMejorPuntuacion()
        {
            return this.mejorPuntuacion;
        }

        public void SetMejorPuntuacion(int mejorpuntuacion)
        {
            this.mejorPuntuacion = mejorpuntuacion;
        }

        public ArrayList GetListTrofeos()
        {
            return this.listTrofeos;
        }

        public void SetListTrofeos(ArrayList listTrofeos)
        {
            this.listTrofeos = listTrofeos;
        }

//				public float GetScoreGeneral ()
//				{
//						return this.scoreGeneral;
//				}
//
//				public void SetScoreGeneral (float scoreGeneral)
//				{
//						this.scoreGeneral = scoreGeneral;
//				}

//	public string GetNombrePersonaje() {
//		return this.nombrePersonaje;
//	}
//
//	public void SetNombrePersonaje(string nombrePersonaje) {
//		this.nombrePersonaje = nombrePersonaje;
//	}

	

    }
}
