using UnityEngine;

public class LaserGun : Weapon
{
    public SystemShootDefolt SystemShoot;
    public override void Fire()
    {
        SystemShoot.Shoot(this);
    }
}
