using UnityEngine;
using System;

using System.Configuration;
using System.Security;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using _Logica;

using System.Text;

//using Mono.Data.Sqlite;
using System.Collections;


namespace _BaseDato
{
    public class dbAccess : MonoBehaviour
    {

       
        private Stream stream ;
        public  SaveGameManager sgm ;



        public dbAccess()
        {
        }
               
        private static readonly dbAccess instance = new dbAccess();
             
        public dbAccess UniqueInstance
        {
            get { return instance;}
        }

        public SaveGameManager Sgm
        {
            get
            {
                return sgm;
            }
            set
            {
                sgm = value;
            }
        }
               
        public void OpenReadDB()
        {
            IFormatter formatter = new BinaryFormatter();  
            
            Stream stream = new FileStream(Application.persistentDataPath + "/" + "datos.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
                                   
            sgm = (SaveGameManager)formatter.Deserialize(stream);

            stream.Close();
        }

        public void SalvarData()
        {
            
            IFormatter formatter = new BinaryFormatter();
            
            Stream stream = new FileStream(Application.persistentDataPath + "/" + "datos.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            
            formatter.Serialize(stream, sgm);

            stream.Close();
            
        }



        public void crearFicheroDat()
        {                  
       
          
            FileInfo fi = new FileInfo(Application.persistentDataPath + "/" + "datos.dat");
            
            if (!fi.Exists)
            {
                IFormatter formatter = new BinaryFormatter();               
                                
                Stream stream = new FileStream(Application.persistentDataPath + "/" + "datos.dat", FileMode.Create, FileAccess.Write, FileShare.None);

              
                SaveGameManager salvaData;
                ControlLogico cl;
                Puntuacion punt;
                ArrayList larmas = new ArrayList();
                ArrayList lmembresia = new ArrayList();
                ArrayList lEscenario = new ArrayList();
                ArrayList lpersonajes = new ArrayList();
                string lenguaje; 
                string navegacion; 
                
                punt = new Puntuacion(0, 0);
                
                larmas.Add(new Arma("martillo", false));
                larmas.Add(new Arma("hielo", true));
                larmas.Add(new Arma("palogolf", true));
                larmas.Add(new Arma("rayo", false));
                
                lEscenario.Add(new Escenario("habana", false));
                lEscenario.Add(new Escenario("corner", true));
                lEscenario.Add(new Escenario("estadio", false));
                lEscenario.Add(new Escenario("callejon", false));
                lEscenario.Add(new Escenario("taquillero", false));
                lEscenario.Add(new Escenario("volcan", false));
                lEscenario.Add(new Escenario("jungla", false));
                
                lpersonajes.Add(new Personaje("cristiano", false));
                lpersonajes.Add(new Personaje("messi", true));
                
                lenguaje = "eng";
                navegacion = "main";
                
                cl = new ControlLogico(punt);
                cl.SetArmas(larmas);
                cl.SetListEscenario(lEscenario);
                cl.SetMembresia(lmembresia);
                
                
                salvaData = new SaveGameManager(cl, lpersonajes, lenguaje, navegacion);
                
                formatter.Serialize(stream, salvaData);

                stream.Close();
               
            }
        } 



        public int Updating(string itemToSelect, string valuedb, string itemtoModify, string valueob, string nameTable)
        {         
            try
            {
                switch (nameTable)
                {
                    case "Arma":
                        {
                            foreach (Arma arma  in sgm.ControlLogico.GetArmas())
                            {
                                if (arma.GetNombre() == valuedb)
                                {
                                             
                                    if (valueob == "true")
                                    {
                                        arma.SetSeleccionada(true);
                                    } else
                                    {
                                        arma.SetSeleccionada(false);
                                    }
                                    
                                }
                            }
                        }
                        break;
                    case "Escenario":
                        {

                            foreach (Escenario escenario  in sgm.ControlLogico.GetListEscenario())
                            {
                                
                                if (escenario.GetNombre() == valuedb)
                                {
                                    if (valueob == "true")
                                    {
                                        escenario.SetSeleccionado(true);
                                    } else
                                    {
                                        escenario.SetSeleccionado(false);
                                    }
                               
                                }
                            }
                        }
                        break;
                    case "Idioma":
                        {
                            sgm.Lenguaje = valueob;                        

                        }
                        break;
                    case "Membresia":
                        break;
                    case "Navegacion":
                        {
                            sgm.navegacion = valueob;
                        }
                        break;
                    case "Personaje":
                        {
                            foreach (Personaje personaje  in sgm.Personajes)
                            {
                            
                                if (personaje.GetNombre() == valuedb)
                                {
                                    if (valueob == "true")
                                    {
                                        personaje.SetSeleccionado(true);
                                    } else
                                    {
                                        personaje.SetSeleccionado(false);
                                    }
                                
                                }
                            }

                        }
                        break;
                    case "Puntuacion":
                        {
                            if (itemtoModify == "cant_tarjeta_general")
                            {
                                sgm.ControlLogico.GetPuntuacion().SetTarjetas(Convert.ToInt32(valueob));
                            }

                            if (itemtoModify == "puntuacion_mejor")
                            {
                                sgm.ControlLogico.GetPuntuacion().SetMejorPuntuacion(Convert.ToInt32(valueob));
                            }


                        }
                        break;
                    case "Trofeo":
                        break;
                }


            } catch (Exception e)
            {
                Debug.Log(e);             
                return 0;
            }
          
            return 1;
        }
    }

}
