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
        //private int daņoCombinado;
        //private int daņoNivel1;
        //	private int daņoNivel2;
        //	private int daņoNivel3;
	
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
//	public int GetDaņoCombinado() {
//		return this.daņoCombinado;
//	}
//	public void SetDaņoCombinado( int daņoCombinado) {
//		this.daņoCombinado = daņoCombinado;
//	}
	
//	public int GetDaņoNivel1() {
//		return this.daņoNivel1;
//	}
//	public void SetDaņoNivel1( int daņoNivel1) {
//		this.daņoNivel1 = daņoNivel1;
//	}
//	public int GetDaņoNivel2() {
//		return this.daņoNivel2;
//	}
//	public void SetDaņoNivel2( int daņoNivel2) {
//		this.daņoNivel2 = daņoNivel2;
//	}
//	public int GetDaņoNivel3() {
//		return this.daņoNivel3;
//	}
//	public void SetDaņoNivel3( int daņoNivel3) {
//		this.daņoNivel3 = daņoNivel3;
//	}

    }
}
