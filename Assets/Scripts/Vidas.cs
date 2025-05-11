using UnityEngine;

public class Vidas : MonoBehaviour
{

    public int VidaMaxima = 4;
    private int contadorVidasPerdidas = 0;
    public GameObject Corazones;
    public Sprite corazon_vacio;
    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag == "Player")
        {
            Debug.Log("Colision de Jugador");
            if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Cabeza" )
            {

                Debug.Log("Colision de Jugador con Enemigo");
                SpriteRenderer[] corazon = Corazones.GetComponentsInChildren<SpriteRenderer>();
                corazon[contadorVidasPerdidas].sprite = corazon_vacio;
                Debug.Log("CAMBIO SPRITE");

                contadorVidasPerdidas += 1;

            }

            if (contadorVidasPerdidas >= VidaMaxima) Debug.Log("Vidas perdidas");
        }
        else
        {
            
            if (collision.gameObject.tag == "Bullet")
            {

                contadorVidasPerdidas += 1;

            }
            Debug.Log(contadorVidasPerdidas);
            if (contadorVidasPerdidas >= VidaMaxima) Destroy(gameObject);


        }
        

    }
}
