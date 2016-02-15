#pragma strict
 
 var timeEliminacion:float = 0.02f;
 var momentoEliminacion:float = 0;
 
function Start () {
momentoEliminacion = timeEliminacion +Time.time;
}

function Update () {

if(momentoEliminacion < Time.time)
{
  Destroy(this.gameObject);

} 


}