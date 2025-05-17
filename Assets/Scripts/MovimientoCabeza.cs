using UnityEngine;
using UnityEngine.AI;

public class MovimientoCabeza : MonoBehaviour
{

    public Camera camara;
    public NavMeshAgent agent;
    public Collider2D pared_inv;

    void Start()
    {
        pared_inv.enabled = false;
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
