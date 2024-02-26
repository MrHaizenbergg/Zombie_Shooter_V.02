using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{

    [SerializeField] private KeyType keyType;

    public UnityEvent keyPickUp;

    public enum KeyType
    {
        Red,
        Green,
        Blue
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }

    public static Color GetColor(KeyType keyType)
    {
        switch (keyType)
        {
            default:
            case KeyType.Red: return Color.red;
            case KeyType.Green: return Color.green;
            case KeyType.Blue: return Color.blue;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keyPickUp.Invoke();
        }
    }
}
