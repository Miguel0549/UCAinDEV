using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float TimeToLive = 2.0f;
    public Collider2D OwnerCollider,ProjectileCollider; 
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

    void OnCollisionEnter()
    {
        Destroy(this);
    }
}
