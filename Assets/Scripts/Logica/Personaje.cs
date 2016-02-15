using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class Personaje
    {

        private string nombre;
        //		private int dañoRecibCara;
        //		private int dañoRecibTronco;
        //		private int dañoRecibPiernas;
        //		private List<TexturaDaño> listTexturaDaño;
        private bool seleccionado;

        public Personaje()
        {
        }

        public Personaje(string nombre, bool seleccionado)
        {
            this.nombre = nombre;
            this.seleccionado = seleccionado;
        }
        

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
//			public int GetDañoRecibCara() {
//				return this.dañoRecibCara;
//			}
//			public void SetDañoRecibCara( int dañoRecibCara) {
//				this.dañoRecibCara = dañoRecibCara;
//			}
//			public int GetDañoRecibTronco() {
//				return this.dañoRecibTronco;
//			}
//			public void SetDañoRecibTronco( int dañoRecibTronco) {
//				this.dañoRecibTronco = dañoRecibTronco;
//			}
//			public int GetDañoRecibPiernas() {
//				return this.dañoRecibPiernas;
//			}
//			public void SetDañoRecibPiernas( int dañoRecibPiernas) {
//				this.dañoRecibPiernas = dañoRecibPiernas;
//			}
//			public List<TexturaDaño> GetListTexturaDaño() {
//				return this.listTexturaDaño;
//			}
//			public void SetListTexturaDaño( List<TexturaDaño> listTexturaDaño) {
//				this.listTexturaDaño = listTexturaDaño;
//			}
        public bool GetSeleccionado()
        { 
            return this.seleccionado;
        }
        public void SetSeleccionado(bool seleccionado)
        { 
            this.seleccionado = seleccionado;
        }

    }
}
