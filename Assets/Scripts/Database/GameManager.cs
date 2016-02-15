using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using _Logica;
using _BaseDato;

namespace _Logica
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Clase controladora de todas las interfaces y escenarios del juego.
        /// Es necesario que se le hagan comentarios a las funsiones desarrolladas y las que estan por implementar
        /// para que sea facil de entender a la hora de invocarlas.
        /// </summary>

        public AudioLevelManager audioLM;
        private static GameManager instance;
        private static ControlLogico controlLogico = new ControlLogico();
        private static ArrayList personajes = new ArrayList();
        private static Resultado resultado;
        public  dbAccess db;
        public bool ComponentesListos = false;


        //Texturas de Escenarios
        public Texture textCorner;
        public Texture textCentroEstadio;
        public Texture textHabana;
        public Texture textCallejon;
        public Texture textTaquillero;
        public Texture textJungla;
        public Texture textVolcan;

        //Escenarios
        public Transform PlanoEscenario;
        public Transform estadio;
        public Transform taquillero;
        public Transform habana;
        public Transform jungla;
        public Transform callejon;
        private Transform terrenoGO; 
        //Personajes

        public Transform messi;
        public Transform cristiano;
        private Transform personajeGO; 

        // Armas 
        public GUI_Play[]  guiPlayScript;


        //Padre transportador
        public Transform padreTransportador;
		        
        //Var de estado
        private bool todoDestruido = false;

        private GameManager()
        {

        }

        /// <summary>
        /// Patron Singleton implementado.
        /// </summary>
        /// <value>The instance.</value>
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
		
        void Start()
        {
           
            cargarDatos(db);		
            inicializarComponentes();            
            	
            inicializarPuntuacion();
            ComponentesListos = true;
        }
        void Update()
        { 
            guiPlayScript = Camera.main.GetComponents<GUI_Play>();
            if (guiPlayScript [0].estadoGuiActual == "advance" && !todoDestruido)
            {
                Destroy(personajeGO.gameObject);
                Destroy(terrenoGO.gameObject);
                Destroy(padreTransportador.gameObject);
                todoDestruido = true;
            }
        }


#region Lesnier


		#region Carga, inicializacion e instanciacion de elementos del juego
        public void cargarDatos(dbAccess dbacces)
        {
            SaveGameManager sgm = new SaveGameManager();

            dbacces.OpenReadDB();
            sgm = dbacces.sgm;
        
            #region CargaArma
          
            controlLogico.SetArmas(sgm.ControlLogico.GetArmas());
            #endregion

            #region CargarEscenarios

            controlLogico.SetListEscenario(sgm.ControlLogico.GetListEscenario());

            #endregion 

            #region CargaMembrecias 
           
            controlLogico.SetMembresia(sgm.ControlLogico.GetMembresia());
      
            #endregion

            #region cargaPuntuacion

            controlLogico.SetPuntuacion(sgm.ControlLogico.GetPuntuacion());

            #endregion
	
            #region cargaPersonajes

            personajes = sgm.Personajes;
            #endregion

        }

        public void inicializarComponentes()
        {
            string nombEsceSelec = ""; 
            string nombPersSelec = "";
            ArrayList armasSelec = new ArrayList();
            #region inicializar Escenario
            ArrayList listEscenarios = controlLogico.GetListEscenario();
            bool parar = false;
            int i = 0;
            while (!parar)
            {
                if (((Escenario)listEscenarios [i]).GetSeleccionado())
                {
                    parar = true;	
                    nombEsceSelec = ((Escenario)listEscenarios [i]).GetNombre();
                }
                i++;
            }
            #endregion

            #region inicializar Personaje
            parar = false;
            int j = 0;
            while (!parar)
            {
                if (((Personaje)personajes [j]).GetSeleccionado())
                {
                    parar = true;	
                    nombPersSelec = ((Personaje)personajes [j]).GetNombre();
                }
                j++;
            }
            #endregion

            #region inicalizar Armas

            ArrayList listaArmas = new  ArrayList();
            listaArmas = controlLogico.GetArmas();
            int cont = 0;
            int k = 0;
            parar = false;
            while (!parar && !(k >= listaArmas.Count))
            { // es menor que 3 porque solamente el juegador se le daran 2  armas para jugar
                if (((Arma)listaArmas [k]).GetSeleccionada())
                {

                    armasSelec.Add(((Arma)listaArmas [k]));
                    cont++;
                    if (cont == 2)
                    {
                        parar = true;
                    }
                }
                k++;
            }
            #endregion
	
            instanciarEscenario(nombEsceSelec);

            instanciarPersonaje(nombPersSelec);

            instanciarArma(armasSelec); 

        }
		
        public void instanciarEscenario(string esce)
        {

            switch (esce)
            {
                case "corner":
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textCorner;
                    audioLM.audioEstadio();
                    break;
                case "estadio":
							//	terrenoGO = (Transform)Instantiate (estadio);
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textCentroEstadio;			
                    audioLM.audioEstadio();
                    break;
                case "habana":
								//terrenoGO = (Transform)Instantiate (habana);
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textHabana;
                    audioLM.audioHabanaPlay();
                    break;
                case "callejon":
							//	terrenoGO = (Transform)Instantiate (callejon);
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textCallejon;				
                    audioLM.audioPasillo();
                    break;
                case "taquillero":
							//	terrenoGO = (Transform)Instantiate (taquillero);
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textTaquillero;				
                    audioLM.audioCasillero();
                    break;
                case "jungla":
						   // 	terrenoGO = (Transform)Instantiate (jungla);
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textJungla;
                    audioLM.audioJungla();
                    break;
                case "volcan":
				           // 	terrenoGO = (Transform)Instantiate (jungla);
                    terrenoGO = (Transform)Instantiate(PlanoEscenario);
                    terrenoGO.GetChild(0).renderer.material.mainTexture = textVolcan;
                    audioLM.audioJungla();
                    break;

            }

        }

        public void instanciarPersonaje(string pers)
        {
            switch (pers)
            {
                case "messi":

                    personajeGO = (Transform)Instantiate(messi);
                    Vector3 v1 = personajeGO.transform.position;
                    v1.x = padreTransportador.transform.position.x;
                    personajeGO.transform.position = v1;
                    personajeGO.parent = padreTransportador;

                    break;

                case "cristiano":

                    personajeGO = (Transform)Instantiate(cristiano);
                    Vector3 v2 = personajeGO.transform.position;
                    v2.x = padreTransportador.transform.position.x;
                    personajeGO.transform.position = v2;
                    personajeGO.parent = padreTransportador;

                    break;
            }
        }

        public  void instanciarArma(ArrayList armas)
        {
            guiPlayScript = Camera.main.GetComponents<GUI_Play>(); 
            guiPlayScript [0].arma1 = ((Arma)armas [0]).GetNombre();
            guiPlayScript [0].arma2 = ((Arma)armas [1]).GetNombre();
        }
			
		#endregion puntuacion inicializar

        public void inicializarPuntuacion()
        {
            guiPlayScript [0].puntuacion = controlLogico.GetPuntuacion();
        }

        public void actualizarBdPuntuacionEnLogica(Puntuacion puntuacion)
        {
            db.OpenReadDB();
           
            controlLogico.SetPuntuacion(puntuacion);
            int cantTarjetasTemp = controlLogico.GetPuntuacion().GetTarjetas();
            int mejorPuntTemp = controlLogico.GetPuntuacion().GetMejorPuntuacion();
            db.Updating("id", "1", "cant_tarjeta_general", cantTarjetasTemp.ToString(), "Puntuacion");
            db.Updating("id", "1", "puntuacion_mejor", mejorPuntTemp.ToString(), "Puntuacion");
            db.SalvarData();

        }

	#endregion
		#region Actualizar Navegacion
        public void actualizarNavegacion(string navegacion)
        {
            db.OpenReadDB();	
            db.Updating("id", "1", "nameMenu", navegacion, "Navegacion");
            db.SalvarData();
						
        }

        public string getPersonSelected()
        {
            bool sel = false;
            int cont = 0;
            string nombrePersonaje = "";
            while (!sel)
            {
				
                if (((Personaje)personajes [cont]).GetSeleccionado())
                {
                    sel = true;
                    nombrePersonaje = ((Personaje)personajes [cont]).GetNombre();
                }
                cont ++;
				
            }
			
            return nombrePersonaje;
        }
		#endregion
  
    }


    [Serializable]
    public class SaveGameManager
    {


        private  ControlLogico controlLogico = new ControlLogico();
        private  ArrayList personajes = new ArrayList();       
        private string lenguaje = "";
        public string navegacion;

        public SaveGameManager(ControlLogico controlLogico, ArrayList personajes, string lenguaje, string  navegacion)
        {

            this.controlLogico = controlLogico;
            this.personajes = personajes;           
            this.lenguaje = lenguaje;
            this.navegacion = navegacion;

        }

        public SaveGameManager()
        {
        }


        public ControlLogico ControlLogico
        {
            get
            {
                return controlLogico;
            }
            set
            {
                controlLogico = value;
            }
        }

        public ArrayList Personajes
        {
            get
            {
                return personajes;
            }
            set
            {
                personajes = value;
            }
        }

       

        public string Lenguaje
        {
            get
            {
                return lenguaje;
            }
            set
            {
                lenguaje = value;
            }
        }

        public string Navegacion
        {
            get
            {
                return navegacion;
            }
            set
            {
                navegacion = value;
            }
        }
    }




}



