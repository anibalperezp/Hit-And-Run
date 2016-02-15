using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class TexturaDa�o
    {

        private string nombre;
        private int da�o;

        public TexturaDa�o()
        {
        }

        public TexturaDa�o(string nombre, int da�o)
        {
            this.nombre = nombre;
            this.da�o = da�o;
        }
        

        public string GetNombre()
        {
            return this.nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public int GetDa�o()
        {
            return this.da�o;
        }
        public void SetDa�o(int da�o)
        {
            this.da�o = da�o;
        }

    }
}
