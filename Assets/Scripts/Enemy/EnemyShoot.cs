using UnityEngine;
using UnityEngine.Events;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunOffset;
    //[SerializeField] private Animator _animator;
    //[SerializeField] private AudioSource _audioSourceShot;

    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float reloadTime;

    [SerializeField] private bool reloading;

    public UnityEvent OnEnemyShoot;

    private bool _firePress;
    private bool _fireSingle;
    private float _lastTimeFire;

    private EnemyKnowPlayer _enemyKnowPlayer;

    private void Awake()
    {
        _enemyKnowPlayer = GetComponent<EnemyKnowPlayer>();
    }

    private void Update()
    {
        if (_enemyKnowPlayer.awareOfPlayer)
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
        //_audioSourceShot.Play();

        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);

        OnEnemyShoot.Invoke();

        //_animatorPistol.SetTrigger("isShoot");
        //_animOtdasha.SetTrigger("isOtdasha");
    }
}
