using UnityEngine;
using UnityEngine.Events;

public class GetGrenade : MonoBehaviour
{
    public UnityEvent grenadePickUp;
    private GrenadeAmount _amountOfGrenadeText;

    private void Awake()
    {
        _amountOfGrenadeText = FindObjectOfType<GrenadeAmount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            grenadePickUp.Invoke();
            SaveManager.instance.amountGrenade++;
            _amountOfGrenadeText.UpdateGrenadeUI(SaveManager.instance.amountGrenade);
            Destroy(gameObject);
        }
    }
}
