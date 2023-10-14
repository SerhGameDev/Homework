using UnityEngine;

public interface IInteractingInputSystem
{
    void SubscriptionInputSystem(InputSystem inputSystem);
    void UnsubscribeInputSystem(InputSystem inputSystem);
}
