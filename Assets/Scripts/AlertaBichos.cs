using UnityEngine;
using UnityEngine.AI;

public class AlertaBichos : MonoBehaviour
{
    public NavMeshAgent Lobo_1;
	public NavMeshAgent Lobo_2;
    
    
    void OnTriggerStay2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "Player")
        {
			Lobo_1.enabled = true;
			Lobo_2.enabled = true;
			Lobo_1.SetDestination(collision.gameObject.transform.position);
			Lobo_2.SetDestination(collision.gameObject.transform.position);

			/*
			foreach (NavMeshAgent child in Lobo.GetComponentsInChildren<NavMeshAgent>())
			{
				child.enabled = true;
            	child.SetDestination(collision.gameObject.transform.position);

			}
			*/

        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {

			Lobo_1.enabled = false;
			Lobo_2.enabled = false;
			Lobo_1.Warp(new Vector2(34,-11));
			Lobo_2.Warp(new Vector2(23,-1));

			/*
			foreach (NavMeshAgent child in Lobo.GetComponentsInChildren<NavMeshAgent>())
			{
				child.enabled = false;
				//child.Warp(new Vector3()):

			}
            */
        }
    }
}
