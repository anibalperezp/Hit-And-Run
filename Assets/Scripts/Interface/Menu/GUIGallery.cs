using UnityEngine;
using System.Collections;

public class GUIGallery : MonoBehaviour {

	public float native_width = 480;
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
		GUIStyle stylelabelgallery= guiSkin.FindStyle("labelgallery");
		GUIStyle stylelabelb1= guiSkin.FindStyle("btnleft");
		GUIStyle stylelabelb2= guiSkin.FindStyle("btnright");
		
		GUI.skin = guiSkin;
		float rx = Screen.width / native_width;
		float ry = Screen.height / native_height;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
		GUI.BeginGroup(new Rect(0, 0, 480, 800));
		
		GUI.Label (new Rect (0, 0, 480, 800), "",stylelabelgallery);
		GUI.Button(new Rect(-20,375,130,80),"",stylelabelb1);
		GUI.Button(new Rect(380,375,130,80),"",stylelabelb2);

		if(GUI.Button(new Rect(175,718,130,80),"BACK"))
		{
			Application.LoadLevel("OptionScene");
		}
		//GUI.Button (new Rect (240, 760, 34, 34), "",styleyoutube);
		
		GUI.EndGroup();
	}
}
