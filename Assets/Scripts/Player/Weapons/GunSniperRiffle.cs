using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GunSniperRiffle : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunOffset;
    [SerializeField] private Animator _animatorSniperRiffle;
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

    [SerializeField] private int _magSize;

    [SerializeField] private AudioSource _audioSourceReload;
    [SerializeField] private AudioSource _audioSourceShot;

    private bool isReloading = false;
    private bool isPC;
    private bool isAndroid;

    private int currentAmmo = -1;

    private float _lastTimeFire;
    public UnityEvent OnSniperRiffleShoot;

    private void Awake()
    {
        _weaponUI = FindObjectOfType<AmmoAndWeaponUI>();
        _reloadButton = FindObjectOfType<ReloadButton>();
        _fireButton = FindObjectOfType<FireButton>();

        _timeBetweenShots = SaveManager.instance.timeBetweenShotsSniperRiffle;
        _bulletSpeed = SaveManager.instance.bulletSpeedSniperRiffle;
        _damage = SaveManager.instance.damageSniperRiffle;
        _reloadTime = SaveManager.instance.reloadTimeSniperRiffle;
        _magSize = SaveManager.instance.magSizeSniperRiffle;

        //if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("PC");
        //}
        //else if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    isPC = true;
        //    isAndroid = false;
        //    Debug.Log("isEditor");
        //}

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

        Debug.Log("TimeBetweenShots " + _timeBetweenShots);
        Debug.Log("BulletSpeed " + _bulletSpeed);
        Debug.Log("Damage " + _damage);
        Debug.Log("ReloadTime " + _reloadTime);
        Debug.Log("magSize " + _magSize);
    }

    private void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = _magSize;

        OnSniperRiffleShoot.Invoke();
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
        OnSniperRiffleShoot.AddListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
        OnSniperRiffleShoot.Invoke();
        Debug.Log("AddEventWeapon");
    }

    private void OnDisable()
    {
        OnSniperRiffleShoot.RemoveListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
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

    IEnumerator Reload()
    {
        isReloading = true;
        _audioSourceReload.Play();
        Debug.Log("Reload");

        yield return new WaitForSeconds(_reloadTime);

        currentAmmo = _magSize;
        isReloading = false;
        OnSniperRiffleShoot.Invoke();
    }

    private void FireBullet()
    {
        _audioSourceShot.Play();
        _particleFallBullets.Play();

        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);

        currentAmmo--;

        OnSniperRiffleShoot.Invoke();

        _animatorSniperRiffle.SetTrigger("isShoot");
        _animOtdasha.SetTrigger("isOtdasha");
    }
}
