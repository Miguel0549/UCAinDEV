using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Vidas_Player : MonoBehaviour
{

    public int VidaMaxima = 4;
    private int contadorVidasPerdidas = 0;
    public GameObject Corazones;
    public Sprite corazon_vacio;
    public float dmg_delay = 2.0f;
    private float dmg_cd = 0f;
    
    
    void Update()
    {
        if (dmg_cd > 0) dmg_cd -= Time.deltaTime;
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Cabeza" )
        {
            if ( dmg_cd > 0 ) return;
            
            Debug.Log("Colision");
            Image[] corazon = Corazones.GetComponentsInChildren<Image>();                               
            corazon[contadorVidasPerdidas].sprite = corazon_vacio;                                       

            contadorVidasPerdidas++;
            
            if (contadorVidasPerdidas >= VidaMaxima) Debug.Log("Vidas perdidas");
            
            dmg_cd = dmg_delay;
            
        }
        
    }

}
