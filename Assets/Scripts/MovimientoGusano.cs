using UnityEngine;
using UnityEngine.AI;

public class MovimientoGusano : MonoBehaviour
{

    public NavMeshAgent agent_cabeza;
    public NavMeshAgent agent;
    public Transform agentTransform;
    public Transform target;
    private float rotationSpeed = 720;
    
    
    void Start()
    {
        agent.enabled = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

	    agent.enabled = agent_cabeza.enabled;
        
		if ( agent_cabeza.enabled == true )
		{

			Vector2 movement = new Vector2( target.position.x - agentTransform.position.x, target.position.y - agentTransform.position.y );
        
        	if (movement != Vector2.zero)
        	{
          	  Quaternion to_rotation = Quaternion.LookRotation(Vector3.forward,movement);
           	  agentTransform.rotation = Quaternion.RotateTowards( agentTransform.rotation, to_rotation, rotationSpeed * Time.deltaTime );
        	}

		}

		agent.SetDestination(target.position);

    }
    
    
}
