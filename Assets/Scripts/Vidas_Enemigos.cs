using UnityEngine;


public class VidasEnemigos : MonoBehaviour
{

    public int VidaMaxima = 5;
    private int contadorVidasPerdidas = 0;
	public Sprite CuerpoGusanoDestruido;
	public bool derrotado = false;
	public bool contado = false; 

	private SpriteRenderer SprR;

	void Start()
	{

		SprR = GetComponent<SpriteRenderer>();

	}

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet") contadorVidasPerdidas++;
        if (contadorVidasPerdidas >= VidaMaxima)
		{
			
			derrotado = true;
			if ( this.tag == "CuerpoGusanoGema" ) SprR.sprite = CuerpoGusanoDestruido;	
			else if ( this.tag == "Enemigo" ) Destroy(this.gameObject);
			

		}
    
    
	}
}
