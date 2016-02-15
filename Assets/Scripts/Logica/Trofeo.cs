using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class Trofeo
    {

        private string nombre;
        private bool bloqueado;
        private int precio;

        public Trofeo()
        {
        }

        public Trofeo(string nombre, bool bloqueado, int precio)
        {
            this.nombre = nombre;
            this.bloqueado = bloqueado;
            this.precio = precio;
        }
        

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public bool GetBloqueado()
        {
            return this.bloqueado;
        }
        public void SetBloqueado(bool bloqueado)
        {
            this.bloqueado = bloqueado;
        }
        public int GetPrecio()
        {
            return this.precio;
        }
        public void SetPrecio(int precio)
        {
            this.precio = precio;
        }

    }
}