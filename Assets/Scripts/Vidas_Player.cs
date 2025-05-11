using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Vidas_Player : MonoBehaviour
{

    public int VidaMaxima = 4;
    private int contadorVidasPerdidas = 0;
    public GameObject Corazones;
    public Sprite corazon_vacio;
    private bool invulnerable = false; 
    public float dmg_delay = 2.0f;
    
    
    void OnTriggerStay2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Cabeza" )
        {
            if ( invulnerable == true ) return;
            
            Image[] corazon = Corazones.GetComponentsInChildren<Image>();                                /*          */
            corazon[contadorVidasPerdidas].sprite = corazon_vacio;                                       /*Error aqui*/

            contadorVidasPerdidas += 1;
            
            if (contadorVidasPerdidas >= VidaMaxima) Debug.Log("Vidas perdidas");
            
            invulnerable = true;
            
            StartCoroutine(DamageDelay());
        }

        
        
    }
    
    
    private IEnumerator DamageDelay()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(dmg_delay);

        // Set the invulnerable flag to false
        invulnerable = false;
    }

}
