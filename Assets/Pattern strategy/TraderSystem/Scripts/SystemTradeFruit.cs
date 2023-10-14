using UnityEngine;

public class SystemTradeFruit : ISystemTrade
{
    [SerializeField] private string Product = "Very Good Fruit";
    public void Trade()
    {
        Debug.Log(Product);
    }
}
