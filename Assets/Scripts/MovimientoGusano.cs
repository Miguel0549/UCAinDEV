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

    public Vector2 AgentVelocityToVector2DInput(UnityEngine.AI.NavMeshAgent agent)
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
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
		if ( agent_cabeza.enabled == true )
		{

			Vector2 movement = new Vector2( target.position.x - agentTransform.position.x, target.position.y - agentTransform.position.y );
        
        	if (movement != Vector2.zero)
        	{
          	  Quaternion to_rotation = Quaternion.LookRotation(Vector3.forward,movement);
           	 agentTransform.rotation = Quaternion.RotateTowards( agentTransform.rotation, to_rotation, rotationSpeed * Time.deltaTime );
        	}

		}

        if (this.tag != "Cabeza")
        {
            agent.enabled = agent_cabeza.enabled;
            agent.SetDestination(target.position);
        }
        
            
    }
    
    
}
