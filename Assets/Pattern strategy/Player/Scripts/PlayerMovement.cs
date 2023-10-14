using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float SpeedRotateCharacter = 10;
    public bool IsCanMove = true;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        if (InputSystem.Instance.VectorInputMove != Vector3.zero && IsCanMove)
        {
            MoveCharacter(InputSystem.Instance.VectorInputMove);
            RotateCharacter(InputSystem.Instance.VectorInputMove);
        }
    }

    private void MoveCharacter(Vector3 movement) => _rigidbody.MovePosition(_rigidbody.position + movement * MoveSpeed * Time.deltaTime);
    private void RotateCharacter(Vector3 movement)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * SpeedRotateCharacter);
    }
}
