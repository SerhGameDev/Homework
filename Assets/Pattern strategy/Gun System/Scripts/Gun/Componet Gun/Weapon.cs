using UnityEngine;

public abstract class Weapon : MonoBehaviour, IInteractingInputSystem
{
    public abstract void Fire();

    public virtual void SubscriptionInputSystem(InputSystem inputSystem)
    {
        inputSystem.EventAttack += Fire;
    }

    public virtual void UnsubscribeInputSystem(InputSystem inputSystem)
    {
        inputSystem.EventAttack -= Fire;
    }
}
