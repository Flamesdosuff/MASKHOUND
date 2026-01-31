using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Cambiar de escena
    public void otro()
    {
        Debug.Log("CLICK EN JUGAR");
        SceneManager.LoadScene("EscenaJuego");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}
