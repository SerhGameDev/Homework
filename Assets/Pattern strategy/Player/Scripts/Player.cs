using UnityEngine;

[RequireComponent (typeof(InventoryPlayer))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [HideInInspector] public PlayerMovement PlayerMovement;
    [HideInInspector] public InventoryPlayer InventoryPlayer;
    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        InventoryPlayer = GetComponent<InventoryPlayer>();
    }
}
