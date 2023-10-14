using System.Collections;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TextMeshPro;
    [SerializeField] private InventoryPlayer InventoryPlayer;
    private const float IntervalUpdate = 0.1f;

    private void Start()
    {
        InputSystem.Instance.EventAttack += UpdateText;
        InputSystem.Instance.EventReload += UpdateText;
        InputSystem.Instance.EventNextWeapon += UpdateText;
        InputSystem.Instance.EventPreviousWeapon += UpdateText;

        UpdateText();
    }

    private IEnumerator StartUpdateText()
    {
        yield return new WaitForSeconds(IntervalUpdate);

        Weapon gun = InventoryPlayer.GunSelect;

        if (gun == null)
            yield break;

        if (gun is IReloaded reloadedGun)
        {
            _TextMeshPro.text = reloadedGun.Magazine.Bullet + " / " + reloadedGun.Magazine.BulletTotalCount;
        }
        else
        {
            _TextMeshPro.text = "∞";
        }
    }
    private void UpdateText()
    {
        StartCoroutine(StartUpdateText());
    }
}
