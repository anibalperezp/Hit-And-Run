#pragma strict
 var  native_width : float = 480;
 var native_height : float  = 800;
 var styleLogo: GUIStyle ;   
 var guiSkin : GUISkin;
  
function Start () {

}

function Update () {
   if(Time.time > 2)
   Application.LoadLevel("SelectPersonScene");
}
 
function OnGUI()
{

 var rx :  float = Screen.width / native_width;
 var ry :    float = Screen.height / native_height;
 GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1)); 
 
styleLogo= guiSkin.FindStyle("logo");
GUI.Box(new Rect(0,0,480,800),"",styleLogo);



}

