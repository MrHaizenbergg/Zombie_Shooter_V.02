using UnityEngine;
using UnityEngine.Events;

public class TriggerMessagePoint : MonoBehaviour
{
    public UnityEvent isTriggerPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggerPoint.Invoke();
        }
    }
}
