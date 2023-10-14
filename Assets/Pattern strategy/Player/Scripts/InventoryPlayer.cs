using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour, IInteractingInputSystem
{
    public List<Weapon> ListGun;
    public Weapon GunSelect { get; private set; }
    private int _currentItemIndex = 0;
    
    private void Start()
    {
        SubscriptionInputSystem(InputSystem.Instance);
        if (ListGun.Count > 0)
            Change(ListGun[_currentItemIndex]);
    }
    private void OnDestroy()
    {
        UnsubscribeInputSystem(InputSystem.Instance);
    }

    public void Change(Weapon newGun)
    {
        if (newGun == null || !ListGun.Contains(newGun))
        {
            Debug.LogError("Invalid gun selected.");
            return;
        }
        RemoveGunSelect();
        SetGunSelect(newGun);
    }
    public void TurnOffAllGuns()
    {
        ListGun.ForEach(gun => { gun.gameObject.SetActive(false); });
    }
    private void SetGunSelect(Weapon newGun)
    {
        TurnOffAllGuns();
        GunSelect = newGun;
        GunSelect.gameObject.SetActive(true);
        GunSelect.SubscriptionInputSystem(InputSystem.Instance);
    }
    private void RemoveGunSelect()
    {
        if (GunSelect != null)
        {
            GunSelect.UnsubscribeInputSystem(InputSystem.Instance);
            GunSelect.gameObject.SetActive(false);
            GunSelect = null;
        }
    }

    public void MoveToNextGun()
    {
        _currentItemIndex = (_currentItemIndex + 1) % ListGun.Count;
        Change(ListGun[_currentItemIndex]);
    }

    public void MoveToPreviousGun()
    {
        _currentItemIndex = (_currentItemIndex - 1 + ListGun.Count) % ListGun.Count;
        Change(ListGun[_currentItemIndex]);
    }

    public void SubscriptionInputSystem(InputSystem inputSystem)
    {
        inputSystem.EventNextWeapon += MoveToNextGun;
        inputSystem.EventPreviousWeapon += MoveToPreviousGun;
    }

    public void UnsubscribeInputSystem(InputSystem inputSystem)
    {
        inputSystem.EventNextWeapon -= MoveToNextGun;
        inputSystem.EventPreviousWeapon -= MoveToPreviousGun;
    }
}
