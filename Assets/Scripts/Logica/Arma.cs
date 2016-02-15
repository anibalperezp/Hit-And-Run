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
        //private int dañoCombinado;
        //private int dañoNivel1;
        //	private int dañoNivel2;
        //	private int dañoNivel3;
	
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
//	public int GetDañoCombinado() {
//		return this.dañoCombinado;
//	}
//	public void SetDañoCombinado( int dañoCombinado) {
//		this.dañoCombinado = dañoCombinado;
//	}
	
//	public int GetDañoNivel1() {
//		return this.dañoNivel1;
//	}
//	public void SetDañoNivel1( int dañoNivel1) {
//		this.dañoNivel1 = dañoNivel1;
//	}
//	public int GetDañoNivel2() {
//		return this.dañoNivel2;
//	}
//	public void SetDañoNivel2( int dañoNivel2) {
//		this.dañoNivel2 = dañoNivel2;
//	}
//	public int GetDañoNivel3() {
//		return this.dañoNivel3;
//	}
//	public void SetDañoNivel3( int dañoNivel3) {
//		this.dañoNivel3 = dañoNivel3;
//	}

    }
}
