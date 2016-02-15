using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour {

     public Texture backgroundTexture;
     public float native_width  = 480;
     public float native_height = 800;
     public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()

    { 
		GUIStyle stylebtnplay= guiSkin.FindStyle("btnplaymenu");
		GUIStyle stylebtnstatus = guiSkin.FindStyle("btnstatusmenu");
		GUIStyle styleoption= guiSkin.FindStyle("btnoptionmenu");
		GUIStyle styleexit = guiSkin.FindStyle("btnexitmenu");

		GUIStyle stylefacebook= guiSkin.FindStyle("facebook");
		GUIStyle styleyoutube = guiSkin.FindStyle("youtube");

        GUI.skin = guiSkin;
        float rx = Screen.width / native_width;
        float ry = Screen.height / native_height;
        GUI.matrix = Matrix4x4.TRS (new Vector3(0, 0, 0), Quaternion.identity,new Vector3 (rx, ry, 1)); 
        GUI.BeginGroup(new Rect(0,0,480,800));
        GUI.DrawTexture(new Rect(0, 0, 480, 800), backgroundTexture, ScaleMode.StretchToFill, false);

		if(GUI.Button(new Rect(140,410,194,75),"PLAY",stylebtnplay))
        {
			Application.LoadLevel("SelectPersonScene");
        }
        
		if(GUI.Button(new Rect (112, 495, 250, 84),"STATUS",stylebtnstatus))
		{
			Application.LoadLevel("StatusScene"); 
		}

		if(GUI.Button (new Rect (117, 579, 240, 82), "OPTIONS",styleoption))
		{
			Application.LoadLevel("OptionScene"); 
		}

		if(GUI.Button(new Rect(140,664,194,75),"EXIT",styleexit))
        {
           Application.Quit();
        }
         
		GUI.Button (new Rect (190, 760, 34, 34), "",stylefacebook);
		GUI.Button (new Rect (240, 760, 34, 34), "",styleyoutube);

        GUI.EndGroup();
    }
}
