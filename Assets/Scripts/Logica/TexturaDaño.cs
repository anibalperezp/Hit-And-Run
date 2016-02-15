using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class TexturaDaño
    {

        private string nombre;
        private int daño;

        public TexturaDaño()
        {
        }

        public TexturaDaño(string nombre, int daño)
        {
            this.nombre = nombre;
            this.daño = daño;
        }
        

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public int GetDaño()
        {
            return this.daño;
        }
        public void SetDaño(int daño)
        {
            this.daño = daño;
        }

    }
}
