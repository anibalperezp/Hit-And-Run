using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class Arma
    {
        private string nombre;
        private bool seleccionada;
        //	private bool bloqueada;
        //	private string nombrePersonaje;
        //	private Arma combinacionArma;
        //private int da�oCombinado;
        //private int da�oNivel1;
        //	private int da�oNivel2;
        //	private int da�oNivel3;
	
        public Arma()
        {
		
        }

        public Arma(string nombre, bool seleccionada)
        {
            this.nombre = nombre;
            this.seleccionada = seleccionada;
        }
        

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
			
        public bool GetSeleccionada()
        {
            return this.seleccionada;
        }
        public void SetSeleccionada(bool seleccionada)
        {
            this.seleccionada = seleccionada;
        }
//	public string GetNombrePersonaje() {
//		return this.nombrePersonaje;
//	}
//	public void SetNombrePersonaje( string nombrePersonaje) {
//		this.nombrePersonaje = nombrePersonaje;
//	}
//	public Arma GetCombinacionArma() {
//		return this.combinacionArma;
//	}
//	public void SetCombinacionArma( Arma combinacionArma) {
//		this.combinacionArma = combinacionArma;
//	}
//	public int GetDa�oCombinado() {
//		return this.da�oCombinado;
//	}
//	public void SetDa�oCombinado( int da�oCombinado) {
//		this.da�oCombinado = da�oCombinado;
//	}
	
//	public int GetDa�oNivel1() {
//		return this.da�oNivel1;
//	}
//	public void SetDa�oNivel1( int da�oNivel1) {
//		this.da�oNivel1 = da�oNivel1;
//	}
//	public int GetDa�oNivel2() {
//		return this.da�oNivel2;
//	}
//	public void SetDa�oNivel2( int da�oNivel2) {
//		this.da�oNivel2 = da�oNivel2;
//	}
//	public int GetDa�oNivel3() {
//		return this.da�oNivel3;
//	}
//	public void SetDa�oNivel3( int da�oNivel3) {
//		this.da�oNivel3 = da�oNivel3;
//	}

    }
}
