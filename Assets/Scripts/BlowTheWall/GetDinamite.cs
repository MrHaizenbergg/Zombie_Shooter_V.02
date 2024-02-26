using UnityEngine;
using UnityEngine.Events;

public class GetDinamite : MonoBehaviour
{
    public UnityEvent _getDynamite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _getDynamite.Invoke();
            Destroy(gameObject);
        }
    }

    private void AddDinamite()
    {

    }
}
