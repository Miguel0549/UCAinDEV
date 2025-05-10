using UnityEngine;
using UnityEngine.AI;

public class MovimientoCabeza : MonoBehaviour
{
    public Camera camara;
    public NavMeshAgent agent;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        agent.enabled = true;
        if (collision.gameObject.tag == "Player")
        {
            agent.SetDestination(collision.gameObject.transform.position);
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
