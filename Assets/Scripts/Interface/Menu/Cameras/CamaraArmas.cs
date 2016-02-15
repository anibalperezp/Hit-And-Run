using UnityEngine;
using System.Collections;

public class CamaraArmas : MonoBehaviour
{
    private string arma1 = "";
    private string arma2 = "";
    private string error = "";
    private GameObject objSprite01;
    private GameObject objSprite01img;
    private GameObject objSprite02;
    private GameObject objSprite03;
    private GameObject objSprite04;
    private GameObject objSprite04img;
    private int cont = 0;
    // Use this for initialization
    void Start()
    {
        objSprite01 = GameObject.Find("UISprite01");
        objSprite01img = GameObject.Find("UISlicedSprite01");
        objSprite02 = GameObject.Find("UISprite02");
        objSprite03 = GameObject.Find("UISprite03");
        objSprite04 = GameObject.Find("UISprite04");
        objSprite04img = GameObject.Find("UISlicedSprite04");
        objSprite01.renderer.active = false;
        objSprite02.renderer.active = false;
        objSprite03.renderer.active = false;
        objSprite04.renderer.active = false;
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
                    if (hit1.collider.name == "Item01")
                    {
                        UISprite martillo = (UISprite)objSprite01img.GetComponent("UISprite");
                        if (martillo.spriteName != "martilloGris")
                        {
                            if (cont < 2)
                            {
                                if (objSprite01.renderer.isVisible == false)
                                {
                                    if (arma1 == "" && arma2 == "")
                                    {
                                        objSprite01.renderer.active = true;
                                        arma1 = "martillo";
                                        Debug.Log(arma1 + " visble");
                                        cont += 1;
                                        Debug.Log(cont.ToString());
                                    } else
										if (arma1 != "" && arma2 == "")
                                    {
                                        if (arma1 != "martillo")
                                        {
                                            objSprite01.renderer.active = true;
                                            arma2 = "martillo";
                                            Debug.Log(arma1 + " visble");
                                            Debug.Log(arma2 + " visble");
                                            cont += 1;
                                            Debug.Log(cont.ToString());
                                        }
                                    } else
									if (arma1 == "" && arma2 != "")
                                    {
                                        if (arma2 != "martillo")
                                        {
                                            objSprite01.renderer.active = true;
                                            arma1 = "martillo";
                                            cont += 1;
                                        }
                                    } else
										if (arma1 != "" && arma2 != "")
                                    {
                                        error = "No puede seleccionar mas armas";
                                        print(error);
                                    }
                                }
                            }
													
                            if (objSprite01.renderer.isVisible == true)
                            {
                                if (arma1 != "" && arma2 != "")
                                {
                                    objSprite01.renderer.active = false;
                                    cont = cont - 1;
                                    if (arma2.Equals("martillo"))
                                    {
                                        arma2 = "";
                                        Debug.Log("cont " + cont.ToString());
                                    } else
										if (arma1.Equals("martillo"))
                                    {
                                        arma1 = "";
                                    }
                                } else
									if (arma1 != "" && arma2 == "")
                                {
                                    objSprite01.renderer.active = false;
                                    cont = cont - 1;
                                    if (arma2.Equals("martillo"))
                                    {
                                        arma2 = "";
                                        Debug.Log("cont " + cont.ToString());
                                    } else
									if (arma1.Equals("martillo"))
                                    {
                                        arma1 = "";
                                    }
                                    Debug.Log("cont " + cont.ToString());
                                    Debug.Log("Ambas armas ya borrdas: " + arma1 + arma2);
                                } else
								if (arma1 == "" && arma2 != "")
                                {
                                    objSprite01.renderer.active = false;
                                    cont = cont - 1;
                                    if (arma2.Equals("martillo"))
                                    {
                                        arma2 = "";
                                        Debug.Log("cont " + cont.ToString());
                                    } else
									if (arma1.Equals("martillo"))
                                    {
                                        arma1 = "";
                                    }
                                }
                            }
                        } else
							if (martillo.spriteName == "martilloGris")
                        {
                            objSprite01.renderer.active = false;
                        }



                    } else
						if (hit1.collider.name == "Item02")
                    {
                        if (cont < 2)
                        {
                            if (objSprite02.renderer.isVisible == false)
                            {
                                if (arma1 == "" && arma2 == "")
                                {
                                    objSprite02.renderer.active = true;
                                    arma1 = "hielo";
                                    cont += 1;
                                    Debug.Log(arma1 + " visble");
                                    Debug.Log(cont.ToString());
                                } else
									if (arma1 != "" && arma2 == "")
                                {
                                    objSprite02.renderer.active = true;
                                    arma2 = "hielo";
                                    Debug.Log(arma1 + " visble");
                                    Debug.Log(arma2 + " visble");
                                    cont += 1;
                                    Debug.Log(cont.ToString());
                                } else
								if (arma1 == "" && arma2 != "")
                                {
                                    objSprite02.renderer.active = true;
                                    arma1 = "hielo";
                                    Debug.Log(arma1 + " visble");
                                    Debug.Log(arma2 + " visble");
                                    cont += 1;
                                    Debug.Log(cont.ToString());
                                } else
									if (arma1 != "" && arma2 != "")
                                {
                                    error = "No puede seleccionar mas armas";
                                    print(error);
                                }
                            }
                        }
                        if (objSprite02.renderer.isVisible == true)
                        {
                            if (arma1 != "" && arma2 != "")
                            {
                                objSprite02.renderer.active = false;
                                cont = cont - 1;
                                if (arma2.Equals("hielo"))
                                {
                                    arma2 = "";
                                    Debug.Log("cont " + cont.ToString());
                                } else
								if (arma1.Equals("hielo"))
                                {
                                    arma1 = "";
                                }
                            } else
							    if (arma1 != "" && arma2 == "")
                            {
                                objSprite02.renderer.active = false;
                                cont = cont - 1;
                                if (arma2.Equals("hielo"))
                                {
                                    arma2 = "";
                                    Debug.Log("cont " + cont.ToString());
                                } else
								if (arma1.Equals("hielo"))
                                {
                                    arma1 = "";
                                }
                            } else
							if (arma1 == "" && arma2 != "")
                            {
                                objSprite02.renderer.active = false;
                                cont = cont - 1;
                                if (arma2.Equals("hielo"))
                                {
                                    arma2 = "";
                                    Debug.Log("cont " + cont.ToString());
                                } else
								if (arma1.Equals("hielo"))
                                {
                                    arma1 = "";
                                }
                            }
                        }
                    } else
						if (hit1.collider.name == "Item03")
                    {
                        if (cont < 2)
                        {
                            if (objSprite03.renderer.isVisible == false)
                            {
                                if (arma1 == "" && arma2 == "")
                                {
                                    objSprite03.renderer.active = true;
                                    arma1 = "palogolf";
                                    cont += 1;
                                } else
									if (arma1 != "" && arma2 == "")
                                {
                                    objSprite03.renderer.active = true;
                                    arma2 = "palogolf";
                                    cont += 1;
                                } else
								if (arma1 == "" && arma2 != "")
                                {
                                    objSprite03.renderer.active = true;
                                    arma1 = "palogolf";
                                    cont += 1;
                                } else
																	                                        if (arma1 != "" && arma2 != "")
                                {
                                    error = "No puede seleccionar mas armas";
                                    print(error);
                                }
                            }
                        }
                        if (objSprite03.renderer.isVisible == true)
                        {
                            if (arma1 != "" && arma2 != "")
                            {
                                objSprite03.renderer.active = false;
                                cont = cont - 1;
                                if (arma2.Equals("palogolf"))
                                {
                                    arma2 = "";
                                    Debug.Log("cont " + cont.ToString());
                                } else
								if (arma1.Equals("palogolf"))
                                {
                                    arma1 = "";
                                }
                            } else
								if (arma1 != "" && arma2 == "")
                            {
                                objSprite03.renderer.active = false;
                                cont = cont - 1;
                                if (arma2.Equals("palogolf"))
                                {
                                    arma2 = "";
                                    Debug.Log("cont " + cont.ToString());
                                } else
								if (arma1.Equals("palogolf"))
                                {
                                    arma1 = "";
                                }
                            } else
							if (arma1 != "" && arma2 == "")
                            {
                                objSprite03.renderer.active = false;
                                cont = cont - 1;
                                if (arma2.Equals("palogolf"))
                                {
                                    arma2 = "";
                                    Debug.Log("cont " + cont.ToString());
                                } else
								if (arma1.Equals("palogolf"))
                                {
                                    arma1 = "";
                                }
                            }
                        }
                    } else
						if (hit1.collider.name == "Item04")
                    {
                        UISprite rayo = (UISprite)objSprite04img.GetComponent("UISprite");
                        if (rayo.spriteName != "rayoGris")
                        {
                            if (cont < 2)
                            {
                                if (objSprite04.renderer.isVisible == false)
                                {
                                    if (arma1 == "" && arma2 == "")
                                    {
                                        objSprite04.renderer.active = true;
                                        cont += 1;
                                        arma1 = "rayo";
                                        Debug.Log(arma1 + " visble");
                                        Debug.Log(cont.ToString());
                                    } else
										if (arma1 != "" && arma2 == "")
                                    {
                                        objSprite04.renderer.active = true;
                                        arma2 = "rayo";
                                        Debug.Log(arma1 + " visble");
                                        Debug.Log(arma2 + " visble");
                                        cont += 1;
                                        Debug.Log(cont.ToString());
                                    } else
									if (arma1 == "" && arma2 != "")
                                    {
                                        objSprite04.renderer.active = true;
                                        arma1 = "rayo";
                                        Debug.Log(arma1 + " visble");
                                        Debug.Log(arma2 + " visble");
                                        cont += 1;
                                        Debug.Log(cont.ToString());
                                    } else
								        if (arma1 != "" && arma2 != "")
                                    {
                                        error = "No puede seleccionar mas armas";
                                        print(error);
                                    }
                                }
                            }
                            if (objSprite04.renderer.isVisible == true)
                            {
                                if (arma1 != "" && arma2 != "")
                                {
                                    objSprite04.renderer.active = false;
                                    cont = cont - 1;
                                    if (arma2.Equals("rayo"))
                                    {
                                        arma2 = "";
                                        Debug.Log("cont " + cont.ToString());
                                    } else
									if (arma1.Equals("rayo"))
                                    {
                                        arma1 = "";
                                    }
									
                                } else
									if (arma1 != "" && arma2 == "")
                                {
                                    objSprite04.renderer.active = false;
                                    cont = cont - 1;
                                    if (arma2.Equals("rayo"))
                                    {
                                        arma2 = "";
                                        Debug.Log("cont " + cont.ToString());
                                    } else
									if (arma1.Equals("rayo"))
                                    {
                                        arma1 = "";
                                    }
                                } else
								if (arma1 == "" && arma2 != "")
                                {
                                    objSprite04.renderer.active = false;
                                    cont = cont - 1;
                                    if (arma2.Equals("rayo"))
                                    {
                                        arma2 = "";
                                        Debug.Log("cont " + cont.ToString());
                                    } else
									if (arma1.Equals("rayo"))
                                    {
                                        arma1 = "";
                                    }
                                }
                            }
                        } else
							if (rayo.spriteName == "rayoGris")
                        {
                            objSprite04.renderer.active = false;
                        }
														
                    }
                }
            }
        }
    }

    public string ObtenerArma1()
    {
        string x = arma1;
        return x;
    }
    public string ObtenerArma2()
    {
        string x = arma2;
        return x;
    }
		
}
