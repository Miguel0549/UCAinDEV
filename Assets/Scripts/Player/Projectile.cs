using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float TimeToLive = 2.0f;
    public Collider2D ProjectileCollider; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        TimeToLive -= Time.fixedDeltaTime;
        if (TimeToLive <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D( Collider2D collision )
    {
       
        if ( collision.gameObject.tag != "Alerta") Destroy(this.gameObject);
    }
}
