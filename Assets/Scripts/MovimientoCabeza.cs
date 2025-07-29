using UnityEngine;
using UnityEngine.AI;

public class MovimientoCabeza : MonoBehaviour
{

    public Camera camara;
    public NavMeshAgent agent;
    public Collider2D pared_inv;
    
    public Transform agentTransform;
    
    private float rotationSpeed = 720;

    void Start()
    {
        pared_inv.enabled = false;
        agent.enabled = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        if (agent.enabled == true)
        {
            agent.SetDestination(DatosGlobales.actual.position);
            
            Vector2 movement = new Vector2( DatosGlobales.actual.position.x - agentTransform.position.x, DatosGlobales.actual.position.y - agentTransform.position.y );
        
            if (movement != Vector2.zero)
            {
                Quaternion to_rotation = Quaternion.LookRotation(Vector3.forward,movement);
                agentTransform.rotation = Quaternion.RotateTowards( agentTransform.rotation, to_rotation, rotationSpeed * Time.deltaTime );
            }
        }

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        pared_inv.enabled = true;
        camara.farClipPlane = 2000;
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            agent.enabled = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            agent.enabled = false;
            agent.Warp(new Vector3(40, 28, 0));
        }
    }
}
