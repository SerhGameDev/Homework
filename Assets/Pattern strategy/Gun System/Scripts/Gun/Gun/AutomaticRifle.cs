using UnityEngine;

public class AutomaticRifle : Weapon, IReloaded
{
    public SystemShootDefolt SystemShoot;
    [field: SerializeField] public Magazine Magazine { get; set; }

    public override void Fire()
    {
        if (Magazine.IsReload)
            return;
        if (!Magazine.CheckBullet())
            return;
        if (!SystemShoot.IsCanShoot)
            return;

        Magazine.RemoveBullet(1);
        SystemShoot.Shoot(this);
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
