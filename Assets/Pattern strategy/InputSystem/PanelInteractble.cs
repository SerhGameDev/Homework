using UnityEngine;
using UnityEngine.Events;

public class PanelInteractble : MonoBehaviour
{
    public UnityEvent UnityEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            InputSystem.Instance.EventInteractble += Interactble;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            InputSystem.Instance.EventInteractble -= Interactble;
    }
    public void Interactble() => UnityEvent?.Invoke();
}
