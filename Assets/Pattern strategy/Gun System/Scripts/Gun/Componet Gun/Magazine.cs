using System.Collections;
using UnityEngine;

[System.Serializable]
public class Magazine
{
    [field: SerializeField] public int Bullet { get; private set; }
    [field: SerializeField] public int BulletMaxReload { get; private set; }
    [field: SerializeField] public int BulletTotalCount { get; private set; }
    [field: SerializeField] public bool IsReload { get; private set; }

    [SerializeField] private float _intervalReload;
    public void RemoveBullet(int index) 
    {
        if (Bullet - index < 0)
            return;

        Bullet -= index;
    }
    public void Reload(MonoBehaviour monoBehaviour)
    {
        if (IsReload)
            return;

        if (BulletTotalCount + Bullet < 0)
            return;

        monoBehaviour.StartCoroutine(StartReload());
    }

    private IEnumerator StartReload()
    {
        IsReload = true;

        BulletTotalCount += Bullet;
        Bullet = 0;

        if (BulletTotalCount > BulletMaxReload)
        {
            Bullet += BulletMaxReload;
            BulletTotalCount -= BulletMaxReload;
        }
        else
        {
            Bullet = BulletTotalCount;
            BulletTotalCount = 0;
        }

        yield return new WaitForSeconds(_intervalReload);
        IsReload = false;
    }
    public bool CheckBullet() => Bullet > 0;
}
