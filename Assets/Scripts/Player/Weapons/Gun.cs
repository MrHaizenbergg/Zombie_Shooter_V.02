using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunOffset;
    [SerializeField] private Animator _animatorAKA;
    [SerializeField] private Animator _animOtdasha;

    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float reloadTime;

    [SerializeField] private int currentAmmo;
    [SerializeField] private int magSize;

    [SerializeField] private bool reloading;
    [SerializeField] private bool isShooting;

    private float _lastTimeFire;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float timeSinceLastFire = Time.time - _lastTimeFire;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();

                _lastTimeFire = Time.time;

            }

        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);

        _animatorAKA.SetTrigger("isShoot");
        _animOtdasha.SetTrigger("isOtdasha");

    }
}
