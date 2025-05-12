using UnityEngine;

public class ParedInvisibleBichos : MonoBehaviour
{
    
    public string Enemigo_1;
    public string Enemigo_2;
    
    
    void Update()
    {

        if (GameObject.Find(Enemigo_1) == null && GameObject.Find(Enemigo_2) == null) Destroy(gameObject);

    }
}
