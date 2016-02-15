

private var guizmo :BoxCollider;
var sceneViewDisplayColor : Color; 

function Start () {

}

function Update () {

}

function OnDrawGizmos()
{
guizmo = this.gameObject.GetComponent(BoxCollider); 

 
Gizmos.color = sceneViewDisplayColor;


var P_1 = Vector3(guizmo.bounds.min.x,guizmo.bounds.min.y,guizmo.bounds.min.z);
var P_2 = Vector3(guizmo.bounds.max.x,guizmo.bounds.min.y,guizmo.bounds.min.z);
var P_3 = Vector3(guizmo.bounds.max.x,guizmo.bounds.max.y,guizmo.bounds.min.z);
var P_4 = Vector3(guizmo.bounds.min.x,guizmo.bounds.max.y,guizmo.bounds.min.z);


var P_5 = Vector3(guizmo.bounds.min.x,guizmo.bounds.min.y,guizmo.bounds.max.z);
var P_6 = Vector3(guizmo.bounds.max.x,guizmo.bounds.min.y,guizmo.bounds.max.z);
var P_7 = Vector3(guizmo.bounds.max.x,guizmo.bounds.max.y,guizmo.bounds.max.z);
var P_8 = Vector3(guizmo.bounds.min.x,guizmo.bounds.max.y,guizmo.bounds.max.z);

Gizmos.DrawLine(P_1,P_2);
Gizmos.DrawLine(P_2,P_3);
Gizmos.DrawLine(P_3,P_4);
Gizmos.DrawLine(P_4,P_1);

Gizmos.DrawLine(P_1,P_5);
Gizmos.DrawLine(P_2,P_6);
Gizmos.DrawLine(P_3,P_7);
Gizmos.DrawLine(P_4,P_8);

Gizmos.DrawLine(P_5,P_6);
Gizmos.DrawLine(P_6,P_7);
Gizmos.DrawLine(P_7,P_8);
Gizmos.DrawLine(P_8,P_5);


}
