using UnityEngine;


public class NewMonoBehaviourScript : MonoBehaviour
{

    public int VidaMaxima = 5;
    private int contadorVidasPerdidas = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet") contadorVidasPerdidas++;
        if (contadorVidasPerdidas >= VidaMaxima) Destroy(this.gameObject);

    }
    
    
}
