using UnityEngine;
using static UnityEngine.TouchScreenKeyboard;

public class WeaponSwitching : MonoBehaviour
{
    private ChangeWeapon _changeWeaponBtn;

    private bool isPC;
    private bool isAndroid;

    public int selectedWeapon = 0;

    private void Awake()
    {
        _changeWeaponBtn = FindObjectOfType<ChangeWeapon>();

        //if (Application.platform==RuntimePlatform.)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("PC");
        //}
        //else if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("isEditor");
        //}

        if (Application.isMobilePlatform)
        {
            isAndroid = true;
            isPC = false;
            Debug.Log("Android");
        }
        else
        {
            isPC = true;
            isAndroid = false;
            Debug.Log("PC");
        }
    }

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (isPC)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }
        }
        else if (isAndroid)
        {
            if (_changeWeaponBtn.isDown)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }
            //if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            //{
            //    if (selectedWeapon <= 0)
            //        selectedWeapon = transform.childCount - 1;
            //    else
            //        selectedWeapon--;
            //}
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }
        }


        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
