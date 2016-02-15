using UnityEngine;
using System.Collections;
using System;
using _BaseDato;
using _Logica;

public class GUIController : MonoBehaviour
{
    private int p = 0;
    public float native_width = 480;
    public float NativeHeight = 800;
    public GUISkin guiSkin;
    private string _globalvar = "main";
    private string _personaje = "messi";
    private string _arma1 = " ";
    private string _arma2 = " ";
    public string nuevoterreno = "";
    private string[] listaRoles;
    private string[] listaDescripciones;
    private string idioma = "";
    private string rolName = "ING. L.G.L";
    private string rolDescrip = "";
    private GameObject objSprite01;
    private GameObject objSprite04;
    private GameObject objSpriteC1;
    private GameObject objSpriteC2;
    private GameObject objSpriteC3;
    private GameObject objSpriteC4;
    private GameObject objSpriteC5;
    private GameObject objSpriteC6;
    private GameObject objSpriteT1;
    private GameObject objSpriteT2;
    private GameObject objSpriteT3;
    private GameObject objSpriteT4;
    private GameObject objSpriteT5;
    private GameObject objSpriteT6;
    private GameObject objSpriteT7;
    public GameObject Obmenuoption;
    public GameObject ObCamaras;
    private bool camaraTerrenosRendereada = false;
    private bool spritesTerrenosObtenidos = false;
    public GameObject Obpersons;
    public GameObject Obmenuplay;
    public GameObject Obmenugallery;
    private bool galeriaRendereada = false;
    private bool spritesGalleryObtenidos = false;
    public GameObject Obmenusetting;
    public GameObject Obmenustatus;
    public GameObject Obmenuvolumensetting;
    public GameObject Obmenustatitis;
    public GameObject Seleccionador;
    public GameObject imagen;
    public GameObject Obmenucredit;
    public AudioSource clip;
    public AudioSource efect;
    public GameManagerI gm;
    public CamaraTerrenos camaraTerreno;
    public CamaraArmas camaraArmas;
    public Texture lesnier;
    public Texture anibal;
    public Texture yoel;
    public Texture iskander;
    public Texture jose;
    public Texture yerandy;
    public Texture Musica;
    private Texture[] listaImagenes;
    private Puntuacion puntuacion;
    private bool loadingPlay = false;
    private bool mostrarAlerta = false; 
    private float vidaAlerta = 0;
    private string textAlerta = "select 2 weapons and \n 1 scenary";

    private GUIStyle stylebtnplay, stylebtnstatus, styleoption, styleexit, stylefacebook, styleyoutube, stylebackmain,
        stylebackplay, stylebtnplaymenu, stylebtngalopt, stylebtnsettopt, stylebtnsettopt2, stylebtnbackopt, stylelabelgallery, stylelabelb1,
        stylelabelb2, stylelanguage, styleesp, styleeng, stylefra, stylepor, stylebtnstatus1, stylebtnstatus2, stylebtnstatus3, stylebtnstatus4,
        styleaudio, stylebrillo, stylesettingtitle, stylegallerytitle, styleoptiontitle, stylerolname, styleroldesc, styleLabelContPuntos,
        styleplayselecttitle, styleplaypower, styleplayweapon, styleplayeaponverde1, styleplaylevel, stylebackmainloading, styleLabelhelp,
        styleLabelrules, styleLabelrulesdesc, styleLabelhelptitle, styleLabelrulestitle, loadinPlayStyle, styleStatisticBack, styleSdvanceTitle,
        styleback, styleFondoAlerta;

    private String varPlay = "", varStatus = "", varOption = "", varExit = "", varTitleStatus = "", varHelp = "", varRules = "",
        varCredit = "", varButtonBack = "", varTitleHelp = "", varTitleRules = "", varTitleCredit = "",
        varCreditRole = "", varCreditRoleDescription = "", varTitleOption = "", varTitleSetting = "", varSettingSoundFX = "",
        varSettingLanguage = "", varButtonSave = "", varTitleGallery = "", varTitleEstadisitcas = "", varTitlePlay = "",
        varButtonGo = "", varWeapons = "", varLands = "", varAnibalRol = "", varAnibalDesc = "", varLesnierRol = "", varLesnierDesc = "", 
        varYoelRol = "", varYoelDesc = "", varIskoRol = "", varIskoDesc = "", varYeroRol = "", varYeroDesc = "", varJoseRol = "",
        varJoseDesc = "", varWeapon = "", varPowerWeapon = "", varWeapon2 = "", varMusica = "", varLevels = "", varLevel = "", varulesdesc = "", varadvanced = "";
	
    // Use this for initialization
 
    void Start()
    {
        gm.inicializandoDB();
        _globalvar = gm.ObtenerNavegacion();
        objSprite01 = GameObject.Find("UISprite01");
        objSprite04 = GameObject.Find("UISprite04");
        listaImagenes = new Texture[]
        {
            anibal,
            yoel,
            iskander,
            jose,
            yerandy,
            Musica,
            lesnier
        };
        varLesnierRol = "ING. L.G.L ";
        varAnibalRol = "ING. A.P.P ";
        varYoelRol = "Y.B.P";
        varIskoRol = "I.V.P";
        varYeroRol = "Y.L.M";
        varJoseRol = "J.J.J";
        listaRoles = new string[]
        {
            varAnibalRol,
            varYoelRol,
            varIskoRol,
            varJoseRol,
            varYeroRol,
            varMusica,
            varLesnierRol
        };
        idioma = gm.ObtenerIdioma();
        print("Cargo el idioma: " + idioma);

        #region Inicializando Idioma 

        if (idioma == "eng")
        {
            varLevels = "SCENERY";
            varPlay = "PLAY";
            varStatus = "STATUS";
            varOption = "OPTIONS";
            varExit = "EXIT";
            varTitleStatus = "STATUS";
            varHelp = "HELP";
            varRules = "RULES";
            varCredit = "CREDITS";
            varButtonBack = "BACK";
            varTitleHelp = "HELP";
            varTitleRules = "RULES";
            varTitleCredit = "CREDITS";
            varadvanced = "ADVANCED";
            varCreditRole = "";
            varCreditRoleDescription = "";
            varTitleOption = "OPTIONS";
            varTitleSetting = "SETTING";
            varSettingSoundFX = "SOUND FX";
            varSettingLanguage = "LANGUAGE";
            varButtonSave = "SAVE";
            varTitleGallery = "GALLERY"; 
            varPowerWeapon = "SELECT 2 WEAPONS";
            varTitleEstadisitcas = "ESTATISTIC";
            varTitlePlay = "SELECT RIVAL";
            textAlerta = "Select 2 weapons and \n 1 scenary";
            varulesdesc = "- There are not refunds! Ok? \n" +
                "You buy this, so you, you he… \n" +
                "THERE ARE NOT REFOUNDS!!! \n" +
                "– Choose the character you like… the less \n" +
                "(and… do it wisssely). \n" +
                "– It’s forbidden not to hit him in the head. \n" +
                "- It’s forbidden not to hit him in the legs. \n" +
                "- Also you could give him some good smashes.\n" +
                "whit your tougher weapon, yes, that’s fine. \n" +
                "- The more you crunch him \n" +
                "the bigger your score. \n" +
                "- Congratulations!! \n" +
                "At this point you should know how to play \n" +
                "PD: you are responsible of your acts, \n" +
                "and we are NOT, so behave yourself… \n" +
                "eat that! \n" +
                "PPD: Oh man! \n" +
                "We’re game developers! \n" +
                "That’s so cool!!";
            varAnibalDesc = "Roles desempeñados en el juego:" + "\n" + "- Planificacion de Proyecto" + "\n" + "- Arquitecto" + "\n" + "- Analista" + "\n" + "- Programador";
            varYoelDesc = "Roles desempeñados en el juego:" + "\n" + "- Director de Arte" + "\n" + "- Diseñador 2D" + "\n" + "- Diseñador de Wallpapper";
            varIskoDesc = "Roles desempeñados en el juego:" + "\n" + "- Jefe de Marketing" + "\n" + "- Modelador 3D";
            varYeroDesc = "Roles desempeñados en el juego:" + "\n" + "- Animador";
            varJoseDesc = "Roles desempeñados en el juego:" + "\n" + "- Modelador 3D";
            varMusica = "Roles desempeñados en el juego:" + "\n" + "\n" + "Banda Sonora:" + "\n" + "- Edesio Alejandro" + "\n" + "- Alberto Rodríguez Urra";
            varLesnierDesc = "Roles desempeñados en el juego:" + "\n" + "- Jefe de Proyecto" + "\n" + "- Arquitecto" + "\n" + "- Analista" + "\n" + "- Programador" + "\n" + "- Animacion de personajes";
            listaDescripciones = new string[]
            {
                varAnibalDesc,
                varYoelDesc,
                varIskoDesc,
                varJoseDesc,
                varYeroDesc,
                varMusica,
                varLesnierDesc
            };
            rolDescrip = varLesnierDesc;
        } else
					if (idioma == "esp")
        {
            varLevels = "SELECCION ESCENARIOS";
            varadvanced = "AVANCES";
            varPowerWeapon = "SELEC 2 ARMAS";
            varPlay = "JUEGA";
            varStatus = "ESTADO";
            varOption = "OPCIONES";
            varExit = "SALIR";
            varTitleStatus = "";
            varHelp = "AYUDA";
            varRules = "REGLAS";
            varCredit = "CREDITOS";
            varButtonBack = "ATRAS";
            varTitleHelp = "AYUDA";
            varTitleRules = "REGLAS";
            varTitleCredit = "CREDITOS";
            varCreditRole = "";
            varCreditRoleDescription = "";
            varTitleOption = "OPCIONES";
            varTitleSetting = "AJUSTES";
            varSettingSoundFX = "SONIDO FX";
            varButtonSave = "SALVAR";
            varTitleGallery = "GALERIA";
            varTitleEstadisitcas = "ESTADISTICA";
            varTitlePlay = "SELECCIONA RIVAL";
            varMusica = "Roles desempeñados en el juego:" + "\n" + "Banda Sonora:" + "\n" + "- Edesio Alejandro" + "\n" + "- Alberto Rodríguez Urra";
            varButtonGo = "JUEGA";
            varWeapons = "ARMAS";
            varLands = "TERRENOS";
            textAlerta = "Seleccione dos armas y \n un escenario";
            varulesdesc = "¡No hay devoluciones!,Ok?, \n" +
                " Tu compraste esto, así que, tu mm… \n" +
                "¡NO HAY DEVOLUCIONES!!\n" +
                " \n" +
                "– Escoge el personaje que te guste… menos \n" +
                "(y… hazlo sabiamente). \n" +
                "– Prohibido no darle por en la cabeza.  \n" +
                "- Prohibido no darle en las piernas. \n" +
                "- También pudieras darle algunos batacazos \n" +
                "con tu arma más dura, si eso está bien. \n" +
                "- Mientras más lo machaques mayor será \n" +
                "tu puntuación. \n" +
                "- Felicidades! \n" +
                "En este punto deberías saber cómo jugar. \n" +
                "\n" +
                "PD: tú eres responsable por tus actos y \n" +
                "nosotros NO, así que compórtate! \n" +
                "Cómete eso! \n" +
                "PPD: Siii!!! \n" +
                "Somos desarrolladores de Videojuegos! \n" +
                "Mola!";
            varSettingLanguage = "IDIOMAS";
            varAnibalDesc = "Roles desempeñados en el juego:" + "\n" + "- Planificacion de Proyecto" + "\n" + "- Arquitecto" + "\n" + "- Analista" + "\n" + "- Programador";
            varYoelDesc = "Roles desempeñados en el juego:" + "\n" + "- Director de Arte" + "\n" + "- Diseñador 2D" + "\n" + "- Diseñador de Wallpapper";
            varIskoDesc = "Roles desempeñados en el juego:" + "\n" + "- Jefe de Marketing" + "\n" + "- Modelador 3D";
            varYeroDesc = "Roles desempeñados en el juego:" + "\n" + "- Animador";
            varJoseDesc = "Roles desempeñados en el juego:" + "\n" + "- Modelador 3D";
            varLesnierDesc = "Roles desempeñados en el juego:" + "\n" + "- Jefe de Proyecto" + "\n" + "- Arquitecto" + "\n" + "- Analista" + "\n" + "- Programador" + "\n" + "- Animacion de personajes";
            listaDescripciones = new string[]
            {
                varAnibalDesc,
                varYoelDesc,
                varIskoDesc,
                varJoseDesc,
                varYeroDesc,
                varMusica,
                varLesnierDesc
            };
            rolDescrip = varLesnierDesc;
        }
        #endregion
					
        #region Control de Audio
        clip.Play();
		
        #endregion
		
        #region Incilizando GUI
		
        #region Main Menu
		
        stylebtnplay = guiSkin.FindStyle("btnplaymenu");
        stylebtnstatus = guiSkin.FindStyle("btnstatusmenu");
        styleoption = guiSkin.FindStyle("btnoptionmenu");
        styleexit = guiSkin.FindStyle("btnexitmenu");
        stylebackmain = guiSkin.FindStyle("stylebackmain");
        stylefacebook = guiSkin.FindStyle("facebook");
        styleyoutube = guiSkin.FindStyle("youtube");
		
        #endregion
		
        #region Play Menu
		
        stylebackplay = guiSkin.FindStyle("up");
        styleplayselecttitle = guiSkin.FindStyle("playselecttitle");
        styleplaypower = guiSkin.FindStyle("playpower");
        styleplayweapon = guiSkin.FindStyle("playweapon");
        styleplayeaponverde1 = guiSkin.FindStyle("playeaponverde1");
        styleplaylevel = guiSkin.FindStyle("playlevel");
        stylebackmainloading = guiSkin.FindStyle("loading");
        loadinPlayStyle = guiSkin.FindStyle("loadingPlay");
		

        #endregion
		
        #region Option Menu
		
        stylebtnplaymenu = guiSkin.FindStyle("btnplaymenu");
        stylebtngalopt = guiSkin.FindStyle("btngalopt");
        stylebtnsettopt = guiSkin.FindStyle("btnsettopt");
        stylebtnsettopt2 = guiSkin.FindStyle("btnsettopt2");
        stylebtnbackopt = guiSkin.FindStyle("btnbackopt");
        styleoptiontitle = guiSkin.FindStyle("optiontitle");
        styleback = guiSkin.FindStyle("back");
		
        #endregion
		
        #region Gallery Menu
        stylegallerytitle = guiSkin.FindStyle("gallerytitle");
        stylelabelgallery = guiSkin.FindStyle("labelgallery");
        stylelabelb1 = guiSkin.FindStyle("btnleft");
        stylelabelb2 = guiSkin.FindStyle("btnright");
		
        #endregion
		
        #region Setting Menu
		
        stylelanguage = guiSkin.FindStyle("labellanguage");
        styleesp = guiSkin.FindStyle("butesp");
        styleeng = guiSkin.FindStyle("buteng");
        stylefra = guiSkin.FindStyle("butfra");
        stylepor = guiSkin.FindStyle("butpor");
        styleaudio = guiSkin.FindStyle("settingaudio");
        stylebrillo = guiSkin.FindStyle("settingbright");
        stylesettingtitle = guiSkin.FindStyle("settingtitle");
		
        #endregion
		
        #region Status Menu
		
        stylebtnstatus1 = guiSkin.FindStyle("btnsettopt3");
        stylebtnstatus2 = guiSkin.FindStyle("btnsettopt4");
        stylebtnstatus3 = guiSkin.FindStyle("btnsettopt5");
        stylebtnstatus4 = guiSkin.FindStyle("btnbackopt");
		
        #endregion

        #region Credits Menu
				
        stylerolname = guiSkin.FindStyle("creditTitle");
        styleroldesc = guiSkin.FindStyle("creditDescription");

        #endregion

        #region Estadisticas

        styleLabelContPuntos = guiSkin.FindStyle("puntos");

        #endregion

        #region Help

        styleLabelhelp = guiSkin.FindStyle("help");
        styleLabelhelptitle = guiSkin.FindStyle("helptitle");

        #endregion

        #region Rules
		
        styleLabelrules = guiSkin.FindStyle("rules");
        styleLabelrulesdesc = guiSkin.FindStyle("rulesdesc");
        styleLabelrulestitle = guiSkin.FindStyle("rulestitle");

        #endregion
		
        #endregion
		
        #region Inicializando Render
		
        Obmenuoption.renderer.active = false;
        ObCamaras.renderer.active = false;
        Obpersons.renderer.active = false;
        Obmenuplay.renderer.active = false;
        Obmenugallery.renderer.active = false;
        Obmenusetting.renderer.active = false;
        Obmenustatus.renderer.active = false;
        Obmenuvolumensetting.renderer.active = false;
        Obmenucredit.renderer.active = false;
        Obmenustatitis.renderer.active = false;
        Seleccionador.renderer.active = false;
        #endregion
    }
	
    // Update is called once per frame
    void Update()
    {
		
        if (_globalvar == "option")
        {
            Obmenuoption.renderer.active = true;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenucredit.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
						
        } else
			if (_globalvar == "play")
        {
            ObCamaras.renderer.active = true;
            Obpersons.renderer.active = true;
            Obmenuplay.renderer.active = true;
            Obmenuoption.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenucredit.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = true;
            if (spritesTerrenosObtenidos == false)
            {
                camaraTerrenosRendereada = true;
            }

        } else
			if (_globalvar == "gallery")
        {
            Obmenugallery.renderer.active = true;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenucredit.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
            if (!spritesGalleryObtenidos)
            {
                galeriaRendereada = true;
            }

        } else
			if (_globalvar == "setting")
        {
            Obmenusetting.renderer.active = true;
            Obmenugallery.renderer.active = false;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenuvolumensetting.renderer.active = true;
            Obmenucredit.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
        } else
			if (_globalvar == "status")
        {
            Obmenustatus.renderer.active = true;
            Obmenusetting.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenucredit.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
        } else
			if (_globalvar == "credit")
        {
            Obmenucredit.renderer.active = true;
            Obmenustatus.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
        } else
			if (_globalvar == "statitics")
        {
            Obmenucredit.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
        } else
		if (_globalvar == "help")
        {
            Obmenucredit.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
        } else
		if (_globalvar == "rules")
        {
            Obmenucredit.renderer.active = false;
            Obmenustatus.renderer.active = false;
            Obmenusetting.renderer.active = false;
            Obmenugallery.renderer.active = false;
            Obmenuoption.renderer.active = false;
            ObCamaras.renderer.active = false;
            Obpersons.renderer.active = false;
            Obmenuplay.renderer.active = false;
            Obmenuvolumensetting.renderer.active = false;
            Obmenustatitis.renderer.active = false;
            Seleccionador.renderer.active = false;
        }
		
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.name.Equals("PlanoMessiSprite"))
                {
                    GameObject.Find("Seleccionador").GetComponent<MoviendoSelector>().AnimacionDerecha();
                    _personaje = "messi";
                    Debug.Log(_personaje);
                } else
				if (hit.collider.name.Equals("PlanoCristPrefab"))
                {
                    GameObject.Find("Seleccionador").GetComponent<MoviendoSelector>().AnimacionIzquierda();
                    _personaje = "cristiano";
                    Debug.Log(_personaje);
                }
                if (hit.collider.name.Equals("Imagen"))
                {
                    if (p < 6)
                    {
                        imagen.transform.renderer.material.mainTexture = listaImagenes [p];
                        rolName = listaRoles [p];
                        rolDescrip = listaDescripciones [p];
                        print(p.ToString() + " " + listaDescripciones [p]);
                        p++;
                    } else
											 if (p == 6)
                    {
                        imagen.transform.renderer.material.mainTexture = listaImagenes [p];
                        rolName = listaRoles [p];
                        rolDescrip = listaDescripciones [p];
                        p = 0;
                    }
                } 
            }
        }
    }
	
    void OnGUI()
    {
        GUI.skin = guiSkin;
        float rx = Screen.width / native_width;
        float ry = Screen.height / NativeHeight;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
        GUI.BeginGroup(new Rect(0, 0, 480, 800));
        ObtenerInterface(_globalvar);
        GUI.EndGroup();
    }
	
    public void ObtenerInterface(string pglobalvar)
    {
        switch (pglobalvar)
        {
            case "main":
                BuildingMainMenu();
                break;
            case "play":
                BuildingPlayMenu();
                break;
            case "status":
                BuildingStatusMenu();
                break;
            case "option":
                BuildingOptionMenu();
                break;
            case "gallery":
                BuildingGalleryMenu();
                break;
            case "setting":
                BuildingSettingMenu();
                break;
            case "credit":
                BuildingCredit();
                break;
            case "statitics":
                BuildingStatitics();
                break;
            case "help":
                BuildingHelp();
                break;
            case "rules":
                BuildingRules();
                break;
        }
    }
	
    public void BuildingMainMenu()
    {
        GUI.Label(new Rect(0, 0, 480, 800), "", stylebackmain);
        if (GUI.Button(new Rect(140, 410, 194, 75), varPlay, stylebtnplay))
        {
            efect.Play();			
            _globalvar = "play";

        }
		
        if (GUI.Button(new Rect(112, 495, 250, 84), "STATUS", stylebtnstatus))
        {
            efect.Play();			
            _globalvar = "status"; 
        }
		
        if (GUI.Button(new Rect(117, 579, 240, 82), varOption, styleoption))
        {
            efect.Play();			
            _globalvar = "option"; 
        }
		
        if (GUI.Button(new Rect(140, 664, 194, 75), varExit, styleexit))
        {
            efect.Play();
            Application.Quit();
        }
		
        /*if (GUI.Button(new Rect(190, 750, 40, 40), "", stylefacebook))
        {
            efect.Play();
        }
        if (GUI.Button(new Rect(240, 750, 40, 40), "", styleyoutube))
        {
            efect.Play();
        }*/
    }
	
    public void BuildingPlayMenu()
    {
        styleFondoAlerta = guiSkin.textArea;

        GUI.Label(new Rect(0, -21, 480, 800), "", stylebackplay);
        GUI.Label(new Rect(180, 340, 130, 80), varTitlePlay, styleplayselecttitle);
        GUI.Label(new Rect(180, 340, 130, 80), varPowerWeapon, styleplaypower);
       
        if (camaraTerrenosRendereada)
        {

            objSprite01 = GameObject.Find("UISlicedSprite01");
            objSpriteT1 = GameObject.Find("UISlicedSprite11");
            objSpriteT4 = GameObject.Find("UISlicedSprite14");
            objSpriteT5 = GameObject.Find("UISlicedSprite15");
            objSpriteT6 = GameObject.Find("UISlicedSprite16");
            objSpriteT7 = GameObject.Find("UISlicedSprite17");
            spritesTerrenosObtenidos = true;

            UISprite t1 = (UISprite)objSpriteT4.GetComponent("UISprite");
            int punt = gm.ObtenerPuntuacionGneral();
            if (punt > 4000)
            {
                t1.spriteName = "callejon 1";
            }
            UISprite t2 = (UISprite)objSpriteT5.GetComponent("UISprite");
            if (punt > 8000)
            {
                t2.spriteName = "jungla 1";
            }
            UISprite t3 = (UISprite)objSpriteT1.GetComponent("UISprite");
            if (punt > 12000)
            {
                t3.spriteName = "habana 1";
            }
            UISprite t4 = (UISprite)objSpriteT7.GetComponent("UISprite");
            if (punt > 20000)
            {
                t4.spriteName = "volcan 1";
            }
            UISprite t5 = (UISprite)objSpriteT6.GetComponent("UISprite");
            if (punt > 23000)
            {
                t5.spriteName = "taquilleroColor";
            }
       
            if (idioma == "eng")
            {
                _arma1 = camaraArmas.ObtenerArma1();
                if (_arma1.Equals(""))
                {
                    varWeapon = " ";
                } else
						if (_arma1.Equals("martillo"))
                {
                    varWeapon = "HAMMER";
                } else
						if (_arma1.Equals("hielo"))
                {
                    varWeapon = "ICE";
                } else
						if (_arma1.Equals("palogolf"))
                {
                    varWeapon = "GOLF CLUB";
                } else
						if (_arma1.Equals("rayo"))
                {
                    varWeapon = "THUNDERBOLT";
                }
            } else
					if (idioma == "esp")
            {
                _arma1 = camaraArmas.ObtenerArma1();
                if (_arma1.Equals(""))
                {
                    varWeapon = " ";
                } else
							if (_arma1.Equals("martillo"))
                {
                    varWeapon = "MARTILLO";
                } else
							if (_arma1.Equals("hielo"))
                {
                    varWeapon = "HIELO";
                } else
							if (_arma1.Equals("palogolf"))
                {
                    varWeapon = "PALO DE GOLF";
                } else
							if (_arma1.Equals("rayo"))
                {
                    varWeapon = "RAYO";
                }
            }
            if (idioma == "eng")
            {
                _arma2 = camaraArmas.ObtenerArma2();
                nuevoterreno = camaraTerreno.ObtenerTerreno();
                if (_arma2.Equals(""))
                {
                    varWeapon2 = " ";
                } else
							if (_arma2.Equals("martillo"))
                {
                    varWeapon2 = "HAMMER";
                } else
								if (_arma2.Equals("hielo"))
                {
                    varWeapon2 = "ICE";
                } else
									if (_arma2.Equals("palogolf"))
                {
                    varWeapon2 = "GOLF CLUB";
                } else
										if (_arma2.Equals("rayo"))
                {
                    varWeapon2 = "THUNDERBOLT";
                }

                if (nuevoterreno.Equals(""))
                {
                    varLevel = " ";
                } else
							if (nuevoterreno.Equals("habana"))
                {
                    varLevel = "HAVANA";
                } else
								if (nuevoterreno.Equals("corner"))
                {
                    varLevel = "CORNER";
                } else
									if (nuevoterreno.Equals("estadio"))
                {
                    varLevel = "STADIUM";
                } else
										if (nuevoterreno.Equals("callejon"))
                {
                    varLevel = "BACK STREET";
                } else
											if (nuevoterreno.Equals("jungla"))
                {
                    varLevel = "JUNGLE";
                } else
			                                   if (nuevoterreno.Equals("taquillero"))
                {
                    varLevel = "CLOSETS";
                } else
			                                      if (nuevoterreno.Equals("volcan"))
                {
                    varLevel = "VOLCANO";
                }

            } else
						if (idioma == "esp")
            {
                _arma2 = camaraArmas.ObtenerArma2();
                nuevoterreno = camaraTerreno.ObtenerTerreno();
                if (_arma2.Equals(""))
                {
                    varWeapon2 = " ";
                } else
								if (_arma2.Equals("martillo"))
                {
                    varWeapon2 = "MARTILLO";
                } else
									if (_arma2.Equals("hielo"))
                {
                    varWeapon2 = "HIELO";
                } else
										if (_arma2.Equals("palogolf"))
                {
                    varWeapon2 = "PALO DE GOLF";
                } else
											if (_arma2.Equals("rayo"))
                {
                    varWeapon2 = "RAYO";
                }
                if (nuevoterreno.Equals(""))
                {
                    varLevel = " ";
                } else
								if (nuevoterreno.Equals("habana"))
                {
                    varLevel = "HABANA";
                } else
								if (nuevoterreno.Equals("corner"))
                {
                    varLevel = "ESQUINA";
                } else
								if (nuevoterreno.Equals("estadio"))
                {
                    varLevel = "ESTADIO";
                } else
								if (nuevoterreno.Equals("callejon"))
                {
                    varLevel = "CALLEJON";
                } else
								if (nuevoterreno.Equals("jungla"))
                {
                    varLevel = "JUNGLA";
                } else
			                    if (nuevoterreno.Equals("taquillero"))
                {
                    varLevel = "TAQUILLERO";
                } else
			                    if (nuevoterreno.Equals("volcan"))
                {
                    varLevel = "VOLCAN";
                }
            }
            GUI.Label(new Rect(200, 340, 130, 80), varWeapon2, styleplayweapon);
            GUI.Label(new Rect(-10, 340, 130, 80), varWeapon, styleplayweapon);
            GUI.Label(new Rect(100, 420, 130, 80), varLevels, styleplaylevel);
            GUI.Label(new Rect(120, 514, 130, 80), varLevel, styleplayweapon);
            #region Cambio de Texturas (Armas)

				
            UISprite martillo = (UISprite)objSprite01.GetComponent("UISprite");
            int puntgmartillo = gm.ObtenerPuntuacionGneral();
            if (puntgmartillo > 2500)
            {
                martillo.spriteName = "martillo";
            }
            objSprite04 = GameObject.Find("UISlicedSprite04");
            UISprite rayo = (UISprite)objSprite04.GetComponent("UISprite");
            int puntgryo = gm.ObtenerPuntuacionGneral();
            if (puntgryo > 4500)
            {
                rayo.spriteName = "rayo";
            }
            #endregion
				


            if (GUI.Button(new Rect(52, 718, 176, 80), varButtonBack, styleback))
            {
                efect.Play();
                _globalvar = "main";
                gm.actualizarNavegacion(_globalvar);
                camaraTerrenosRendereada = false;
                spritesTerrenosObtenidos = false;
            }
		
            if (GUI.Button(new Rect(310, 718, 176, 80), "GO", styleback))
            {
                efect.Play();
                if (_arma1 != "" && _arma2 != "")
                {
                    loadingPlay = true;
                    gm.ArmaSeleccionado(_arma1, _arma2, "true");
                    gm.EscenarioSeleccionado(nuevoterreno);
                    Debug.Log("Selecciono personaje " + _personaje + " correctamente");
                    Debug.Log("Selecciono arma " + _arma1 + " correctamente");
                    gm.PersonajeSeleccionado(_personaje);
                    Application.LoadLevel("EscenarioJuego");

                } else
                {
                    mostrarAlerta = true;
                    vidaAlerta = Time.time + 2;
                }

            }
            if (mostrarAlerta && vidaAlerta > Time.time)
            {
                GUI.Box(new Rect(100, 300, 280, 70), textAlerta, styleFondoAlerta);

            } else
            {
                if (mostrarAlerta == true)
                {
                    mostrarAlerta = false;
                    vidaAlerta = 0;
                }
            }

            if (Application.isLoadingLevel.Equals(true))
            {
                GUI.Box(new Rect(0, 0, 480, 800), "", loadinPlayStyle);
            }

         

        }
    }
	
    public void BuildingOptionMenu()
    {
        GUI.Label(new Rect(180, 340, 130, 80), varOption, styleoptiontitle);	
        if (GUI.Button(new Rect(117, 410, 230, 86), varTitleSetting, stylebtngalopt))
        {
            efect.Play();
            _globalvar = "setting";
        }
		
        if (GUI.Button(new Rect(118, 495, 230, 86), varTitleGallery, stylebtnsettopt))
        {
            efect.Play();		
            _globalvar = "gallery";
        }
		
        if (GUI.Button(new Rect(88, 579, 297, 86), varTitleEstadisitcas, stylebtnsettopt2))
        {
            efect.Play();		
            _globalvar = "statitics";
        }
		
        if (GUI.Button(new Rect(149, 664, 176, 70), varButtonBack, stylebtnbackopt))
        {
            efect.Play();
            _globalvar = "main";
        }

    }
	
    public void BuildingGalleryMenu()
    {
        GUI.Label(new Rect(0, 0, 480, 800), "", stylelabelgallery);
        GUI.Label(new Rect(180, 340, 130, 80), varTitleGallery, stylegallerytitle);

        if (galeriaRendereada)
        {
            objSpriteC1 = GameObject.Find("UISpriteC1");
            objSpriteC2 = GameObject.Find("UISpriteC2");
            objSpriteC3 = GameObject.Find("UISpriteC3");
            objSpriteC4 = GameObject.Find("UISpriteC4");
            objSpriteC5 = GameObject.Find("UISpriteC5");
            objSpriteC6 = GameObject.Find("UISpriteC6");
            spritesGalleryObtenidos = true;
            

            UISprite bronce = (UISprite)objSpriteC1.GetComponent("UISprite");
            int punt = gm.ObtenerPuntuacionGneral();
            if (punt > 2000)
            {
                bronce.spriteName = "5";
            }
            UISprite plata = (UISprite)objSpriteC2.GetComponent("UISprite");
            if (punt > 8000)
            {
                plata.spriteName = "3";
            }
            UISprite oro = (UISprite)objSpriteC3.GetComponent("UISprite");
            if (punt > 14000)
            {
                oro.spriteName = "0";
            }
            UISprite copa3 = (UISprite)objSpriteC4.GetComponent("UISprite");
            if (punt > 22000)
            {
                copa3.spriteName = "0";
            }
            UISprite copa2 = (UISprite)objSpriteC5.GetComponent("UISprite");
            if (punt > 30000)
            {
                copa2.spriteName = "0";
            }
            UISprite copa1 = (UISprite)objSpriteC6.GetComponent("UISprite");
            if (punt > 40000)
            {
                copa1.spriteName = "0";
            }

            if (GUI.Button(new Rect(175, 718, 176, 80), varButtonBack, styleback))
            {
                efect.Play();
                _globalvar = "option";
                galeriaRendereada = false;
                spritesGalleryObtenidos = false;
            }
            
        }
    }
	
    public void BuildingSettingMenu()
    {
        GUI.Label(new Rect(180, 340, 130, 120), varTitleSetting, stylesettingtitle);
        GUI.Label(new Rect(180, 340, 130, 80), varSettingLanguage, stylelanguage);
        if (GUI.Button(new Rect(320, 230, 70, 60), "", styleesp))
        {
            efect.Play();			
            varLevels = "ESCENARIOS";
            varPowerWeapon = "SELEC 2 ARMAS";
            varPlay = "JUEGA";
            varStatus = "ESTADO";
            varOption = "OPCIONES";
            varExit = "SALIR";
            varTitleStatus = "";
            varHelp = "AYUDA";
            varRules = "REGLAS";
            varCredit = "CREDITOS";
            varButtonBack = "ATRAS";
            varTitleHelp = "AYUDA";
            varTitleRules = "REGLAS";
            varTitleCredit = "CREDITOS";
            varTitleOption = "OPCIONES";
            varTitleSetting = "AJUSTES";
            varSettingSoundFX = "SONIDO FX";
            varButtonSave = "SALVAR";
            varTitleGallery = "GALERIA";
            varadvanced = "AVANCES";
            varTitleEstadisitcas = "ESTADISTICA";
            varTitlePlay = "SELECCIONA OPONENTE";
            varButtonGo = "JUEGA";
            varWeapons = "ARMAS";
            varLands = "TERRENOS";
            varMusica = "Roles desempeñados en el juego:" + "\n" + "Banda Sonora:" + "\n" + "- Edesio Alejandro" + "\n" + "- Alberto Rodríguez Urra";
            varSettingLanguage = "IDIOMAS";
            idioma = "esp";
            textAlerta = "Seleccione dos armas y \n un escenario";
            varulesdesc = "¡No hay devoluciones!,Ok?, \n" +
                " Tu compraste esto, así que, tu mm… \n" +
                "¡NO HAY DEVOLUCIONES!!\n" +
                " \n" +
                "– Escoge el personaje que te guste… menos \n" +
                "(y… hazlo sabiamente). \n" +
                "– Prohibido no darle por en la cabeza.  \n" +
                "- Prohibido no darle en las piernas. \n" +
                "- También pudieras darle algunos batacazos \n" +
                "con tu arma más dura, si eso está bien. \n" +
                "- Mientras más lo machaques mayor será \n" +
                "tu puntuación. \n" +
                "- Felicidades! \n" +
                "En este punto deberías saber cómo jugar. \n" +
                "\n" +
                "PD: tú eres responsable por tus actos y \n" +
                "nosotros NO, así que compórtate! \n" +
                "Cómete eso! \n" +
                "PPD: Siii!!! \n" +
                "Somos desarrolladores de Videojuegos! \n" +
                "Mola!";
        }
        if (GUI.Button(new Rect(90, 230, 70, 60), "", styleeng))
        {
            efect.Play();
            varLevels = "SCENARY";
            varadvanced = "ADVANCED";
            varPlay = "PLAY";
            varStatus = "STATUS";
            varOption = "OPTIONS";
            varExit = "EXIT";
            varTitleStatus = "STATUS";
            varHelp = "HELP";
            varRules = "RULES";
            varCredit = "CREDITS";
            varButtonBack = "BACK";
            varTitleHelp = "HELP";
            varTitleRules = "RULES";
            varTitleCredit = "CREDITS";
            varTitleOption = "OPTIONS";
            varTitleSetting = "SETTING";
            varSettingSoundFX = "SOUND FX";
            varSettingLanguage = "LANGUAGE";
            varButtonSave = "SAVE";
            varTitleGallery = "GALLERY"; 
            varMusica = "Roles desempeñados en el juego:" + "\n" + "Banda Sonora:" + "\n" + "- Edesio Alejandro" + "\n" + "- Alberto Rodríguez Urra";
            varPowerWeapon = "SELECT 2 WEAPONS";
            varTitleEstadisitcas = "ESTATISTIC";
            varTitlePlay = "SELECT OPONENT";
            idioma = "eng";
            textAlerta = "Select 2 weapons and \n 1 scenary";
            varulesdesc = "- There are not refunds! Ok? \n" +
                "You buy this, so you, you he… \n" +
                "THERE ARE NOT REFOUNDS!!! \n" +
                "– Choose the character you like… the less \n" +
                "(and… do it wisssely). \n" +
                "– It’s forbidden not to hit him in the head. \n" +
                "- It’s forbidden not to hit him in the legs. \n" +
                "- Also you could give him some good smashes.\n" +
                "whit your tougher weapon, yes, that’s fine. \n" +
                "- The more you crunch him \n" +
                "the bigger your score. \n" +
                "- Congratulations!! \n" +
                "At this point you should know how to play \n" +
                "PD: you are responsible of your acts, \n" +
                "and we are NOT, so behave yourself… \n" +
                "eat that! \n" +
                "PPD: Oh man! \n" +
                "We’re game developers! \n" +
                "That’s so cool!!";
        }
        GUI.Label(new Rect(137, 365, 186, 90), "AUDIO", styleaudio);
        //GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);
		
        if (GUI.Button(new Rect(52, 718, 130, 80), varButtonBack, styleback))
        {
            efect.Play();			
            _globalvar = "option";
        }

        if (GUI.Button(new Rect(310, 718, 90, 80), "GO", styleback))
        {
            efect.Play();
            gm.IdiomaSeleccionado(idioma);
            print("Idioma " + idioma + " guardado correctamente");
            _globalvar = "option";
        }
    }

    public void BuildingStatusMenu()
    {
        GUI.Label(new Rect(180, 340, 130, 80), varStatus, styleoptiontitle);

        if (GUI.Button(new Rect(127, 410, 200, 76), varHelp, stylebtnstatus1))
        {
            efect.Play();
            _globalvar = "help";
        }
        if (GUI.Button(new Rect(118, 495, 230, 76), varRules, stylebtnstatus2))
        {
            efect.Play();
            _globalvar = "rules";
        }
        if (GUI.Button(new Rect(112, 579, 240, 86), varCredit, stylebtnstatus3))
        {
            efect.Play();
            _globalvar = "credit";
        }
        if (GUI.Button(new Rect(149, 664, 168, 70), varButtonBack, stylebtnstatus4))
        {
            efect.Play();
            _globalvar = "main";
        }
       
    }

    public void BuildingCredit()
    {
        GUI.Label(new Rect(180, 340, 130, 80), rolName, stylerolname);
        GUI.Label(new Rect(180, 340, 130, 80), rolDescrip, styleroldesc);
        if (GUI.Button(new Rect(175, 718, 130, 80), varButtonBack, styleback))
        {
            efect.Play();
            _globalvar = "status";
        }
    }

    public void BuildingStatitics()
    {   
        styleStatisticBack = guiSkin.FindStyle("statisticBack");
        styleSdvanceTitle = guiSkin.FindStyle("advanceTitle");
        GUI.Box(new Rect(0, 0, 480, 800), "", styleStatisticBack); 
        GUI.Label(new Rect(180, 200, 130, 80), varadvanced, styleSdvanceTitle);
        string x = gm.ObtenerMejorPuntuacionGneral().ToString();
        string y = gm.ObtenerPuntuacionGneral().ToString();
        GUI.Label(new Rect(278, 390, 200, 31), x, styleLabelContPuntos);
        GUI.Label(new Rect(278, 520, 200, 31), y, styleLabelContPuntos);
        if (GUI.Button(new Rect(175, 718, 130, 50), varButtonBack, styleback))
        {
            _globalvar = "option";
        }
    }

    public void BuildingHelp()
    {
        GUI.Label(new Rect(0, 0, 480, 800), "", styleLabelhelp);
        GUI.Label(new Rect(180, 30, 130, 80), varHelp, styleLabelhelptitle);
        if (GUI.Button(new Rect(175, 718, 130, 80), varButtonBack, styleback))
        {
            efect.Play();
            _globalvar = "status";
        }
    }

    public void BuildingRules()
    {
        GUI.Label(new Rect(0, 0, 480, 800), "", styleLabelrules);
        GUI.Label(new Rect(180, 56, 130, 80), varRules, styleLabelrulestitle);
        GUI.Label(new Rect(10, 180, 200, 31), varulesdesc, styleLabelrulesdesc);

        if (GUI.Button(new Rect(300, 700, 130, 80), varButtonBack, styleback))
        {
            efect.Play();
            _globalvar = "status";
        }
    }
}
