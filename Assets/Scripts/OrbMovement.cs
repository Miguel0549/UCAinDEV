using UnityEngine;

public class Orb : MonoBehaviour
{
    public Transform origin;
    public Camera cam;
    public float radius;
    public GameObject projectile;
    public float firerate;
    public float projectileSpeed;
    private float lastfire = 0f;
    private Vector3 cursor;
    private Vector3 lastcursor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam=Camera.main;
        lastcursor = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 newpos;

      cursor = cam.ScreenToWorldPoint(Input.mousePosition);
      if (Vector3.Distance(cursor,origin.position) < radius) cursor = lastcursor; //Si el cursor esta dentro del personaje.
      Vector3 direction = cursor - origin.position;
      float angle = Mathf.Atan2(direction.y,direction.x);

      Debug.Log(angle);

      newpos.x = origin.position.x + Mathf.Cos(angle  ) * radius;
      newpos.y = origin.position.y + Mathf.Sin(angle ) * radius; 
      newpos.z = origin.position.z;

      transform.position = newpos;
    }

    void FixedUpdate()
    {
      if (Input.GetKey(KeyCode.Mouse0)&&Time.fixedTime-lastfire > firerate)
      {
        Debug.Log("!!FIRE");
        GameObject newproj = Instantiate(projectile,transform.position,Quaternion.identity);
        newproj.GetComponent<Rigidbody2D>().linearVelocity = (Vector2) Vector3.Normalize(cursor-transform.position) * projectileSpeed;
        lastfire = Time.fixedTime;
      }
    }
}
