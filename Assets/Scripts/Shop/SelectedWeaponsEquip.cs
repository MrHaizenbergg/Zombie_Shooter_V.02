using UnityEngine;
using UnityEngine.UI;

public class SelectedWeaponsEquip : MonoBehaviour
{
    [SerializeField] private Image _weaponIcon;
    private int currentWeapon;

    [SerializeField] private Sprite[] _weaponSprite;

    public void SetWeaponIcon()
    {
        currentWeapon = SaveManager.instance.currentWeapon;

        for (int i = 0; i < _weaponSprite.Length; i++)
        {
            if (i == currentWeapon)
            {
                _weaponIcon.sprite = _weaponSprite[i];
            }
        }
    }

    public void SetWeaponIconTwoSlot()
    {
        currentWeapon = SaveManager.instance.currentWeaponTwo;

        for (int i = 0; i < _weaponSprite.Length; i++)
        {
            if (i == currentWeapon)
            {
                _weaponIcon.sprite = _weaponSprite[i];
            }
        }
    }

}
