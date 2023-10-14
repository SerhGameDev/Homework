using UnityEngine;

public class Trader : MonoBehaviour
{
    public bool IsWantsTradePlayer;
    public TypeTrade TypeTrade;
    public ISystemTrade SystemTrade;

    private void Start()
    {
        SetSystemTradeForType();
    }

    public void Trade()
    {
        SystemTrade.Trade();
    }
    public void SetSystemTradeForType()
    {
        if(TypeTrade == TypeTrade.Armor)
            SystemTrade = new SystemTraderArmor();
        if (TypeTrade == TypeTrade.Fruit)
            SystemTrade = new SystemTradeFruit();
    }
}
