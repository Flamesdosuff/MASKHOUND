using UnityEngine;
using UnityEngine.SceneManagement;


public class salir : MonoBehaviour
{
    public void btnSalir()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
}
