using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using _Logica;




public class controlCristiano : MonoBehaviour
{

    public AudioClip[] arrayClipAudio ;
    public GameObject planoValGolpe;
    private float timeDestrucPlano = 0 ;
    public int golpesRecividos = 0;
    private GUI_Play scriptGuiPlay;
    private int[] patronComboDado = new int[3]; 
    private int[] patronUltraDado = new  int[3];
    //	private int ultimaPosicionModifCombo = 2;
    private Combos combosScript;
    public GameObject particulasGolpestandart;
    public GameObject particulasCombo;
    public GameObject particulasUltra;
    private MovTransportador movtrans;
    private GameObject audioUltra;

    //texturas de ultra y combo
    private GameObject planeUltraCombo;
		
	
	
    //efecto rayo
    public GameObject relampago;
	
	
	
    //efecto congelacion
    public GameObject congelacion;


    //texturas de golpes de cristiano
    public Texture TextGolpeCritL1;
    public Texture TextGolpeCritL2;	
    public Texture TextGolpeCritL3;
    public Texture TextQuemaduraRayo;
    public Texture TextCongelacion;

    //Instantiate(part,hit.point,Quaternion.identity);
    public AudioClip[] arrayAudio;

    void Start()
    {       
        scriptGuiPlay = Camera.main.GetComponent<GUI_Play>();
        movtrans = GameObject.Find("transportadorMax").GetComponent<MovTransportador>();
        combosScript = GameObject.Find("Contenedor").GetComponent<Combos>();	
        audioUltra = GameObject.Find("audioUltraPrefab");
        planeUltraCombo = GameObject.Find("planoUltraCombo");
    }

    void Update()
    {

        recibirGolpe();
        scriptGuiPlay .puntosAplicados = golpesRecividos;
				
    }

    public void recibirGolpe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //	if (Input.touchCount > 0 && 
            //	Input.GetTouch (0).phase == TouchPhase.Began)   
			
            RaycastHit hit; 

            //Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position); 
						 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

            if (Physics.Raycast(ray, out hit))
            {         
								
                string colliderName = hit.collider.name;
				               
                switch (colliderName)
                {
								
                    case "c_centro_cabeza":
                        this.animation.CrossFadeQueued("cr7_golpeCara", 0.07F, QueueMode.PlayNow);
                        audio.clip = arrayClipAudio [0];
                        audio.Play();
				
                        Idle();
                        instanciarPlanValNumGolp(hit.point, 5);
										
                        break;
                    case "c_tronco":
                        this.animation.CrossFadeQueued("cr7_golpeEstomago", 0.07F, QueueMode.PlayNow);
                        audio.clip = arrayClipAudio [1];
                        audio.Play();
                        Idle();
                        instanciarPlanValNumGolp(hit.point, 3);
															
                        break;
                    case "c_piernas":
                        this.animation.CrossFadeQueued("cr7_golpePiernas", 0.07F, QueueMode.PlayNow);
                        audio.clip = arrayClipAudio [2];
                        audio.Play();
                        Idle();
                        instanciarPlanValNumGolp(hit.point, 1);
										
                        break;
                    case "c_cachete_izq":
                        this.animation.CrossFadeQueued("cr7_golpeCaraIzq", 0.07F, QueueMode.PlayNow);
                        audio.clip = arrayClipAudio [2];
                        audio.Play();
                        Idle();
                        instanciarPlanValNumGolp(hit.point, 3);
										
                        break;

                    case "c_cachete_der":
                        this.animation.CrossFadeQueued("cr7_golpeCaraDer", 0.07F, QueueMode.PlayNow);
                        audio.clip = arrayClipAudio [2];
                        audio.Play();
                        Idle();
                        instanciarPlanValNumGolp(hit.point, 3);
					
                        break;
                    case "c_genitales":
                        this.animation.CrossFadeQueued("cr7_golpeGenitales", 0.07F, QueueMode.PlayNow);
                        audio.clip = arrayClipAudio [1];
                        audio.Play();
                        Idle();
                        instanciarPlanValNumGolp(hit.point, 5);
					
                        break;
					

                }
				

					
            }
			
        }


    }



	
    public void instanciarPlanValNumGolp(Vector3 point, int valGolpe)
    {

			
        addValAlPatronCombo(valGolpe);

        ArrayList result = combosScript.hayCombo(patronComboDado);

        if ((int)result [0] == 1)
        {

            planeUltraCombo.renderer.enabled = true;
            planeUltraCombo.SendMessage("setMomentoAparicion", Time.time);
            planeUltraCombo.renderer.material.mainTextureOffset = new Vector2(0, 0);


            audio.clip = arrayClipAudio [3];
            audio.Play();

            valGolpe = (int)result [1];

            Instantiate(particulasCombo, point, Quaternion.identity);

            addValAlPatronUltra(valGolpe);

            ArrayList resultUltra = combosScript.hayUltra(patronUltraDado);

            if ((int)resultUltra [0] == 1)
            {

                efectoUltra(point);							

                valGolpe = (int)resultUltra [1];

                planeUltraCombo.renderer.enabled = true;	

                planeUltraCombo.SendMessage("setMomentoAparicion", Time.time);

                planeUltraCombo.renderer.material.mainTextureOffset = new Vector2(0.5f, 0f);
								
                Camera.main.GetComponent<GUI_Play>().tiempoFinal += 2;
            }
            
        }

        List<ArmaSelected> listTempArmSelect = Camera.main.GetComponent<GUI_Play>().listArmaSelec;
		
        if (listTempArmSelect.Count != 0)
        {
			
            bool efectoEjecutado = false;
			
            int i = 0;
			
            while (!efectoEjecutado &&  i <=  listTempArmSelect.Count-1)
            {
				
                //aplica golpe y efecto si es el martillo
                if (listTempArmSelect [i].nombreArma == "martillo" && listTempArmSelect [i].seleccionada == true)
                {
                    efectoUltra(point);
                    valGolpe = 150;
                    Camera.main.GetComponent<GUI_Play>().listArmaSelec [i].seleccionada = false;
                    efectoEjecutado = true;
                }
				
                //aplica golpe y efecto si es el palogolf
                if (listTempArmSelect [i].nombreArma == "palogolf" && listTempArmSelect [i].seleccionada == true)
                {
                    efectoUltra(point);
                    valGolpe = 120;
                    Camera.main.GetComponent<GUI_Play>().listArmaSelec [i].seleccionada = false;
                    efectoEjecutado = true;
                }
				
                //aplicar rayo
                if (listTempArmSelect [i].nombreArma == "rayo" && listTempArmSelect [i].seleccionada == true)
                {
                    efectoRayo(point);
                    valGolpe = 150;
                    Camera.main.GetComponent<GUI_Play>().listArmaSelec [i].seleccionada = false;
                    efectoEjecutado = true;
                    audio.clip = arrayClipAudio [5];
                    audio.Play();
                }
				
                //aplicar congelacion
                if (listTempArmSelect [i].nombreArma == "hielo" && listTempArmSelect [i].seleccionada == true)
                {
                    efectoCongelacion(point);
                    valGolpe = 150;
                    Camera.main.GetComponent<GUI_Play>().listArmaSelec [i].seleccionada = false;
                    efectoEjecutado = true;
					
                }
                i++;
            }
        }

        point.z -= 0.4f;
        Instantiate(particulasGolpestandart, point, Quaternion.identity);
        GameObject planoVal = (GameObject)Instantiate(planoValGolpe, point, Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));				
	     
        planoVal.transform.renderer.material.mainTextureOffset = aplicarGolpeSegunVal(valGolpe);

        timeDestrucPlano = Time.time + 1;
    }

    public void efectoUltra(Vector3 point)
    {
        audioUltra.GetComponent<AudioUltra>().playAudioUltra();
		
        Instantiate(particulasUltra, point, Quaternion.identity);
        caidaAtras();
        Idle();
    }

    public void efectoRayo(Vector3 point)
    {
        Instantiate(relampago, point, Quaternion.identity);		        
        GameObject.Find("/raizTransp/transportadorMax").GetComponent<MovTransportador>().textQuemaduraAplicada = true;
        GameObject.Find("/raizTransp/transportadorMax").GetComponent<MovTransportador>().momentoAparicionTex = Time.time;
        this.animation.CrossFadeQueued("cr7_electrocutado", 0.07F, QueueMode.PlayNow);
        Idle();
    }
	
    public void efectoCongelacion(Vector3 point)
    {
        Instantiate(congelacion, point, Quaternion.identity);
        GameObject.Find("/raizTransp/transportadorMax").GetComponent<MovTransportador>().textCongelacionAplicada = true;
        GameObject.Find("/raizTransp/transportadorMax").GetComponent<MovTransportador>().momentoAparicionTex = Time.time;
    }

		        
		
		

    public Vector2 aplicarGolpeSegunVal(int valGolp)
    {
        float Xoffse = 0;
        float Yoffse = 0;
        //int num = UnityEngine.Random.Range (0, 3);
        switch (valGolp)
        {
        //+5		
            case 5:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.215f;
                    break;
                }
        //+1
            case 1:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.43f;
                    break;
                }
        //+3		
            case 3:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.32f;
                    break;
                }
            case 20:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.11f;
                    break;

                }
            case 30:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.001f;
                    break;
			
                }
            case 50:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = -0.102f;
                    break;
			
                }

            case 100:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.56f;
                    break;
			
                }
            case 120:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.67f;
                    break;
			
                }
            case 150:
                {
                    golpesRecividos += valGolp;
                    Xoffse = 0;
                    Yoffse = 0.56f;
                    break;
			
                }
        }
        return new Vector2(Xoffse, Yoffse);
    }




    public void addValAlPatronCombo(int val)
    {
        patronComboDado [0] = patronComboDado [1];
        patronComboDado [1] = patronComboDado [2];
        patronComboDado [2] = val;			
    }
    public void addValAlPatronUltra(int val)
    {
        patronUltraDado [0] = patronUltraDado [1];
        patronUltraDado [1] = patronUltraDado [2];
        patronUltraDado [2] = val;
    }



    public void SaltoEntradaPorIzquierda()
    {

        this.animation.Play("cr7_entradaPorIzq");

    }
    public void SaltoEntradaPorDerecha()
    {
	
        this.animation.Play("cr7_entradaPorDer");
				
    }
    public void Idle()
    {
        this.animation.CrossFadeQueued("cr7_patadaBalon", 0.07f, QueueMode.CompleteOthers);		 
        this.animation.CrossFadeQueued("cr7_Idle", 0.07f, QueueMode.CompleteOthers);

    }
    public void caidaAtras()
    {
		
        //this.animation.CrossFadeQueued ("cr7_caidaAtras", 0.02f, QueueMode.CompleteOthers);
        this.animation.Play("cr7_caidaAtras");
	
    }


    public void cambioTextGolpes(int nivel)
    {

        switch (nivel)
        {
            case 1:
                this.transform.Find("cristiano_con morfer").renderer.material.mainTexture = TextGolpeCritL1;

                break;
            case 2:
                this.transform.Find("cristiano_con morfer").renderer.material.mainTexture = TextGolpeCritL2;
                break;

            case 3:
                this.transform.Find("cristiano_con morfer").renderer.material.mainTexture = TextGolpeCritL3;
                break;
            case 4:
                this.transform.Find("cristiano_con morfer").renderer.material.mainTexture = TextQuemaduraRayo;
                break;
            case 5:
                this.transform.Find("cristiano_con morfer").renderer.material.mainTexture = TextCongelacion;
                break;

        }


    }






	
}
