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
    public SpriteRenderer sprite;

    public Animator Anim;
    
    enum direccion {
        Arriba,
        Abajo,
        Izquierda,
        Derecha,
        Izq_Arriba,
        Izq_Abajo,
        Dch_Arriba,
        Dch_Abajo,
    }

    private direccion lastDir;
    
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

            if (xMovement < 0 && yMovement == 0) lastDir = direccion.Izquierda;
            if (xMovement < 0 && yMovement > 0) lastDir = direccion.Izq_Arriba;
            if (xMovement == 0 && yMovement > 0) lastDir = direccion.Arriba;
            if (xMovement > 0 && yMovement > 0) lastDir = direccion.Dch_Arriba;
            if (xMovement > 0 && yMovement == 0) lastDir = direccion.Derecha;
            if (xMovement > 0 && yMovement < 0) lastDir = direccion.Dch_Abajo;
            if (xMovement == 0 && yMovement < 0) lastDir = direccion.Abajo;
            if (xMovement < 0 && yMovement < 0) lastDir = direccion.Izq_Abajo;
            
            sprite.flipX = ( lastDir == direccion.Derecha || lastDir == direccion.Dch_Abajo || lastDir == direccion.Dch_Arriba);
            
            Anim.SetBool("Idle",xMovement == 0 && yMovement == 0 && lastDir == direccion.Abajo);
            Anim.SetBool("IdleArriba",xMovement == 0 && yMovement == 0 && lastDir == direccion.Arriba);
            Anim.SetBool("IdleHorizontal",xMovement == 0 && yMovement == 0 && ( lastDir == direccion.Izquierda || lastDir == direccion.Derecha) );
            Anim.SetBool("IdleDiagArriba",xMovement == 0 && yMovement == 0 && ( lastDir == direccion.Izq_Arriba || lastDir == direccion.Dch_Arriba) );
            Anim.SetBool("IdleDiagAbajo",xMovement == 0 && yMovement == 0 && ( lastDir == direccion.Izq_Abajo || lastDir == direccion.Dch_Abajo) );
            Anim.SetBool("AndarHorizontal",xMovement != 0 && yMovement == 0);
            Anim.SetBool("AndarArriba",xMovement == 0 && yMovement > 0 );
            Anim.SetBool("AndarAbajo",xMovement == 0 && yMovement < 0 );
            Anim.SetBool("AndarDiagArriba",(xMovement < 0 && yMovement > 0) || ( xMovement > 0 && yMovement > 0 ) );
            Anim.SetBool("AndarDiagAbajo",(xMovement < 0 && yMovement < 0) || ( xMovement > 0 && yMovement < 0 ) );
            
            
           

    }
}
