using UnityEngine;
using UnityEngine.AI;

public class Lobo : MonoBehaviour
{

	public Transform player;
	public Transform lobo;
	public float Speed=8.0f;
    public SpriteRenderer sprite;
    public Animator Anim;
	public NavMeshAgent agent_lobo;

	private float xMovement;
	private float yMovement;

	enum direccion {
        Arriba,
        Abajo,
        Izquierda,
        Derecha,
        Izq_Arriba,
        Izq_Abajo,
        Dch_Arriba,
        Dch_Abajo,
    }

	private direccion lastDir;
   
    void FixedUpdate()
    {

	    if (agent_lobo.enabled == true)
	    {
		    xMovement = player.position.x - lobo.position.x;
		    yMovement = player.position.y - lobo.position.y;
	    }
	    else xMovement = yMovement = 0;
        
        if (xMovement < 0 && yMovement == 0) lastDir = direccion.Izquierda;
        if (xMovement < 0 && yMovement > 0) lastDir = direccion.Izq_Arriba;
        if (xMovement == 0 && yMovement > 0) lastDir = direccion.Arriba;
        if (xMovement > 0 && yMovement > 0) lastDir = direccion.Dch_Arriba;
        if (xMovement > 0 && yMovement == 0) lastDir = direccion.Derecha;
        if (xMovement > 0 && yMovement < 0) lastDir = direccion.Dch_Abajo;
        if (xMovement == 0 && yMovement < 0) lastDir = direccion.Abajo;
        if (xMovement < 0 && yMovement < 0) lastDir = direccion.Izq_Abajo;
            
        sprite.flipX = ( lastDir == direccion.Izquierda || lastDir == direccion.Izq_Abajo || lastDir == direccion.Izq_Arriba);
            
        Anim.SetBool("IdleHorizontal",xMovement == 0 && yMovement == 0 );
        Anim.SetBool("AndarHorizontal",xMovement != 0 && yMovement == 0);
        Anim.SetBool("AndarArriba",xMovement == 0 && yMovement > 0 );
        Anim.SetBool("AndarAbajo",xMovement == 0 && yMovement < 0 );
        Anim.SetBool("AndarDiagArriba",(xMovement < 0 && yMovement > 0) || ( xMovement > 0 && yMovement > 0 ) );
        Anim.SetBool("AndarDiagAbajo",(xMovement < 0 && yMovement < 0) || ( xMovement > 0 && yMovement < 0 ) );
        
        


		
    }
}
