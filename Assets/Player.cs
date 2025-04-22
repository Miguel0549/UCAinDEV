using System;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed=8.0f;
    public float WalkSpeedMultiplier=0.5f;
    public Rigidbody2D rbody2d;
    private bool Dodging= false;
    public float DodgeCooldown = 1.5f;
    private float LastDodge = 0f;
    public float DodgeDuration = 0.3f;
    public float DodgeSpeed = 12.0f;
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
        if (!Dodging)
        { 
            rbody2d.linearVelocity = new Vector2(Speed * xMovement,Speed * yMovement);
        }
            if (Dodging&&Time.fixedTime-LastDodge>DodgeDuration)
            {
                Dodging = false;
                rbody2d.linearVelocity = Vector2.zero;
            }
            if (Input.GetKey(KeyCode.Space)&&Time.fixedTime-LastDodge>DodgeCooldown)
            {
                Dodging=true;
                LastDodge=Time.fixedTime;
                rbody2d.linearVelocity = new Vector2(DodgeSpeed * xMovement,DodgeSpeed * yMovement);

            }
        
    }
}
