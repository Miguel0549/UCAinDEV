using UnityEngine;

public class Camera : MonoBehaviour
{
    public Rigidbody2D CamaraRigidBody;
    public Rigidbody2D PlayerRigidBody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Fuera");
        if (collision.collider.tag == "Player")
        {
            CamaraRigidBody.linearVelocity = PlayerRigidBody.linearVelocity + new Vector2(2.0f,2.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Dentro");
        if (collision.collider.tag == "Player")
        {
            CamaraRigidBody.linearVelocity = new Vector2(0,0);
        }
    }
}
