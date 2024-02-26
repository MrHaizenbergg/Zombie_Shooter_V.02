using UnityEngine;

public class EnergyShell : MonoBehaviour
{
    [SerializeField] private GameObject _particleBloodEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            Instantiate(_particleBloodEffect, transform.position, Quaternion.identity);
            healthController.TakeDamage(25);
            Destroy(gameObject);
        }
        if (collision.GetComponent<EnemyShoot>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            Instantiate(_particleBloodEffect, transform.position, Quaternion.identity);
            healthController.TakeDamage(25);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<WallBlowTrigger>())
        {
            Destroy(gameObject);
        }
    }
}
