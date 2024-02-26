using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private DoorTopDown doorTopDown;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        doorTopDown.OpenDoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(collision.gameObject);
        }
    }

    //public void PlayOpenFailAnim()
    //{
    //    doorAnims.PlayOpenFailAnim();
    //}
}
