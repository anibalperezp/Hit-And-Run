using UnityEngine;
using System.Collections;

public class CamaraTerrenos : MonoBehaviour
{

    private string terreno = "";
    private GameObject objSprite11;
    private GameObject objSprite12;
    private GameObject objSprite13;
    private GameObject objSprite14;
    private GameObject objSprite15;
    private GameObject objSprite16;
    private GameObject objSprite17;
    private GameObject objSpriteT1;
    private GameObject objSpriteT2;
    private GameObject objSpriteT3;
    private GameObject objSpriteT4;
    private GameObject objSpriteT5;
    private GameObject objSpriteT6;
    private GameObject objSpriteT7;

    // Use this for initialization
    void Start()
    {
        objSprite11 = GameObject.Find("UISprite11");
        objSprite12 = GameObject.Find("UISprite12");
        objSprite13 = GameObject.Find("UISprite13");
        objSprite14 = GameObject.Find("UISprite14");
        objSprite15 = GameObject.Find("UISprite15");
        objSprite16 = GameObject.Find("UISprite16");
        objSprite17 = GameObject.Find("UISprite17");

        objSpriteT1 = GameObject.Find("UISlicedSprite11");
        objSpriteT4 = GameObject.Find("UISlicedSprite14");
        objSpriteT5 = GameObject.Find("UISlicedSprite15");
        objSpriteT6 = GameObject.Find("UISlicedSprite16");
        objSpriteT7 = GameObject.Find("UISlicedSprite17");

        objSprite11.renderer.active = false;
        objSprite12.renderer.active = false;
        objSprite13.renderer.active = false;
        objSprite14.renderer.active = false;
        objSprite15.renderer.active = false;
        objSprite16.renderer.active = false;
        objSprite17.renderer.active = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit1;
            foreach (var item in Camera.allCameras)
            {
                Ray ray1 = item.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray1, out hit1, Mathf.Infinity))
                {
                    if (hit1.collider.name == "Item11")
                    {
                        UISprite t1 = (UISprite)objSpriteT1.GetComponent("UISprite");
                        if (t1.spriteName != "habana")
                        {
                            terreno = "habana";
                            if (objSprite11.renderer.isVisible != true)
                            {
                                objSprite11.renderer.active = true;
                                objSprite12.renderer.active = false;
                                objSprite13.renderer.active = false;
                                objSprite14.renderer.active = false;
                                objSprite15.renderer.active = false;
                                objSprite16.renderer.active = false;
                                objSprite17.renderer.active = false;
                            } else
								if (objSprite11.renderer.isVisible == true)
                            {
                                objSprite11.renderer.active = false;
                            }
                        }
                    } else
						if (hit1.collider.name == "Item12")
                    {
                        terreno = "corner";
                        if (objSprite12.renderer.isVisible != true)
                        {
                            objSprite11.renderer.active = false;
                            objSprite12.renderer.active = true;
                            objSprite13.renderer.active = false;
                            objSprite14.renderer.active = false;
                            objSprite15.renderer.active = false;
                            objSprite16.renderer.active = false;
                            objSprite17.renderer.active = false;
                            Debug.Log(terreno + " visble");
                        } else
							if (objSprite12.renderer.isVisible == true)
                        {
                            objSprite12.renderer.active = false;
                            Debug.Log(terreno + " no visible");
                        }
                    } else
						if (hit1.collider.name == "Item13")
                    {
                        terreno = "estadio";
                        if (objSprite13.renderer.isVisible != true)
                        {
                            objSprite11.renderer.active = false;
                            objSprite12.renderer.active = false;
                            objSprite13.renderer.active = true;
                            objSprite14.renderer.active = false;
                            objSprite15.renderer.active = false;
                            objSprite16.renderer.active = false;
                            objSprite17.renderer.active = false;
                            Debug.Log(terreno + " visble");
                        } else
							if (objSprite13.renderer.isVisible == true)
                        {
                            objSprite13.renderer.active = false;
                            Debug.Log(terreno + " no visible");
                        }
                    } else
						if (hit1.collider.name == "Item14")
                    {
                        UISprite t4 = (UISprite)objSpriteT4.GetComponent("UISprite");
                        if (t4.spriteName != "callejon")
                        {
                            terreno = "callejon";
                            if (objSprite14.renderer.isVisible != true)
                            {
                                objSprite11.renderer.active = false;
                                objSprite12.renderer.active = false;
                                objSprite13.renderer.active = false;
                                objSprite14.renderer.active = true;
                                objSprite15.renderer.active = false;
                                objSprite16.renderer.active = false;
                                objSprite17.renderer.active = false;
                                Debug.Log(terreno + " visble");
                            } else
								if (objSprite14.renderer.isVisible == true)
                            {
                                objSprite14.renderer.active = false;
                                Debug.Log(terreno + " no visible");
                            }
                        }
                    } else
						if (hit1.collider.name == "Item15")
                    {
                        UISprite t5 = (UISprite)objSpriteT5.GetComponent("UISprite");
                        if (t5.spriteName != "jungla")
                        {
                            terreno = "jungla";
                            if (objSprite15.renderer.isVisible != true)
                            {
                                objSprite11.renderer.active = false;
                                objSprite12.renderer.active = false;
                                objSprite13.renderer.active = false;
                                objSprite14.renderer.active = false;
                                objSprite15.renderer.active = true;
                                objSprite16.renderer.active = false;
                                objSprite17.renderer.active = false;
                                Debug.Log(terreno + " visble");
                            } else
								if (objSprite15.renderer.isVisible == true)
                            {
                                objSprite15.renderer.active = false;
                                Debug.Log(terreno + " no visible");
                            }
                        }
                    } else
					if (hit1.collider.name == "Item16")
                    {
                        UISprite t6 = (UISprite)objSpriteT6.GetComponent("UISprite");
                        if (t6.spriteName != "taquillero")
                        {
                            terreno = "taquillero";
                            if (objSprite16.renderer.isVisible != true)
                            {
                                objSprite11.renderer.active = false;
                                objSprite12.renderer.active = false;
                                objSprite13.renderer.active = false;
                                objSprite14.renderer.active = false;
                                objSprite15.renderer.active = false;
                                objSprite16.renderer.active = true;
                                objSprite17.renderer.active = false;
                                Debug.Log(terreno + " visble");
                            } else
						if (objSprite16.renderer.isVisible == true)
                            {
                                objSprite16.renderer.active = false;
                                Debug.Log(terreno + " no visible");
                            }
                        }
                    } else
					if (hit1.collider.name == "Item17")
                    {
                        UISprite t6 = (UISprite)objSpriteT7.GetComponent("UISprite");
                        if (t6.spriteName != "volcan")
                        {
                            terreno = "volcan";
                            if (objSprite17.renderer.isVisible != true)
                            {
                                objSprite11.renderer.active = false;
                                objSprite12.renderer.active = false;
                                objSprite13.renderer.active = false;
                                objSprite14.renderer.active = false;
                                objSprite15.renderer.active = false;
                                objSprite16.renderer.active = false;
                                objSprite17.renderer.active = true;
                                Debug.Log(terreno + " visble");
                            } else
						         if (objSprite17.renderer.isVisible == true)
                            {
                                objSprite17.renderer.active = false;
                                Debug.Log(terreno + " no visible");
                            }
                        }
                    }
                }
            }
        }
    }

    public string ObtenerTerreno()
    {
        string x = terreno;
        return x;
    }
}
