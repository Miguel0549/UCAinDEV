using UnityEngine;
using UnityEngine.AI;
using System;

public class MovimientoLobo : MonoBehaviour
{
	public BoxCollider2D collider_player;
	public BoxCollider2D collider_lobo;
	public NavMeshAgent agent;    
    
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

		//Random num = new Random();
		//rbody2D.linearVelocity = new Vector2(num.Next(0,2), num.Next(0, 2)) * 4;
	    
	    
    }

}
