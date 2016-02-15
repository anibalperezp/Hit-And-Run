using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using _Logica;
using _BaseDato;

public class GameManagerI : MonoBehaviour
{

    /// <summary>
    /// Clase controladora de todas las interfaces y escenarios del juego.
    /// Es necesario que se le hagan comentarios a las funsiones desarrolladas y las que estan por implementar
    /// para que sea facil de entender a la hora de invocarlas.
    /// </summary>

    public static ControlLogico controlLogico = new ControlLogico();
    public static ArrayList personajes;
    public static Resultado resultado;
    public  dbAccess db;
    private string lenguaje = "";
    public static string navegacion;

    public GameManagerI()
    {
        personajes = new ArrayList();
    }

    public ControlLogico getControlLogico()
    {
        return controlLogico;
    }

    public ArrayList getPersonajes()
    {
        return personajes;
    }
		
    void Start()
    {
        inicializandoDB();
    }

    public void inicializandoDB()
    {


        db.crearFicheroDat();

        cargarDatos(db);	
       
    }


#region Anibal
		
    /// <summary>
    /// Actualizar escenario seleccionado
    /// </summary>
    /// <param name="terreno">Terreno.</param>
    public void EscenarioSeleccionado(string terreno)
    {
        db.OpenReadDB();
        foreach (Escenario escenario in controlLogico.GetListEscenario())
        {
            if (escenario.GetNombre().Equals(terreno) && terreno.Equals("habana"))
            {
                db.Updating("nombre", "habana", "seleccionado", "true", "Escenario");
                db.Updating("nombre", "corner", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "estadio", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "callejon", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "taquillero", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "jungla", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "false", "Escenario");
                escenario.SetSeleccionado(true);
            } else
               				 if (escenario.GetNombre().Equals(terreno) && terreno.Equals("corner"))
            {
                db.Updating("nombre", "corner", "seleccionado", "true", "Escenario");
                db.Updating("nombre", "estadio", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "callejon", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "taquillero", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "jungla", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "habana", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "false", "Escenario");
                escenario.SetSeleccionado(true);
            } else
                  		     if (escenario.GetNombre().Equals(terreno) && terreno.Equals("estadio"))
            {
                db.Updating("nombre", "estadio", "seleccionado", "true", "Escenario");
                db.Updating("nombre", "callejon", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "taquillero", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "jungla", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "habana", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "corner", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "false", "Escenario");
                escenario.SetSeleccionado(true);
            } else
                        	if (escenario.GetNombre().Equals(terreno) && terreno.Equals("callejon"))
            {
                db.Updating("nombre", "callejon", "seleccionado", "true", "Escenario");
                db.Updating("nombre", "taquillero", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "jungla", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "habana", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "corner", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "estadio", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "false", "Escenario");
                escenario.SetSeleccionado(true);
            } else
                            if (escenario.GetNombre().Equals(terreno) && terreno.Equals("taquillero"))
            {
                db.Updating("nombre", "taquillero", "seleccionado", "true", "Escenario");
                db.Updating("nombre", "jungla", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "habana", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "corner", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "estadio", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "callejon", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "false", "Escenario");
                escenario.SetSeleccionado(true);
            } else
                                if (escenario.GetNombre().Equals(terreno) && terreno.Equals("jungla"))
            {
                db.Updating("nombre", "jungla", "seleccionado", "true", "Escenario");
                db.Updating("nombre", "habana", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "corner", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "estadio", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "callejon", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "taquillero", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "false", "Escenario");

                escenario.SetSeleccionado(true);
            } else
		                    	if (escenario.GetNombre().Equals(terreno) && terreno.Equals("volcan"))
            {
                db.Updating("nombre", "jungla", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "habana", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "corner", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "estadio", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "callejon", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "taquillero", "seleccionado", "false", "Escenario");
                db.Updating("nombre", "volcan", "seleccionado", "true", "Escenario");
				
                escenario.SetSeleccionado(true);
            }
            
        }
        db.SalvarData();
    }
		
    /// <summary>
    /// Actualizar personaje seleccionado
    /// </summary>
    /// <returns><c>true</c>, if seleccionado was personajed, <c>false</c> otherwise.</returns>
    /// <param name="personaje">Personaje.</param>
    public bool PersonajeSeleccionado(string personaje)
    {
        db.OpenReadDB();
        bool encontrado = false;
        foreach (Personaje person in personajes)
        {
            if (person.GetNombre().Equals(personaje) && personaje.Equals("messi"))
            {
                db.Updating("nombre", "messi", "seleccionado", "true", "Personaje");
                db.Updating("nombre", "cristiano", "seleccionado", "false", "Personaje");
                person.SetSeleccionado(true);
                encontrado = true;
            } else
                if (person.GetNombre().Equals(personaje) && personaje.Equals("cristiano"))
            {
                db.Updating("nombre", "cristiano", "seleccionado", "true", "Personaje");
                db.Updating("nombre", "messi", "seleccionado", "false", "Personaje");
                person.SetSeleccionado(true);
                encontrado = true;
            }
        }
        db.SalvarData();
        return encontrado;
    }

    /// <summary>
    /// Actualizar Idioma seleccionado
    /// </summary>
    /// <param name="idioma">Idioma.</param>
    public void IdiomaSeleccionado(string idioma)
    {
        db.OpenReadDB();
        int x = db.Updating("idiomaseleccionado", lenguaje, "idiomaseleccionado", idioma, "Idioma");
        db.SalvarData();
    }
		
    /// <summary>
    /// Obteners the idioma.
    /// </summary>
    /// <returns>The idioma.</returns>
    public string ObtenerIdioma()
    {
        return lenguaje;
    }
		
    /// <summary>
    /// Actualizar arma
    /// </summary>
    /// <param name="nombreArma">Nombre arma.</param>
    public void ArmaSeleccionado(string nombreArma1, string nombreArma2, string seleccionado)
    {
        db.OpenReadDB();
        //Hacerle u actualizar aparte para el arma entera
        db.Updating("nombre", "martillo", "seleccionado", "false", "Arma");
        db.Updating("nombre", "hielo", "seleccionado", "false", "Arma");
        db.Updating("nombre", "palogolf", "seleccionado", "false", "Arma");
        db.Updating("nombre", "rayo", "seleccionado", "false", "Arma");
        db.Updating("nombre", nombreArma1, "seleccionado", seleccionado, "Arma");
        db.Updating("nombre", nombreArma2, "seleccionado", seleccionado, "Arma");
        db.SalvarData();

    }

    public int ObtenerPuntuacionGneral()
    {
        Puntuacion puntosg = controlLogico.GetPuntuacion();
        return puntosg.GetTarjetas();
    }

    public int ObtenerMejorPuntuacionGneral()
    {
        Puntuacion puntosg = controlLogico.GetPuntuacion();
        return puntosg.GetMejorPuntuacion();
    }

    public string ObtenerNavegacion()
    {
        return navegacion;
    }

    public void actualizarNavegacion(string navegacion)
    {
        db.OpenReadDB();
        db.Updating("id", "1", "nameMenu", navegacion, "Navegacion");
        db.SalvarData();
    }

#endregion

#region Lesnier

    public void cargarDatos(dbAccess dbacces)
    {
        
        SaveGameManager sgm = new SaveGameManager();
        
        dbacces.OpenReadDB();
        sgm = dbacces.Sgm;
        
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

        #region Idioma
		
        lenguaje = sgm.Lenguaje;
        #endregion
				
        #region Navegacion
        navegacion = sgm.Navegacion;
        #endregion	



    }

#endregion
}

	    








