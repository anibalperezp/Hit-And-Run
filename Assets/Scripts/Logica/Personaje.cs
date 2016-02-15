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
        //		private int da�oRecibCara;
        //		private int da�oRecibTronco;
        //		private int da�oRecibPiernas;
        //		private List<TexturaDa�o> listTexturaDa�o;
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
//			public int GetDa�oRecibCara() {
//				return this.da�oRecibCara;
//			}
//			public void SetDa�oRecibCara( int da�oRecibCara) {
//				this.da�oRecibCara = da�oRecibCara;
//			}
//			public int GetDa�oRecibTronco() {
//				return this.da�oRecibTronco;
//			}
//			public void SetDa�oRecibTronco( int da�oRecibTronco) {
//				this.da�oRecibTronco = da�oRecibTronco;
//			}
//			public int GetDa�oRecibPiernas() {
//				return this.da�oRecibPiernas;
//			}
//			public void SetDa�oRecibPiernas( int da�oRecibPiernas) {
//				this.da�oRecibPiernas = da�oRecibPiernas;
//			}
//			public List<TexturaDa�o> GetListTexturaDa�o() {
//				return this.listTexturaDa�o;
//			}
//			public void SetListTexturaDa�o( List<TexturaDa�o> listTexturaDa�o) {
//				this.listTexturaDa�o = listTexturaDa�o;
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
