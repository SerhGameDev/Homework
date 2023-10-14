using System.Collections;
using UnityEngine;

[System.Serializable] 
public abstract class SystemShoot
{
    public bool IsCanShoot = true;
    public float ShootInterval = 0.1f;
    public Bullet BulletPrefab;
    public Transform FirePoint;
    public float BulletSpeed = 10;
    public float BulletMaxDistanceFly = 10;
    public virtual void Shoot(MonoBehaviour monoBehaviourForCorutine)
    {
        if (IsCanShoot)
            monoBehaviourForCorutine.StartCoroutine(StartShoot());
    }
    protected abstract IEnumerator StartShoot();
}
