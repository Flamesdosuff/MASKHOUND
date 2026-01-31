using UnityEngine;
using System;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;

    [Header("Economía")]
    public int dinero = 100;
    public int deuda = 100000;

    // Evento para UI
    public static event Action OnEconomyChanged;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ======================
    // DINERO
    // ======================
    public void AddDinero(int amount)
    {
        dinero += amount;
        Notify();
    }

    public void RemoveDinero(int amount)
    {
        dinero -= amount;
        if (dinero < 0) dinero = 0;
        Notify();
    }

    // ======================
    // DEUDA
    // ======================
    public void AddDeuda(int amount)
    {
        deuda += amount;
        Notify();
    }

    public void PayDeuda(int amount)
    {
        deuda -= amount;
        if (deuda < 0) deuda = 0;
        Notify();
    }

    void Notify()
    {
        OnEconomyChanged?.Invoke();
    }

    public bool PuedePagar(int amount)
    {
        return dinero >= amount;
    }

    public void Pagar(int amount)
    {
        if (!PuedePagar(amount))
            return;

        RemoveDinero(amount);
    }
    public void PagarTodaLaDeuda()
    {
        if (dinero <= 0 || deuda <= 0)
            return;

        int pago = Mathf.Min(dinero, deuda);

        dinero -= pago;
        deuda -= pago;

        Notify();
    }



}
