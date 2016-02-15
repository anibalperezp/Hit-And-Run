using UnityEngine;
using System.Collections;

public class GUISelectPerson : MonoBehaviour {

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
		GUIStyle stylefacebook= guiSkin.FindStyle("up");

        GUI.skin = guiSkin;
        float rx = Screen.width / native_width;
        float ry = Screen.height / native_height;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
        GUI.BeginGroup(new Rect(0, 0, 480, 800));

		GUI.Label (new Rect (0, -20, 480, 800), "",stylefacebook);

		if(GUI.Button(new Rect(52,718,130,80),"BACK"))
		{
			Application.LoadLevel("MainMenu");
		}

		if(GUI.Button(new Rect(310,718,90,80),"GO"))
		{
			Application.LoadLevel("");
		}
		//GUI.Button (new Rect (240, 760, 34, 34), "",styleyoutube);

        GUI.EndGroup();
    }
}
