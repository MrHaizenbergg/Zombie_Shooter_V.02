using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class WeaponShotGun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _oneDulo;
    [SerializeField] private Transform _twoDulo;
    [SerializeField] private Animator _animatorMuzzleOne;
    [SerializeField] private Animator _animatorMuzzleTwo;
    [SerializeField] private Animator _animOtdasha;

    [SerializeField] private ParticleSystem _particleFallBullets;

    private ReloadButton _reloadButton;
    private FireButton _fireButton;

    private AmmoAndWeaponUI _weaponUI;
    [SerializeField] private Sprite _weaponSprite;

    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _reloadTime;

    [SerializeField] private int _amountOfBullets;
    private float spread = 0.2f;
    [SerializeField] private int _magSize;

    [SerializeField] private bool isFirstDulo = true;

    [SerializeField] private AudioSource _audioSourceReload;
    [SerializeField] private AudioSource _audioSourceShot;

    private bool isReloading = false;
    //public bool getShotGunEventOff;
    private bool isPC;
    private bool isAndroid;

    private int currentAmmo = -1;

    private float _lastTimeFire;
    public UnityEvent OnShotgunShoot;

    private void Awake()
    {
        _weaponUI = FindObjectOfType<AmmoAndWeaponUI>();
        _reloadButton = FindObjectOfType<ReloadButton>();
        _fireButton = FindObjectOfType<FireButton>();

        _timeBetweenShots = SaveManager.instance.timeBetweenShotsShotGun;
        _bulletSpeed = SaveManager.instance.bulletSpeedShotGun;
        _damage = SaveManager.instance.damageShotGun;
        _reloadTime = SaveManager.instance.reloadTimeShotGun;
        _magSize = SaveManager.instance.magSizeShotGun;
        _amountOfBullets = 4;

        if (Application.isMobilePlatform)
        {
            isAndroid = true;
            isPC = false;
            Debug.Log("Android");
        }
        else
        {
            isPC = true;
            isAndroid = false;
            Debug.Log("PC");
        }
    }

    private void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = _magSize;

        OnShotgunShoot.Invoke();
    }

    public int GetCurrentAmmo
    {
        get
        {
            return currentAmmo;
        }
    }

    private void OnEnable()
    {
        isReloading = false;
            OnShotgunShoot.AddListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
            OnShotgunShoot.Invoke();
            Debug.Log("AddEventWeapon");     
    }

    private void OnDisable()
    {
        OnShotgunShoot.RemoveListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
        Debug.Log("RemoveEventWeapon");
    }

    private void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (isPC)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }

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
        else if (isAndroid)
        {
            if (_reloadButton.isDown)
            {
                StartCoroutine(Reload());
                return;
            }

            if (_fireButton.isDown)
            {
                float timeSinceLastFire = Time.time - _lastTimeFire;

                if (timeSinceLastFire >= _timeBetweenShots)
                {
                    FireBullet();

                    _lastTimeFire = Time.time;

                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }

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
    }

    public void StartCoroutineReloadBtn()
    {
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        isReloading = true;
        _audioSourceReload.Play();
        Debug.Log("Reload");

        yield return new WaitForSeconds(_reloadTime);

        currentAmmo = _magSize;
        isReloading = false;
        OnShotgunShoot.Invoke();
    }

    private void FireBullet()
    {
        if (isFirstDulo)
        {
            _audioSourceShot.Play();
            _particleFallBullets.Play();

            for (int i = 0; i < _amountOfBullets; i++)
            {
                GameObject bullet = Instantiate(_bulletPrefab, _twoDulo.position, transform.rotation);
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                Vector2 dir = transform.rotation * Vector2.up;
                Vector2 veer = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
                rigidbody.AddForce((dir + veer) * _bulletSpeed, ForceMode2D.Impulse);
            }

            _animatorMuzzleOne.SetTrigger("isShoot");
            isFirstDulo = false;
            Debug.Log("OneDuloShot");
        }
        else
        {
            _audioSourceShot.Play();
            _particleFallBullets.Play();

            for (int i = 0; i < _amountOfBullets; i++)
            {
                GameObject bullet = Instantiate(_bulletPrefab, _oneDulo.position, transform.rotation);
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                Vector2 dir = transform.rotation * Vector2.up;
                Vector2 veer = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
                rigidbody.AddForce((dir + veer) * _bulletSpeed, ForceMode2D.Impulse);
            }

            _animatorMuzzleTwo.SetTrigger("isShoot");
            isFirstDulo = true;
            Debug.Log("TwoDuloShot");
        }

        currentAmmo--;

        OnShotgunShoot.Invoke();

        _animOtdasha.SetTrigger("isOtdasha");
    }
}
