using UnityEngine;

public class ParedInvisibleBichos : MonoBehaviour
{
    void Update()
    {

        if (DatosGlobales.Lobos.Count == 0) Destroy(gameObject);

    }
}
