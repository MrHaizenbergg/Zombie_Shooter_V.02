using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{  
    public bool isDown { get; private set; }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }

    //private WeaponSwitching _weaponSwitching;

    //private GunPistol gunPistol;
    //private WeaponShotGun weaponShotGun;


    //private void Start()
    //{
    //    _weaponSwitching=FindObjectOfType<WeaponSwitching>();
    //    gunPistol=FindObjectOfType<GunPistol>();
    //    weaponShotGun=FindObjectOfType<WeaponShotGun>();
    //}

    //private void Update()
    //{
    //    if (_weaponSwitching.selectedWeapon == 0)
    //    {
    //        reloadCurrentGun.AddListener(gunPistol.StartCoroutineReloadBtn);
    //        reloadCurrentGun.RemoveListener(weaponShotGun.StartCoroutineReloadBtn);
    //    }
    //    if (_weaponSwitching.selectedWeapon == 1)
    //    {
    //        reloadCurrentGun.RemoveListener(gunPistol.StartCoroutineReloadBtn);
    //        reloadCurrentGun.AddListener(weaponShotGun.StartCoroutineReloadBtn);
    //    }
    //}
}
