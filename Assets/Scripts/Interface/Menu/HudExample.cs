using UnityEngine;
using System.Collections;

public class HudExample : MonoBehaviour {
    
    public int puntuacion;
    public GameObject objeto;

    void Start()
    {
        puntuacion = 0;
    }

void Update ()
 {
 	
	if (Input.GetMouseButtonDown(0))
					  {
						RaycastHit hit;            
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);                        
						if (Physics.Raycast(ray,out hit,Mathf.Infinity)) 
						{
                            if (hit.collider.name == "Controlador")                    
						    {
                                objeto.transform.Rotate(0, Time.deltaTime * 15, 0);
                                if (puntuacion < 3)
                                {
                                    puntuacion = puntuacion + 1;
                                    Debug.Log("puntuacion  ="+ puntuacion.ToString());
                                }
                                else
                                    if (puntuacion == 3)
                                    {
                                        Application.LoadLevel("Result");
                                    }
						    }
						}        
					 }					  			    
 }

}
