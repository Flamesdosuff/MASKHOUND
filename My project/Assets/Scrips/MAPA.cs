using UnityEngine;
using UnityEngine.SceneManagement;

public class MAPA: MonoBehaviour
{
    // Cambiar de escena
    public void Market()
    {
        SceneManager.LoadScene("Market");
    }
    public void BANK()
    {
        SceneManager.LoadScene("BANK");
    }
    public void PARK()
    {
        SceneManager.LoadScene("PARK");
    }
    public void Jewerlyshop()
    {
        SceneManager.LoadScene("Jewerlyshop");
    }
    public void MaskShop()
    {
        SceneManager.LoadScene("MaskShop");
    }
}

