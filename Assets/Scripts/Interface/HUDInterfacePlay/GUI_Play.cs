using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using _BaseDato;
namespace _Logica
{
    public class GUI_Play : MonoBehaviour
    {
        public AudioClip grillos;
			
        public AudioClip silvato;

        public float native_width = 480;
        public float native_height = 800;
        public GUISkin guiSkin;
        public string arma1;
        public string arma2;
        public Texture[] texturas;
        public int cont90seg = 0;
        //private controlMessi cm;
        //	public dbAccess db;
        private  dbAccess db;
        public int puntosAplicados = 0;
        public string estadoGuiActual = "play";
        public Puntuacion puntuacion;
        private bool hayNewValor = false;
        public bool paused = false;
        public bool ocultarGuiArma1 = false;       
        public bool ocultarGuiArma2 = false; 
        public List<ArmaSelected> listArmaSelec;
        bool sound = true;
        bool music = true;
        private Texture musicaText;
        private Texture sonido;

        // control para game over
        public int oportunidades = 0 ;
        public bool gameOver = false ;
        public int tiempoFinal = 30;

        //inicializar estilos
        private GUIStyle styleLabelArma1, styleLabelArma2, styleLabelBarraSuperior,
            styleLabelContador, styleLabelContPuntos, styleLabelTarjetas, styleBoxAdvance,
            styleButonAdvanceSelect, styleButonAdvancePlay, styleAdvanceNew, styleAdvanceNewsombra, styleAdvanceText,
            styleresume, stylepausedback, stylepausedresume, stylepausedrestart, stylepausedresumen, stylepausedselect,
            stylePrimeraOportunidad, styleSegunOport, styleTerceOport, stylePauseText, styleMusicOn, styleMusicOff, backRanking,
            textRanking, textDataRanking, textColorWhiteSmall, styleMessiFoto, styleCristFoto, styleHierva, varButtonBack, styleBack, styleRanking;

        private Rect windowRect;

        //variables del ranking
        public string resultado = "";
        public List<List<String>> tablaResult = new List<List<String>>();
        private string posicion = "";
        private string nombreUser = "";
        private string scoreUsuario = "";
        public Vector2 scrollPosition = Vector2.zero;
        public bool resultadoRecivido = false;
        public string nameEnviar = "";
        public bool datosEnviados = false;
        private int cantLlamadas = 0;

        private bool messiSelRank = true;
        private bool desmarcarMessi = false ;

        private bool crisSelRank = false;
        private bool desmarcarCrist = false ;

        public Texture imgMessi ;
        public Texture imgCrist ;

        private bool internetConexion = true;
        public string estadoCnexion = "Conecting...";
        public bool enviando = false; 

        // Use this for initialization
        void Start()
        {
            styleresume = guiSkin.FindStyle("resume");
            stylepausedback = guiSkin.FindStyle("pausedback");
            stylepausedrestart = guiSkin.FindStyle("pausedrestart");
            stylepausedresumen = guiSkin.FindStyle("pausedresume");
            stylepausedselect = guiSkin.FindStyle("pausedselect");

            audio.clip = silvato;
            audio.Play();
            listArmaSelec = new List<ArmaSelected>();

        }
		
        // Update is called once per frame
        void Update()
        {       
					
						
            if (cont90seg == tiempoFinal && estadoGuiActual != "advance" && paused == false)
            {
							
                GameObject.Find("Contenedor").SendMessage("stopBackLevel");
                audio.clip = silvato;
                audio.Play();	
                estadoGuiActual = "advance";								
                int nuevoTotalActual = puntosAplicados + puntuacion.GetTarjetas();
                puntuacion.SetTarjetas(nuevoTotalActual);
            }


        }
		
        void OnGUI()
        {
            float rx = Screen.width / native_width;
            float ry = Screen.height / native_height;
            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1)); 

            GUI.BeginGroup(new Rect(0, 0, 480, 800));
		
            obtenerInterfaz(estadoGuiActual);
				
            GUI.EndGroup();
        }

        public void obtenerInterfaz(string valGlob)
        {
            switch (valGlob)
            {
                case	"play":
                    buildGuiPlay();
                    break;
                case "advance":
                    buildAdvance();
                    break;
                case "pause":
                    BuildPaused();
                    break;
                case "ranking":
                    buildRanking();
                    break;
            //Muestra el juego pausado
            }
        }
        #region builGuiplay
        public void buildGuiPlay()
        {      

            //Armas
            styleLabelArma1 = guiSkin.FindStyle(arma1);
            styleLabelArma2 = guiSkin.FindStyle(arma2);
            styleLabelBarraSuperior = guiSkin.FindStyle("barraSuperior");
            styleLabelContador = guiSkin.FindStyle("label");
            styleLabelContPuntos = guiSkin.FindStyle("contPuntos");
            styleLabelTarjetas = guiSkin.FindStyle("tarjetas");
            styleBoxAdvance = guiSkin.FindStyle("advanceBack");
            styleButonAdvanceSelect = guiSkin.FindStyle("botonAdvanceSelect");
            styleButonAdvancePlay = guiSkin.FindStyle("botonAdvancePlay");
            styleAdvanceNew = guiSkin.FindStyle("new");
            styleAdvanceNewsombra = guiSkin.FindStyle("newsombra");
            styleAdvanceText = guiSkin.FindStyle("advanceText");
            stylePauseText = guiSkin.FindStyle("pauseText");
            stylePrimeraOportunidad = guiSkin.FindStyle("primeraOportunidad");
            styleSegunOport = guiSkin.FindStyle("segundaOportunidad");
            styleTerceOport = guiSkin.FindStyle("terceraOportunidad");
						
            switch (oportunidades)
            {
                case 1:
								
                    GUI.Box(new Rect(0, 0, 480, 800), "", stylePrimeraOportunidad);
								
                    break;
                case 2:
                    GUI.Box(new Rect(0, 0, 480, 800), "", styleSegunOport);
								
                    break;
						
            } 
			             

            if (!ocultarGuiArma1)
            {
                if (GUI.Button(new Rect(15, 616, 75, 75), "", styleLabelArma1))
                {
                    ocultarGuiArma1 = true;
                    ArmaSelected armSel = new ArmaSelected(1, true, arma1);
                    listArmaSelec.Add(armSel);
                }
            }

            if (!ocultarGuiArma2)
            {
                if (GUI.Button(new Rect(15, 710, 75, 75), "", styleLabelArma2))
                {
                    ocultarGuiArma2 = true;
                    ArmaSelected armSel = new ArmaSelected(2, true, arma2);
                    listArmaSelec.Add(armSel);
                }
            }

            GUI.Label(new Rect(0, 0, 480, 105), "", styleLabelBarraSuperior);
            //contador e imagen de tarjetas puntosAplicados.ToString ()
            GUI.Label(new Rect(66, 35, 83, 40), puntosAplicados.ToString(), styleLabelContPuntos);
            GUI.Label(new Rect(9, 26, 51, 45), "", styleLabelTarjetas);
            if (cont90seg >= 0 && cont90seg <= 15)
            {   
                //cont90seg * 1/30 
                styleLabelContador.normal.textColor = Color.Lerp(Color.green, Color.yellow, cont90seg * 0.03333f);
            }
			
            if (cont90seg >= 15 && cont90seg <= 28)
            {
                styleLabelContador.normal.textColor = Color.Lerp(Color.yellow, Color.red, (cont90seg - 15) * 0.03333f);
            }

            GUI.Label(new Rect(226, 17, 55, 57), cont90seg.ToString(), styleLabelContador);
						
            if (GUI.Button(new Rect(420, 20, 45, 45), "", styleresume))
            {
                estadoGuiActual = "pause";
            }

            if (oportunidades == 3 && gameOver == false)
            {								
                gameOver = true;
                tiempoFinal = cont90seg + 3;	
            }
            if (gameOver == true)
            {
                GUI.Box(new Rect(0, 0, 480, 800), "", styleTerceOport);
            }

        }
        #endregion
        #region build Pause
        public void BuildPaused()
        {    
            styleMusicOn = guiSkin.FindStyle("musicOn");
            styleMusicOff = guiSkin.FindStyle("musicOff");

            GameObject.Find("raizTransp/transportadorMax").GetComponent<MovTransportador>().ocultarPersPorpausa = true;

            //GameObject.Find ("Contenedor").SendMessage ("pauseBackLevel");
            if (paused == false)
            {
                paused = true;
                GameObject.Find("Contenedor").SendMessage("setMomentoPausa", Convert.ToInt32(Time.time));
						
            }
            if (music == true)
            {
                GameObject.Find("Contenedor").SendMessage("playBackLevel");
                musicaText = texturas [1];
            } else
			
            if (music == false)
            {
                GameObject.Find("Contenedor").SendMessage("pauseBackLevel");
                musicaText = texturas [0];
            }


            GUI.Box(new Rect(0, 0, 480, 800), "", stylepausedback);
            GUI.Label(new Rect(140, 46, 217, 40), "PAUSE", stylePauseText);

            music = GUI.Toggle(new Rect(200, 120, 80, 80), music, musicaText);


            if (music == false)
            {
                // GameObject.Find("Contenedor").SendMessage("playBackLevel");
                musicaText = texturas [1];
                // music = true;
            } else
				if (music == true)
            {
                // GameObject.Find("Contenedor").SendMessage("pauseBackLevel");
                musicaText = texturas [0];
                //  music = false;
            }

			
  
		

            if (GUI.Button(new Rect(40, 600, 400, 130), "SELECT LEVEL", stylepausedselect))
            {
                Application.LoadLevel("SelectPersonScene");
            }

            if (GUI.Button(new Rect(120, 200, 240, 130), "RESUME", stylepausedselect))
            {   
                GameObject.Find("raizTransp/transportadorMax").GetComponent<MovTransportador>().ocultarPersPorpausa = false;
                paused = false;
                estadoGuiActual = "play";
                //GameObject.Find ("Contenedor").SendMessage ("playBackLevel");
                GameObject.Find("Contenedor").SendMessage("setMomentoFinPausa", Convert.ToInt32(Time.time));
                print(cont90seg.ToString());
                GameObject.Find("Contenedor").GetComponent<tiempoPuntuacion>().CalcTiempoResumen();

            }

            if (GUI.Button(new Rect(115, 400, 249, 130), "RESTART", stylepausedselect))
            {
                Application.LoadLevel("EscenarioJuego");
            }

        }
        #endregion
        #region buildAdvance
        public void buildAdvance()
        {        
            styleRanking = guiSkin.FindStyle("ranking");


            if (!audio.isPlaying)
            {
                
                audio.clip = grillos;
                audio.Play();
            }
			            
            GUI.Box(new Rect(0, 0, 480, 800), "", styleBoxAdvance);



            GUI.Label(new Rect(127, 218, 217, 40), "ADVANCE", styleAdvanceText);

            if (puntuacion.GetMejorPuntuacion() < puntosAplicados)
            {
                puntuacion.SetMejorPuntuacion(puntosAplicados);
                hayNewValor = true;
								
            }
            if (hayNewValor)
            {
                GUI.Label(new Rect(250, 340, 200, 31), "new", styleAdvanceNewsombra);
                GUI.Label(new Rect(247, 338, 200, 31), "new", styleAdvanceNew);
            }
            GUI.Label(new Rect(291, 340, 200, 31), puntuacion.GetMejorPuntuacion().ToString(), styleLabelContPuntos);
            GUI.Label(new Rect(291, 433, 200, 31), puntosAplicados.ToString(), styleLabelContPuntos);
            GUI.Label(new Rect(291, 540, 200, 31), puntuacion.GetTarjetas().ToString(), styleLabelContPuntos);
            if (GUI.Button(new Rect(30, 725, 167, 68), "Select", styleButonAdvanceSelect))
            {

                GameObject.Find("Contenedor").SendMessage("actualizarBdPuntuacionEnLogica", puntuacion);
                GameObject.Find("Contenedor").SendMessage("actualizarNavegacion", "play");
                audio.Stop();
                Application.LoadLevel("SelectPersonScene");
            }
            if (GUI.Button(new Rect(291, 725, 167, 68), "Replay", styleButonAdvancePlay))
            {
                GameObject.Find("Contenedor").SendMessage("actualizarBdPuntuacionEnLogica", puntuacion);
                audio.Stop();				
                Application.LoadLevel("EscenarioJuego");
            }

            if (GUI.Button(new Rect(156, 40, 167, 107), "Ranking", styleRanking))
            {
                estadoGuiActual = "ranking";
            }

        }
        #endregion 

        public void buildRanking()
        {
            stylePauseText = guiSkin.FindStyle("pauseText");
            backRanking = guiSkin.FindStyle("backRanking");  
            textRanking = guiSkin.FindStyle("dataUserTextRanking");
            textDataRanking = guiSkin.FindStyle("infoTextRanking");
            textColorWhiteSmall = guiSkin.FindStyle("textColorWhiteSmall");       
            styleMessiFoto = guiSkin.FindStyle("messiFoto");
            styleCristFoto = guiSkin.FindStyle("cristFoto");
            styleHierva = guiSkin.FindStyle("hiervalarga");
            styleBack = guiSkin.FindStyle("back");

            string CM = "";


            GUI.Box(new Rect(0, 0, 480, 800), "", backRanking);
            GUI.Label(new Rect(160, 38, 160, 50), "Worldwide Ranking", stylePauseText);


            string idDevice = SystemInfo.deviceUniqueIdentifier;

            if (!resultadoRecivido && cantLlamadas < 3)
            {
                GameObject.Find("Contenedor").GetComponent<HSController>().DisplayScore(SystemInfo.deviceUniqueIdentifier, puntuacion.GetMejorPuntuacion());
                print("llamada a la web");
                cantLlamadas++;
				
            }
//            else
//            {
//                estadoCnexion = "Not internet conection";
//            }
            if (resultado == ":")
            {
                resultadoRecivido = false;
            }
            if (resultado != "" && resultado != ":")
            {
                resultadoRecivido = true;
               
            }
            if (resultado == "")
            {
                internetConexion = false;
            } else
            {
                internetConexion = true;
            }



            int distAltIni = 30;

            int anchoLabel = 130;
            
            int alturaLabel = 40;        //la tabla la hice con labeles, un label es una fokin celda... 
            
            int espacioEntreFilas = 5;  //espacio entre las fokin filas

          

            if (resultado != ":" && resultado != "")
            {
                enviando = false;
                mostrarLista();



                GUI.Label(new Rect(70, 300, 340, 80), "POSITIONS", styleHierva);                
                GUI.Label(new Rect(100, 117, 100, 50), "pos: ", textRanking);
                GUI.Label(new Rect(100, 167, 100, 50), "nick: ", textRanking);
                GUI.Label(new Rect(100, 217, 100, 50), "score: ", textRanking);                
                GUI.Label(new Rect(270, 117, 100, 50), posicion, textDataRanking);
                GUI.Label(new Rect(270, 167, 100, 50), nombreUser, textDataRanking);
                GUI.Label(new Rect(270, 217, 100, 50), scoreUsuario, textDataRanking);


                
                List<List<String>> tablaUsuarios = tablaResult;
                
                if (tablaUsuarios != null)
                {
                    scrollPosition = GUI.BeginScrollView(new Rect(0, 360, 480, 325), scrollPosition, new Rect(0, 0, 450, 500));
                    
                    for (int i = 0; i<tablaUsuarios.Count; i++)
                    {
                        
                        int sep = i * alturaLabel + i * espacioEntreFilas + distAltIni;


                        if (tablaUsuarios [i] [0] != posicion)
                        {
                            GUI.Label(new Rect(0, sep, anchoLabel, alturaLabel), tablaUsuarios [i] [0], textColorWhiteSmall); 
                        
                            GUI.Label(new Rect(anchoLabel + 1, sep, anchoLabel, alturaLabel), tablaUsuarios [i] [1], textColorWhiteSmall); 

                            GUI.Label(new Rect(2 * anchoLabel + 2, sep, anchoLabel, alturaLabel), tablaUsuarios [i] [2], textColorWhiteSmall); 

                            if (tablaUsuarios [i] [3] == "c")
                                GUI.Label(new Rect(3 * anchoLabel + 3, sep, anchoLabel, alturaLabel), "", styleCristFoto); 
                            if (tablaUsuarios [i] [3] == "m")
                                GUI.Label(new Rect(3 * anchoLabel + 3, sep, anchoLabel, alturaLabel), "", styleMessiFoto); 
                           
                        } else
                        {
                            GUI.Label(new Rect(0, sep, anchoLabel, alturaLabel), tablaUsuarios [i] [0], textRanking); 
                        
                            GUI.Label(new Rect(anchoLabel + 1, sep, anchoLabel, alturaLabel), tablaUsuarios [i] [1], textRanking); 
                        
                            GUI.Label(new Rect(2 * anchoLabel + 2, sep, anchoLabel, alturaLabel), tablaUsuarios [i] [2], textRanking); 
                           
                            if (tablaUsuarios [i] [3] == "c")
                                GUI.Label(new Rect(3 * anchoLabel + 3, sep, anchoLabel, alturaLabel), "", styleCristFoto); 
                            if (tablaUsuarios [i] [3] == "m")
                                GUI.Label(new Rect(3 * anchoLabel + 3, sep, anchoLabel, alturaLabel), "", styleMessiFoto); 
                       

                        }

                        if (tablaUsuarios [i] [0] == posicion)
                        {
                            nombreUser = tablaUsuarios [i] [1];
                            scoreUsuario = tablaUsuarios [i] [2];
                        }

                    }
                    GUI.EndScrollView();
                }      
                resultadoRecivido = true;
            } 

            if (!internetConexion)
            {   

                GUI.Label(new Rect(160, 611, 160, 50), estadoCnexion, textColorWhiteSmall);
            }

            if (enviando)
            {
                estadoCnexion = "sending...";
                GUI.Label(new Rect(160, 611, 160, 50), estadoCnexion, textColorWhiteSmall);
            }
        

            if (!resultadoRecivido && !datosEnviados && internetConexion)
            {
                int y = 200;

                GUI.Label(new Rect(193, 400 - y, 94, 22), "NICK", textRanking);               

                nameEnviar = GUI.TextField(new Rect(140, 462 - y, 205, 43), nameEnviar, 10, guiSkin.textField);

                GUI.Label(new Rect(193, 540 - y, 94, 22), "you are fan of ...", textRanking);

                messiSelRank = GUI.Toggle(new Rect(130, 610 - y, 100, 100), messiSelRank, imgMessi);
             
                if (messiSelRank == true)
                {   
                    crisSelRank = false;

                    CM = "m";
                } else
                {
                    crisSelRank = true;

                }
                crisSelRank = GUI.Toggle(new Rect(260, 610 - y, 100, 100), crisSelRank, imgCrist);        

                if (crisSelRank == true)
                {
                    // crisSelRank = false;
                    messiSelRank = false;
                    CM = "c";
                } else
                {
                    messiSelRank = true;
                }


                if (GUI.Button(new Rect(140, 750 - y, 205, 80), "submit", styleBack))
                {    
                    if (nameEnviar != "")
                    {
                        GameObject.Find("Contenedor").GetComponent<HSController>().addScore(nameEnviar, Convert.ToInt32(puntuacion.GetMejorPuntuacion()), SystemInfo.deviceUniqueIdentifier, CM);

                        datosEnviados = true;
                        cantLlamadas = 0;
                        enviando = true;

                    }
                }
            }
           

            if (GUI.Button(new Rect(164, 718, 140, 75), "BACK", styleBack))
            {    
                estadoGuiActual = "advance";
            }
               
        }

        public void mostrarLista()
        {
            
            List<List<String>> tabla = new List<List<String>>();                 
            String[] divPosiTabla = resultado.Split(':');       
            posicion = divPosiTabla [0];
            String[] extracTuplas = divPosiTabla [1].Split(';');
            for (int i = 0; i <extracTuplas.Length-1; i++)
            {
                List<String> fila = new List<String>();
                String[] elements = extracTuplas [i].Split(',');
                fila.Add(elements [0]);
                fila.Add(elements [1]);
                fila.Add(elements [2]);
                fila.Add(elements [3]);
                tabla.Add(fila);
                
            }
            
            tablaResult = tabla;
            
        }



    }




    public class ArmaSelected
    {

        public int numArma = 0;
        public bool seleccionada = false;
        public string nombreArma = "";

        public ArmaSelected(int numeroArma, bool sel, string name)
        {
            numArma = numeroArma;
            seleccionada = sel;
            nombreArma = name;

        }
        public ArmaSelected()
        {
        }

        public int NumArma
        {
            get
            {
                return numArma;
            }
            set
            {
                numArma = value;
            }
        }

        public bool Seleccionada
        { 
            get
            {
                return seleccionada;
            }
            set
            {
                seleccionada = value;
            }
        }

        public string NombreArma
        {
            get
            {
                return nombreArma;
            }
            set
            {
                nombreArma = value;
            }
        }
    }

	    
}
