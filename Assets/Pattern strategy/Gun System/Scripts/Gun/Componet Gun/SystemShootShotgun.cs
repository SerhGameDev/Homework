using System.Collections;
using UnityEngine;

[System.Serializable]
public class SystemShootShotgun : SystemShoot
{
    public int BulletCount = 3;
    [SerializeField] private float spreadAngle = 30f;
    protected override IEnumerator StartShoot()
    {
        IsCanShoot = false;
        for (int i = 0; i < BulletCount; i++)
        {
            float angle = spreadAngle / (BulletCount - 1) * i - spreadAngle / 2f;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * FirePoint.forward;
            Bullet bullet = MonoBehaviour.Instantiate(BulletPrefab, FirePoint.position, Quaternion.LookRotation(direction));
            bullet.bulletSpeed = BulletSpeed;
        }
        yield return new WaitForSeconds(ShootInterval);
        IsCanShoot = true;
    }
}

