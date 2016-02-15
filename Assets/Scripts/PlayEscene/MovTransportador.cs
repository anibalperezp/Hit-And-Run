using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace _Logica
{
			

    public class MovTransportador : MonoBehaviour
    {
        public Transform cristiano;
        public Transform messi;
        public bool ocultarPersPorpausa = false;
        public Animator a ;
        private ArrayList tiemposList = new ArrayList();
        public bool poderGolpear = true;
        public bool posCentral = true;
        public bool posDerecha = false;
        public bool posIzquierda = false;
        public string condicionMovimiento = "";
        public float tFinEspera = 1;
        public float tFinEsperaDer = 0;
        public float tFinEsperaIzq = 0;
        public float tIniEspera = 0;
        private int contadorEfectInicial = 0;
        //textura de quemadura y congelacion
		        
        public bool textQuemaduraAplicada = false;
        public bool textCongelacionAplicada = false;
        public float tiempoDesaparicionTextura = 10f;
        public float momentoAparicionTex = 0;

        private GameManager gm;
        public static bool interruptorSalto = false;
        private GameObject personajeSelecto;
		        

        // puntuacion acumulada por el personaje antes de un pause

        public int puntosPause = 0;
        private string nombrePers = "";





        // Use this for initialization
				
        void Start()
        {     

            gm = GameObject.Find("Contenedor").GetComponent<GameManager>();
            //personajeSelecto = new GameObject ();
            llenarTiemposEspera();
            tFinEspera = Time.time - Time.fixedTime + timeEspera();
					    

						

        }

	
        // Update is called once per frame

        void Update()
        {
            if (Application.isPlaying)
            {
								
                if (personajeSelecto == null)
                {
					
                    if (gm.getPersonSelected() == "cristiano")
                    {
                        personajeSelecto = GameObject.Find("CristPrefab(Clone)");
                        nombrePers = "cristiano";													
                    }    
					
                    if (gm.getPersonSelected() == "messi")
                    {
                        personajeSelecto = GameObject.Find("MessiPrefab(Clone)");
                        nombrePers = "messi";					
                    } 
                }

                //	movTranspAnimator ();
                movTranspSinAnimator();
            }

            cambioDeTexturas();
            aparDecTexEfecto();

            if (ocultarPersPorpausa == true && personajeSelecto != null)
            {   
                print("resolver esto");
                
                if (nombrePers == "cristiano")
                {
                    
                    puntosPause = personajeSelecto.GetComponent<controlCristiano>().golpesRecividos;
                    
                }    
                
                if (nombrePers == "messi")
                {
                    
                    puntosPause = personajeSelecto.GetComponent<controlMessi>().golpesRecividos;
                    
                } 


                Destroy(personajeSelecto);
                personajeSelecto = null;
            }

            if (personajeSelecto == null && ocultarPersPorpausa == false)
            {
                GameObject.Find("Contenedor").GetComponent<GameManager>().SendMessage("instanciarPersonaje", gm.getPersonSelected());
              
                if (gm.getPersonSelected() == "cristiano")
                {

                    personajeSelecto = GameObject.Find("CristPrefab(Clone)");
                    personajeSelecto.GetComponent<controlCristiano>().golpesRecividos = puntosPause;
                }    
                
                if (gm.getPersonSelected() == "messi")
                {

                    personajeSelecto = GameObject.Find("MessiPrefab(Clone)");
                    personajeSelecto.GetComponent<controlMessi>().golpesRecividos = puntosPause;
                
                } 

            }
        }

		         
        public void aparDecTexEfecto()
        {

            if (tiempoDesaparicionTextura + momentoAparicionTex < Time.time && textQuemaduraAplicada && personajeSelecto != null)
            {

                textQuemaduraAplicada = false;
                contadorEfectInicial++;

            }
            if (tiempoDesaparicionTextura + momentoAparicionTex < Time.time && textCongelacionAplicada && personajeSelecto != null)
            {
							
                textCongelacionAplicada = false;
                contadorEfectInicial++;
            }
        }

        public void playEffect()
        {
            personajeSelecto.audio.Play();
        }

        public void pauseEffect()
        {
            personajeSelecto.audio.Pause();
        }

        public void cambioDeTexturas()
        {
            GUI_Play guiPlay = Camera.main.GetComponent<GUI_Play>();
            int puntosAplic = guiPlay.puntosAplicados;
			       
            if (!textQuemaduraAplicada || !textCongelacionAplicada && personajeSelecto != null)
            {
                if (puntosAplic >= 200 && puntosAplic <= 600 && personajeSelecto != null)
                    personajeSelecto.SendMessage("cambioTextGolpes", 1);   
			
                if (puntosAplic > 600 && puntosAplic <= 900 && personajeSelecto != null) 
                    personajeSelecto.SendMessage("cambioTextGolpes", 2);   
			
                if (puntosAplic >= 900 && personajeSelecto != null)
                    personajeSelecto.SendMessage("cambioTextGolpes", 3); 
            }
            if (textQuemaduraAplicada && personajeSelecto != null)
            {
                personajeSelecto.SendMessage("cambioTextGolpes", 4);
            }
            if (textCongelacionAplicada && personajeSelecto != null)
            {
                personajeSelecto.SendMessage("cambioTextGolpes", 5);
            }
            if (!textQuemaduraAplicada && !textCongelacionAplicada && puntosAplic < 200 && contadorEfectInicial != 0 && personajeSelecto != null)
            {
                personajeSelecto.SendMessage("cambioTextGolpes", 1);
            }
			
        }

        public void movTranspSinAnimator()
        {
						
            if (posCentral && !ocultarPersPorpausa && personajeSelecto != null)
            { 								
				
                if (tFinEspera < Time.time)
                {
					
                    poderGolpear = false;
                    int slectDirSalida = UnityEngine.Random.Range(0, 2);
                    if (slectDirSalida == 0)
                        condicionMovimiento = "ir_de_2_a_1";				                			
                    if (slectDirSalida == 1)
                        condicionMovimiento = "ir_de_2_a_3";	
					

					
                    switch (condicionMovimiento)
                    {
                    //salida para la derecha
                        case "ir_de_2_a_3":
                            playTransp2a3();	
                            personajeSelecto.SendMessage("SaltoEntradaPorIzquierda");
                            personajeSelecto.SendMessage("Idle");
                            posCentral = false;
                            posDerecha = true;
                            posIzquierda = false;
                            poderGolpear = false;
                            tFinEsperaDer = Time.time + 0.5f + animation ["2_a_3"].clip.length;		
						
                            break;
                    //salida para la izquierda
                        case "ir_de_2_a_1":
                            playTransp2a1();	
                            personajeSelecto.SendMessage("SaltoEntradaPorDerecha");
                            personajeSelecto.SendMessage("Idle");
                            posCentral = false;
                            posIzquierda = true;
                            posDerecha = false;
                            poderGolpear = false;
                            tFinEsperaIzq = Time.time + 0.5f + animation ["2_a_1"].clip.length;
                            break;						                
                    }	
										
                }				            
            }
            if (posDerecha && !ocultarPersPorpausa && personajeSelecto != null)
            {
                //entrada por la derecha
                if (tFinEsperaDer < Time.time)
                {
                    playTransp3a2();
                    personajeSelecto.SendMessage("SaltoEntradaPorDerecha");
                    personajeSelecto.SendMessage("Idle");                    														
                    posCentral = true;								
                    posDerecha = false;
                    posIzquierda = false;
                    poderGolpear = true;
                    tFinEspera = Time.time + timeEspera() + animation ["3_a_2"].clip.length;		
										
                }
            }
			
            if (posIzquierda && !ocultarPersPorpausa && personajeSelecto != null)
            {						
                //entrada por la izquierda
                if (tFinEsperaIzq < Time.time)
                {
                    playTransp1a2();
                    personajeSelecto.SendMessage("SaltoEntradaPorIzquierda");
                    personajeSelecto.SendMessage("Idle");
                    posCentral = true;								
                    posIzquierda = false;
                    posDerecha = false;
                    poderGolpear = true;
                    tFinEspera = Time.time + timeEspera() + animation ["1_a_2"].clip.length;	
										
                }													
            }
        }

        public void playTransp2a3()
        {
            animation.Play("2_a_3");
        }
        public void playTransp3a2()
        {
            animation.Play("3_a_2");
        }
        public void playTransp2a1()
        {
            animation.Play("2_a_1");
        }
        public void playTransp1a2()
        {
            animation.Play("1_a_2");
        }
		       


        /*	public void movTranspAnimator ()
				{
						//yield return new WaitForSeconds (5);
						if (posCentral) { 								
			            
								if (tFinEspera < Time.time) {
										
										poderGolpear = false;
										int slectDirSalida = UnityEngine.Random.Range (0, 2);
										if (slectDirSalida == 0)
												condicionMovimiento = "ir_de_2_a_1";				                			
										if (slectDirSalida == 1)
												condicionMovimiento = "ir_de_2_a_3";	
								

										switch (condicionMovimiento) {
												
										case "ir_de_2_a_3":
												a.SetBool ("ir_de_2_a_1", true);
												a.SetBool ("ir_de_1_a_2", false);
												a.SetBool ("ir_de_3_a_2", false);
												a.SetBool (condicionMovimiento, true);													
												posCentral = false;
												posDerecha = true;
												poderGolpear = false;
												tFinEsperaDer = Time.time + 0.002f;		
												break;
						
										case "ir_de_2_a_1":
												a.SetBool ("ir_de_1_a_2", false);
												a.SetBool ("ir_de_3_a_2", false);
												a.SetBool ("ir_de_2_a_3", false);
												a.SetBool (condicionMovimiento, true);														
												posCentral = false;
												posIzquierda = true;
												poderGolpear = false;
												tFinEsperaIzq = Time.time + 0.002f;
												break;						                
										}	
										personajeSelecto.SendMessage ("SaltoEntradaGenerica");
								}				            
						}
						if (posDerecha) {
							
								if (tFinEsperaDer < Time.time) {
					
										a.SetBool ("ir_de_1_a_2", false);
										a.SetBool ("ir_de_2_a_1", false);								
										a.SetBool ("ir_de_2_a_3", false);	
										a.SetBool ("ir_de_3_a_2", true);
										posCentral = true;								
										posDerecha = false;
										poderGolpear = true;
										tFinEspera = Time.time + timeEspera ();		
										personajeSelecto.SendMessage ("SaltoEntradaGenerica");
								}
						}

						if (posIzquierda) {				


								if (tFinEsperaIzq < Time.time) {
										a.SetBool ("ir_de_1_a_2", true);
										a.SetBool ("ir_de_2_a_1", false);								
										a.SetBool ("ir_de_2_a_3", false);	
										a.SetBool ("ir_de_3_a_2", false);
										posCentral = true;								
										posIzquierda = false;
										poderGolpear = true;
										tFinEspera = Time.time + timeEspera ();	
										personajeSelecto.SendMessage ("SaltoEntradaGenerica");
								}													
						}
					
						
				}*/

				




		#region Tiempo espera
        /// <summary>
        /// llena la lista de tiempos de espera.
        /// </summary>
        public	void llenarTiemposEspera()
        {
            tiemposList.Add(1f);
            tiemposList.Add(2f);
            tiemposList.Add(2.5f);
            tiemposList.Add(3f);
        }
        /// <summary>
        /// Devuelve un entero que indca la cantidad de 
        /// segundos que debe esperar el personaje en el centro de la pantalla.
        /// </summary>
        /// <returns>The espera.</returns>
        public float timeEspera()
        { 
					
            int index = UnityEngine.Random.Range(1, 5);
					       
            float val = (float)tiemposList [index - 1];
						
            print(val.ToString());

            return val;
		
        }

		#endregion

    }

}
