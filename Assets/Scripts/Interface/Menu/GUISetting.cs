using UnityEngine;
using System.Collections;

public class GUISetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float native_width = 480;
    public float native_height = 800;
    public GUISkin guiSkin;

    void OnGUI()
    {


		GUIStyle stylebtnplay= guiSkin.FindStyle("btnplaymenu");
		GUIStyle stylebtnstatus = guiSkin.FindStyle("btngalopt");
		GUIStyle styleoption= guiSkin.FindStyle("btnsettopt");
		GUIStyle styleoption2= guiSkin.FindStyle("btnsettopt2");
		GUIStyle styleexit = guiSkin.FindStyle("btnbackopt");
		
		GUIStyle stylefacebook= guiSkin.FindStyle("facebook");
		GUIStyle styleyoutube = guiSkin.FindStyle("youtube");

        GUI.skin = guiSkin;
        float rx = Screen.width / native_width;
        float ry = Screen.height / native_height;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
        GUI.BeginGroup(new Rect(0, 0, 480, 800));

		if(GUI.Button(new Rect(117,410,230,86),"SETTING",stylebtnstatus))
		{
			Application.LoadLevel("SettingScene");
		}
		
		if(GUI.Button(new Rect (118, 495, 230, 86),"GALLERY",styleoption))
		{
			Application.LoadLevel("GalleryScene"); 
		}
		
		if(GUI.Button (new Rect (112, 579, 240, 86), "ESTATICS",styleoption2))
		{
			Application.LoadLevel("EstaticsScene"); 
		}
		
		if(GUI.Button(new Rect(149,664,168,70),"BACK",styleexit))
		{
			Application.LoadLevel("MainMenu");
		}

		GUI.Button (new Rect (190, 760, 34, 34), "",stylefacebook);
		GUI.Button (new Rect (240, 760, 34, 34), "",styleyoutube);

        GUI.EndGroup();
    }
}
