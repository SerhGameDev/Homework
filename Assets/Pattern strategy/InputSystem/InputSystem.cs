using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event Action EventAttack;
    public event Action EventReload;
    public event Action EventNextWeapon;
    public event Action EventPreviousWeapon;
    public event Action EventInteractble;

    public Vector3 VectorInputMove;

    [SerializeField] private KeyCode KeyCodeAttack = KeyCode.Mouse0;
    [SerializeField] private KeyCode KeyCodeReload = KeyCode.R;
    [SerializeField] private KeyCode KeyCodeNextWeapon = KeyCode.X;
    [SerializeField] private KeyCode KeyCodePreviousWeapon = KeyCode.Z;
    [SerializeField] private KeyCode KeyCodeInteractble = KeyCode.F;

    private void Awake()
    {
        Singleton();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCodeAttack))
            EventAttack?.Invoke();
        if (Input.GetKeyDown(KeyCodeReload))
            EventReload?.Invoke();
        if (Input.GetKeyDown(KeyCodeNextWeapon))
            EventNextWeapon?.Invoke();
        if (Input.GetKeyDown(KeyCodePreviousWeapon))
            EventPreviousWeapon?.Invoke();
        if (Input.GetKeyDown(KeyCodeInteractble))
            EventInteractble?.Invoke();

        VectorInputMove = GetVectorInput();
    }
    private Vector3 GetVectorInput()
    {
        Vector3 vectorInput = Vector3.zero;

        vectorInput.x = Input.GetAxis("Horizontal");
        vectorInput.y = 0;
        vectorInput.z = Input.GetAxis("Vertical");

        return vectorInput;
    }
    #region Singleton
    public static InputSystem Instance { get { return _instance; } }
    private static InputSystem _instance;

    public void Singleton()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    #endregion
}
