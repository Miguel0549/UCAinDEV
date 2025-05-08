using UnityEngine;
using UnityEngine.AI;

public class AlertaBichos : MonoBehaviour
{
    public Rigidbody2D rbody2D;
    public NavMeshAgent Lobo;
    
    
    void OnTriggerStay2D(Collider2D collision)
    {
        
        Lobo.enabled = true;
        if ( collision.gameObject.CompareTag("Player") ) Lobo.SetDestination(collision.gameObject.transform.position);
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        rbody2D.linearVelocity = new Vector2(0f, 0f);
        if ( collision.gameObject.CompareTag("Player") ) Lobo.enabled = false;
    }
}
