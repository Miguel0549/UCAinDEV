using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Jugar()
    {
        
        SceneManager.LoadScene("Nivel");
        
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
