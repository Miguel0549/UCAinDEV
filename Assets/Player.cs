using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed=8.0f;
    public float WalkSpeedMultiplier=0.5f;
    public Rigidbody2D rbody2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        rbody2d.linearVelocity = new Vector2(Speed * xMovement,Speed * yMovement);
    }
}
