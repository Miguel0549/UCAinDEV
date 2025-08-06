using UnityEngine;

public class ParedInvisibleBoss : MonoBehaviour
{
    public Camera camara;
    public Collider2D ParedInvisible;
    void Start()
    {
        ParedInvisible.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.main.orthographicSize = 8f;
            ParedInvisible.enabled = true;
        }
        
    }
}
