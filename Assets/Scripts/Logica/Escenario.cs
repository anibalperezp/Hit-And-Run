using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class Escenario
    {

        private string nombre;
        private bool bloqueado;
        private int precio;
        private bool seleccionado;

        public Escenario()
        {
        }

        public Escenario(string nombre, bool seleccionado)
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
