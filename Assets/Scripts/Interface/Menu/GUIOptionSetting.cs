using UnityEngine;
using System.Collections;

public class GUIOptionSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public float hSliderValue = 0.0f;
	public float native_width = 480;
	public float native_height = 800;
	public GUISkin guiSkin;
	
	void OnGUI()
	{
		GUIStyle stylelanguage= guiSkin.FindStyle("labellanguage");
		GUIStyle styleesp= guiSkin.FindStyle("butesp");
		GUIStyle styleeng= guiSkin.FindStyle("buteng");
		GUIStyle stylefra= guiSkin.FindStyle("butfra");
		GUIStyle stylepor= guiSkin.FindStyle("butpor");

		GUI.skin = guiSkin;
		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
		GUI.BeginGroup(new Rect(0, 0, 480, 800));

		GUI.Label (new Rect (180, 340, 130, 80), "LANGUAGE",stylelanguage);

		GUI.Button (new Rect (116, 209, 130, 80), "ESP",styleesp);
		GUI.Button (new Rect (6, 209, 130, 80), "ENG",styleeng);
		GUI.Button (new Rect (221, 209, 130, 80), "FRA",stylefra);
		GUI.Button (new Rect (328, 209, 130, 80), "POR",stylepor);

		//GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);

		if(GUI.Button(new Rect(52,718,130,80),"BACK"))
		{
			Application.LoadLevel("OptionScene");
		}
		
		GUI.Button (new Rect (310, 718, 90, 80), "GO");
		//{
		//	Application.LoadLevel("");
		//}
		//GUI.Button (new Rect (240, 760, 34, 34), "",styleyoutube);
		
		GUI.EndGroup();
	}
}
