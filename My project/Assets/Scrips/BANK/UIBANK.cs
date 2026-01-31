using UnityEngine;

public class BankUI : MonoBehaviour
{
    public void Pay()
    {
        EconomyManager.Instance.PagarTodaLaDeuda();
    }
}
