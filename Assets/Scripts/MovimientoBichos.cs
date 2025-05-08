using UnityEngine;
using UnityEngine.AI;
using System;

public class MovimientoBichos : MonoBehaviour
{
	public BoxCollider2D collider_player;
	public BoxCollider2D collider_lobo;
	public Rigidbody2D rbody2D;
	public NavMeshAgent agent;    
    
    void Start()
    {
	    Physics2D.IgnoreCollision(collider_player, collider_lobo);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

		//Random num = new Random();
		//rbody2D.linearVelocity = new Vector2(num.Next(0,2), num.Next(0, 2)) * 4;
	    
	    
    }

}
