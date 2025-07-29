using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Linq;

public class AlertaBichos : MonoBehaviour
{

	void Start(){

		DatosGlobales.Lobos = FindObjectsOfType<NavMeshAgent>()
            .Where(agent => agent.gameObject.name.StartsWith("Lobo"))
            .ToList();

	}


    void OnTriggerStay2D(Collider2D collision)
    {
        
		if ( DatosGlobales.Lobos.Count != 0 ){

			if (collision.gameObject.tag == "Player"){
		
				foreach ( NavMeshAgent Lobo in DatosGlobales.Lobos )
				{

					Lobo.enabled = true;
					Lobo.SetDestination(collision.gameObject.transform.position);

				}


            }

		}
       
      
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {

		if ( DatosGlobales.Lobos.Count != 0 ){

			if (collision.gameObject.tag == "Player")
			{

				int x = 34, y = -11;
			
				foreach ( NavMeshAgent Lobo in DatosGlobales.Lobos )
				{

					Lobo.enabled = false;
					Lobo.Warp(new Vector2(x,y));
					x = x - 11;
					y = y + 10;
				}
	
            }

		}
       
        
    }
}
