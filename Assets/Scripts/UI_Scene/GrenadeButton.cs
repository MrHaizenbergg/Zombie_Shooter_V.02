using UnityEngine;
using UnityEngine.EventSystems;

public class GrenadeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private LaunchGrenade _launchGrenade;

    private void Start()
    {
        _launchGrenade = FindObjectOfType<LaunchGrenade>();
    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        if (SaveManager.instance.amountGrenade != 0)
            _launchGrenade.StartLaunch();
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        if (SaveManager.instance.amountGrenade != 0)
            _launchGrenade.ReleaseThrow();
    }
}
