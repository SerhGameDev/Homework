using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; 
    public float followSpeed = 5.0f; 
    public Vector3 offset; 

    private void FixedUpdate()
    {
        if (target != null)
            FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
