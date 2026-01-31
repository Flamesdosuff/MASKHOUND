using UnityEngine;


public class NPCBidder
{
    public string name;
    int money;
    float aggressiveness;

    public NPCBidder(string name, int money, float aggressiveness)
    {
        this.name = name;
        this.money = money;
        this.aggressiveness = aggressiveness;
    }

    public bool TryBid(int nextBid)
    {
        if (money < nextBid)
            return false;

        if (Random.value < aggressiveness)
        {
            money -= nextBid;
            return true;
        }

        return false;
    }
}
