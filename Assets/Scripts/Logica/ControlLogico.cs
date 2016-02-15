

using UnityEngine;


using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Logica
{
    [Serializable]
    public class ControlLogico
    {

        private Puntuacion puntuacion;
        private ArrayList armas;
        private ArrayList membresia;
        private ArrayList listEscenario;


        public ControlLogico()
        {
        }

        public ControlLogico(Puntuacion puntuacion)
        {
            this.puntuacion = puntuacion;
            this.armas = new ArrayList();
            this.membresia = new ArrayList();
            this.listEscenario = new ArrayList();
        }


        public Puntuacion GetPuntuacion()
        {
            return this.puntuacion;
        }
        public void SetPuntuacion(Puntuacion puntuacion)
        {
            this.puntuacion = puntuacion;
        }
        public ArrayList GetArmas()
        {
            return this.armas;
        }
        public void SetArmas(ArrayList armas)
        {
            this.armas = armas;
        }
        public ArrayList GetMembresia()
        {
            return this.membresia;
        }
        public void SetMembresia(ArrayList membresia)
        {
            this.membresia = membresia;
        }
        public ArrayList GetListEscenario()
        {
            return this.listEscenario;  
        }
        public void SetListEscenario(ArrayList listEscenario)
        {
            this.listEscenario = listEscenario;
        }

    }
}
