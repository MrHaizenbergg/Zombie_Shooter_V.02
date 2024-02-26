using UnityEngine;

public class HelTriggerSound : MonoBehaviour
{
    [SerializeField] private AudioSource _soundLopast;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            _soundLopast.Play();
        }
    }
}