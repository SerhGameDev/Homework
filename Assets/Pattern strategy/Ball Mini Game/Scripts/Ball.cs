using System;
using UnityEngine;


public class Ball : MonoBehaviour, IClickable
{
    public TipeColorBall Color = TipeColorBall.Red;

    public event Action<Ball> OnDestroyEvent;

    private MeshRenderer _ballRenderer;

    private void OnValidate()
    {
        _ballRenderer = GetComponent<MeshRenderer>();
        UpdateColor();
    }

    private void Awake()
    {
        _ballRenderer = GetComponent<MeshRenderer>();
        UpdateColor();
    }

    public void Clicked()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        OnDestroyEvent?.Invoke(this);
    }
    private void UpdateColor()
    {
        if (_ballRenderer == null)
            return;

        Color newColor = UnityEngine.Color.red;

        switch (Color)
        {
            case TipeColorBall.Red:
                newColor = UnityEngine.Color.red;
                break;
            case TipeColorBall.White:
                newColor = UnityEngine.Color.white;
                break;
            case TipeColorBall.Green:
                newColor = UnityEngine.Color.green;
                break;
        }

        Material newMaterial = new Material(_ballRenderer.sharedMaterial);
        newMaterial.color = newColor;
        _ballRenderer.material = newMaterial;
    }
}
public enum TipeColorBall
{
    Red,
    White,
    Green
}