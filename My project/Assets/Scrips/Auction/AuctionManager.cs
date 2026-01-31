using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class AuctionManager : MonoBehaviour
{
    [Header("UI")]
    public Image itemImage;
    public TMP_Text bidText;        // cuanto va la apuesta
    public TMP_Text whoBetText;     // quien apostó
    public TMP_Text winnerText;     // quien ganó
    public Button betButton;

    [Header("Subasta")]
    public int bidInicial = 50;
    public int incremento = 10;
    public float duracionSubasta = 15f;
    public float tiempoEntreNPC = 2f;

    int bidActual;
    string ganador = "Nadie";
    bool subastaActiva;

    ItemData itemEnSubasta;
    List<NPCBidder> npcBidders = new List<NPCBidder>();

    void Start()
    {
        CrearNPCs();
        IniciarSubasta();
    }

    // =========================
    void IniciarSubasta()
    {
        bidActual = bidInicial;
        ganador = "Nadie";
        subastaActiva = true;

        itemEnSubasta = ExtraDatabase.Instance.GetRandomExtra();
        itemImage.sprite = itemEnSubasta.sprite;

        bidText.text = "Apuesta actual: $" + bidActual;
        whoBetText.text = "Nadie ha apostado";
        winnerText.text = "Ganador: ---";

        betButton.interactable = true;

        StartCoroutine(NPCBiddingLoop());
        Invoke(nameof(CerrarSubasta), duracionSubasta);
    }

    // =========================
    void CrearNPCs()
    {
        npcBidders.Clear();
        npcBidders.Add(new NPCBidder("NPC 1", 200, 0.6f));
        npcBidders.Add(new NPCBidder("NPC 2", 300, 0.5f));
        npcBidders.Add(new NPCBidder("NPC 3", 150, 0.4f));
    }

    // =========================
    public void PlayerBet()
    {
        if (!subastaActiva) return;
        if (EconomyManager.Instance.dinero < incremento) return;

        EconomyManager.Instance.RemoveDinero(incremento);

        bidActual += incremento;
        ganador = "Jugador";

        bidText.text = "Apuesta actual: $" + bidActual;
        whoBetText.text = "Jugador apostó";
    }

    // =========================
    IEnumerator NPCBiddingLoop()
    {
        while (subastaActiva)
        {
            yield return new WaitForSeconds(tiempoEntreNPC);

            foreach (var npc in npcBidders)
            {
                if (!subastaActiva) yield break;

                if (npc.TryBid(bidActual + incremento))
                {
                    bidActual += incremento;
                    ganador = npc.name;

                    bidText.text = "Apuesta actual: $" + bidActual;
                    whoBetText.text = npc.name + " apostó";
                    break;
                }
            }
        }
    }

    // =========================
    void CerrarSubasta()
    {
        subastaActiva = false;
        betButton.interactable = false;

        if (ganador == "Jugador")
        {
            InventoryManager.Instance.AddItem(itemEnSubasta);
        }

        winnerText.text = "Ganador: " + ganador;

        Invoke(nameof(IniciarSubasta), 3f);
    }
}
