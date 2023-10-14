using UnityEngine;

public class Shotgun : Weapon, IReloaded
{
    public SystemShootShotgun ShootSystem;
    [field: SerializeField] public Magazine Magazine { get; set; }

    public override void Fire()
    {
        if (Magazine.IsReload)
            return;
        if (!Magazine.CheckBullet())
            return;
        if(!ShootSystem.IsCanShoot)
            return;

        Magazine.RemoveBullet(ShootSystem.BulletCount);
        ShootSystem.Shoot(this);
    }
    public void Reload()
    {
        Debug.Log("Reload");
        Magazine.Reload(this);
    }

    public override void SubscriptionInputSystem(InputSystem inputSystem)
    {
        inputSystem.EventAttack += Fire;
        inputSystem.EventReload += Reload;
    }
    public override void UnsubscribeInputSystem(InputSystem inputSystem)
    {
        inputSystem.EventAttack -= Fire;
        inputSystem.EventReload -= Reload;
    }
}
