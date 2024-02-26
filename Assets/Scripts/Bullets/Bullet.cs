using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _particleBloodEffect;
    [SerializeField] private GameObject _particleBloodCrabEffect;

    private float _damagePistol;
    private float _damageShotGun;
    private float _damageAKA;
    private float _damageMashineGun;
    private float _damageSniperRiffle;

    private void Awake()
    {
        _damagePistol = SaveManager.instance.damagePistol;
        _damageShotGun = SaveManager.instance.damageShotGun;
        _damageAKA = SaveManager.instance.damageAKA;
        _damageMashineGun = SaveManager.instance.damageMahineGun;
        _damageSniperRiffle = SaveManager.instance.damageSniperRiffle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            if (collision.GetComponent<EnemyShoot>())
                Instantiate(_particleBloodCrabEffect, transform.position, Quaternion.identity);
            else
                Instantiate(_particleBloodEffect, transform.position, Quaternion.identity);

            HealthController healthController = collision.GetComponent<HealthController>();

            if (gameObject.CompareTag("Pistol"))
                healthController.TakeDamage(_damagePistol);
            if (gameObject.CompareTag("Shotgun"))
                healthController.TakeDamage(_damageShotGun);
            if (gameObject.CompareTag("AKA"))
                healthController.TakeDamage(_damageAKA);
            if (gameObject.CompareTag("MashineGun"))
                healthController.TakeDamage(_damageMashineGun);
            if (gameObject.CompareTag("SniperRiffle"))
                healthController.TakeDamage(_damageSniperRiffle);

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
