using UnityEngine;
using UnityEngine.UI;

public class AmmoAndWeaponUI:MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    [SerializeField] private Text _maxAmmoText;

    [SerializeField] private Image _weaponImage;

    public void UpdateAmmoAndWeapon(Sprite weaponIcon, int ammo, int magSize)
    {
        _weaponImage.sprite = weaponIcon;
        _ammoText.text = ammo.ToString();
        _maxAmmoText.text = magSize.ToString();
    }
}
