using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float maxDistance = 50f;

    private float traveledDistance = 0f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        traveledDistance = Vector3.Distance(initialPosition, transform.position);
        if (traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
