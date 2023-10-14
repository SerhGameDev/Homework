using UnityEngine;

public class SystemTraderArmor : ISystemTrade
{
    [SerializeField] private string Product = "Very Good Armor";
    public void Trade()
    {
        Debug.Log(Product);
    }
}
