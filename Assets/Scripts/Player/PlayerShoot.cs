using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunOffset;
    [SerializeField] private Animator _animatorAKA;

    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float reloadTime;

    [SerializeField] private int currentAmmo;
    [SerializeField] private int magSize;

    [SerializeField] private bool reloading;

    private bool _firePress;
    private bool _fireSingle;
    private float _lastTimeFire;

    private void Update()
    {
        if (_firePress || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastTimeFire;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();

                _lastTimeFire = Time.time;
                _fireSingle = false;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);

        _animatorAKA.SetTrigger("isShoot");
    }

    //private void OnFire(InputValue inputValue)
    //{
    //    _firePress = inputValue.isPressed;

    //    if (inputValue.isPressed)
    //    {
    //        _fireSingle = true;
    //    }
    //}
}
