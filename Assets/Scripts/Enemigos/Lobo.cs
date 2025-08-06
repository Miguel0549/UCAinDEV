using UnityEngine;
using UnityEngine.AI;
using System;

public class Lobo : MonoBehaviour
{

	public Transform player;
	public Transform lobo;
	public float Speed=8.0f;
    public SpriteRenderer sprite;
    public Animator Anim;
	public NavMeshAgent agent_lobo;
	public float angulo;

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

		Vector2 movement = new Vector2( player.position.x - lobo.position.x, player.position.y - lobo.position.y);
		Vector2 eje_x = new Vector2(1,0);
		Vector2 neg_eje_x = new Vector2(-1,0);
		Vector2 eje_y = new Vector2(0,1);
		Vector2 neg_eje_y = new Vector2(0,-1);
		movement.Normalize();

	    if (agent_lobo.enabled == true)
	    {
		
		    xMovement = movement.x;
		    yMovement = movement.y;
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
        Anim.SetBool("AndarHorizontal",( xMovement != 0 ) && ( Vector2.Angle(movement,eje_x) >= 0 && Vector2.Angle(movement,eje_x) < angulo ) || ( Vector2.Angle(movement,neg_eje_x) >= 0 && Vector2.Angle(movement,neg_eje_x) < angulo ) );
        Anim.SetBool("AndarArriba",( yMovement != 0 ) && (Vector2.Angle(movement,eje_y) >= 0 && Vector2.Angle(movement,eje_y) < angulo ) );
        Anim.SetBool("AndarAbajo",( yMovement != 0 ) && (Vector2.Angle(movement,neg_eje_y) >= 0 && Vector2.Angle(movement,neg_eje_y) < angulo ));
        Anim.SetBool("AndarDiagArriba", ( (xMovement < 0 && yMovement > 0) || ( xMovement > 0 && yMovement > 0 ) ) && (( Vector2.Angle(movement,eje_x) >= angulo && Vector2.Angle(movement,eje_x) < 90 - angulo ) || ( Vector2.Angle(movement,neg_eje_x) >= angulo && Vector2.Angle(movement,neg_eje_x) < 90 - angulo )) );
        Anim.SetBool("AndarDiagAbajo",( (xMovement < 0 && yMovement < 0) || ( xMovement > 0 && yMovement < 0 ) ) && (( Vector2.Angle(movement,eje_x) >= angulo && Vector2.Angle(movement,eje_x) < 90 - angulo ) || ( Vector2.Angle(movement,neg_eje_x) >= angulo && Vector2.Angle(movement,neg_eje_x) < 90 - angulo )) );
        
        


		
    }
}
