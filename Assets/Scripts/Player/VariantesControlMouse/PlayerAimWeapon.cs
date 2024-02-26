using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform _aimTransform;
    //[SerializeField] private Camera worldCamera;

    private void Awake()
    {
        //_aimTransform = transform.Find("Aim");
        _aimTransform = transform;
    }

    private void Update()
    {
        Vector3 mousePos = GetMouseWorldPos();

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle= Mathf.Atan2(aimDirection.y,aimDirection.x)*Mathf.Rad2Deg;
        _aimTransform.eulerAngles=new Vector3(0,0,angle);
        Debug.Log(angle);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 vec = GetMouseWorldPosWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    private Vector3 GetMouseWorldPosWithZ()
    {
        return GetMouseWorldPosWithZ(Input.mousePosition, Camera.main);
    }

    private Vector3 GetMouseWorldPosWithZ(Camera worldPos)
    {
        return GetMouseWorldPosWithZ(Input.mousePosition, worldPos);
    }

    private Vector3 GetMouseWorldPosWithZ(Vector3 screenPos,Camera worldPos)
    {
        Vector3 worldPosition = worldPos.ScreenToWorldPoint(screenPos);
        return worldPosition;
    }
}
