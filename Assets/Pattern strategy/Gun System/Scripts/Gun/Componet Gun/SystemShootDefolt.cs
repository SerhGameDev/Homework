using System.Collections;
using UnityEngine;

[System.Serializable]
public class SystemShootDefolt : SystemShoot
{
    protected override IEnumerator StartShoot()
    {
        IsCanShoot = false;
        Vector3 direction = Quaternion.Euler(0, 1, 0) * FirePoint.forward;
        Bullet bullet = MonoBehaviour.Instantiate(BulletPrefab, FirePoint.position, Quaternion.LookRotation(direction));
        bullet.bulletSpeed = BulletSpeed;
        yield return new WaitForSeconds(ShootInterval);
        IsCanShoot = true;
    }
}
