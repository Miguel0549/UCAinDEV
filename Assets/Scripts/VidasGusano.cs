using UnityEngine;
using UnityEngine.SceneManagement;

public class VidasGusano : MonoBehaviour
{

    private VidasEnemigos[] cuerpos;
    public int n_cuerpos = 5;
    public int cuerpos_derrotados = 0;

    void Start()
    {
        cuerpos = GetComponentsInChildren<VidasEnemigos>();
    }
    
    void FixedUpdate()
    {

        for (int i = 0; i < 5; i++)
        {
            if (cuerpos[i].derrotado == true && cuerpos[i].contado == false)
            {
                cuerpos_derrotados++;
                cuerpos[i].contado = true;
            }
        }
        
        Debug.Log(cuerpos_derrotados);
        if ( cuerpos_derrotados >= n_cuerpos ) SceneManager.LoadScene("Menu");
       
    }
}
