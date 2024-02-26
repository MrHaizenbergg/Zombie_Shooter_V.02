using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeWeapon : MonoBehaviour, IPointerDownHandler
{
    public bool isDown { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PressBtn());
    }

    private IEnumerator PressBtn()
    {
        isDown = true;
        yield return new WaitForEndOfFrame();
        isDown = false;
    }
}
