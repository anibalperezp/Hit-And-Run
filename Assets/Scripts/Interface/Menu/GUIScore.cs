using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {

    public Texture backgroundTexture;
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
        GUIStyle styleplay = guiSkin.FindStyle("play");
        GUIStyle stylebacplay = guiSkin.FindStyle("backplay");
        GUIStyle stylemenu = guiSkin.FindStyle("menu");

        GUI.skin = guiSkin;
        float rx = Screen.width / native_width;
        float ry = Screen.height / native_height;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
        GUI.BeginGroup(new Rect(0, 0, 480, 800));
        GUI.DrawTexture(new Rect(0, 0, 480, 800), backgroundTexture, ScaleMode.StretchToFill, false);
       
        if (GUI.Button(new Rect(89, 635, 115, 200), "", styleplay))
        {
            Application.LoadLevel("PlayingTheGame");

        }
        if (GUI.Button(new Rect(189, 635, 115, 200), "", stylebacplay))
        {
            Application.LoadLevel("PlayScene");
        }

        if (GUI.Button(new Rect(289, 635, 115, 200), "", stylemenu))
        {
            Application.LoadLevel("MenuPrincipal");
        }

        GUI.EndGroup();
    }
}
