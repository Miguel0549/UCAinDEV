using UnityEngine;

public class Lobo : MonoBehaviour
{
    public float Speed=8.0f;
    public Rigidbody2D rbody2d;
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
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        /*
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
        
        */
    }
}
