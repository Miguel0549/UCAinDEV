using UnityEngine;
using UnityEngine.SceneManagement;

public class VidasGusano : MonoBehaviour
{

    private VidasEnemigos[] cuerpos;
    public int n_cuerpos = 6;
    private int cuerpos_derrotados = 0;

    void Start()
    {
        cuerpos = GetComponentsInChildren<VidasEnemigos>();
    }
    
    void FixedUpdate()
    {

        for (int i = 2; i < 8; i++)
        {
            if (cuerpos[i].derrotado == true && cuerpos[i].contado == false)
            {
                cuerpos_derrotados++;
                cuerpos[i].contado = true;
            }
        }
        
        if ( cuerpos_derrotados == n_cuerpos ) SceneManager.LoadScene("Menu");
       
    }
}
