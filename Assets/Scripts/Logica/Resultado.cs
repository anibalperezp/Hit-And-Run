using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace _Logica
{
    [Serializable]
    public class Resultado
    {

        private int puntuacionBatalla;
        private float scoreBatalla;

        public Resultado()
        {


        }

        public Resultado(int puntuacionBatalla, float scoreBatalla)
        {
            this.puntuacionBatalla = puntuacionBatalla;
            this.scoreBatalla = scoreBatalla;
        }
        

        public int GetPuntuacionBatalla()
        {
            return this.puntuacionBatalla;
        }
        public void SetPuntuacionBatalla(int puntuacionBatalla)
        {
            this.puntuacionBatalla = puntuacionBatalla;
        }
        public float GetScoreBatalla()
        {
            return this.scoreBatalla;
        }
        public void SetScoreBatalla(float scoreBatalla)
        {
            this.scoreBatalla = scoreBatalla;
        }

    }


}