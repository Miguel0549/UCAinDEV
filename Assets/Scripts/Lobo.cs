using UnityEngine;
using UnityEngine.AI;

public class Lobo : MonoBehaviour
{
    

	public float Speed=8.0f;
    public Rigidbody2D rbody2d;
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

	public Vector2 AgentVelocityToVector2DInput(NavMeshAgent agent)
	{
        float xValue;
        float yValue;
        // Get the NavMeshAgent's desired velocity direction relative from it's actual position
        Vector3 desiredVelocityRelativeToAgent = agent.transform.InverseTransformDirection(agent.desiredVelocity);
        // Normalize the vector so it doesn't have a magnitude beyond 1.0f
        desiredVelocityRelativeToAgent.Normalize();
        // X value will be the X value of the vector
        xValue = desiredVelocityRelativeToAgent.x;
        // Y value will be the Z value of the vector
        yValue = desiredVelocityRelativeToAgent.z;
        // It's worth noting that you should scale this 2D vector by a desired speed on a scale of 0 - 1
        return new Vector2(xValue, yValue);
	}
   
    void FixedUpdate()
    {
		
		Vector2 vec = AgentVelocityToVector2DInput(agent_lobo);

		xMovement = vec.x;
		yMovement = -vec.y;
		
		Debug.Log("X:");
		Debug.Log(xMovement);
		Debug.Log("Y:");
		Debug.Log(yMovement);


        
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
