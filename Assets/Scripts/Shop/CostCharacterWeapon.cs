using UnityEngine;
using UnityEngine.UI;

public class CostCharacterWeapon : MonoBehaviour
{
    [SerializeField] private CharacteristicWeapons _characteristicWeapon;

    [SerializeField] private Text _timeBetweenShots;
    [SerializeField] private Text _bulletSpeed;
    [SerializeField] private Text _damage;
    [SerializeField] private Text _reloadTime;
    [SerializeField] private Text _magSize;

    private void Awake()
    {
        ShowCostWeaponUpgrade();
    }

    private void ShowCostWeaponUpgrade()
    {
        _timeBetweenShots.text = _characteristicWeapon._timeBetweenShotPrice.ToString();
        _bulletSpeed.text = _characteristicWeapon._bulletSpeedPrice.ToString();
        _damage.text = _characteristicWeapon._damageUpgradePrice.ToString();
        _reloadTime.text = _characteristicWeapon._reloadTimePrice.ToString();
        _magSize.text = _characteristicWeapon._magSizePrice.ToString();
    }
}
