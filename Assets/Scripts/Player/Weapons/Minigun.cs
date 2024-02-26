using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Minigun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform[] _gunOffset;
    [SerializeField] private Animator _animatorMinigunOne;
    [SerializeField] private Animator _animatorMinigunTwo;
    [SerializeField] private Animator _animatorMinigunThree;
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
    private int muzzleBullet = 0;

    private float _lastTimeFire;
    public UnityEvent OnMinigunShoot;
    // public UnityEvent OnSoundShoot;

    private void Awake()
    {
        _weaponUI = FindObjectOfType<AmmoAndWeaponUI>();
        _reloadButton = FindObjectOfType<ReloadButton>();
        _fireButton = FindObjectOfType<FireButton>();
        //_timeBetweenShots = SaveManager.instance.timeBetweenShotsMahineGun;
        //_bulletSpeed = SaveManager.instance.bulletSpeedMahineGun;
        //_damage = SaveManager.instance.damageMahineGun;
        //_reloadTime = SaveManager.instance.reloadTimeMahineGun;
        //_magSize = SaveManager.instance.magSizeMahineGun;

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

        OnMinigunShoot.Invoke();
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
        OnMinigunShoot.AddListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
        OnMinigunShoot.Invoke();
        Debug.Log("AddEventWeapon");
    }

    private void OnDisable()
    {
        OnMinigunShoot.RemoveListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
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
            else if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(DelaySound());
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
            else if (_fireButton.isDown == false)
            {
                StartCoroutine(DelaySound());
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
            else if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(DelaySound());
            }
        }
    }

    private IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(0.1f);
        _audioSourceShot.Stop();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        _audioSourceReload.Play();
        Debug.Log("Reload");

        yield return new WaitForSeconds(_reloadTime);

        currentAmmo = _magSize;
        isReloading = false;
        OnMinigunShoot.Invoke();
    }

    private void FireBullet()
    {
        _audioSourceShot.Play();
        _particleFallBullets.Play();

        if (muzzleBullet > 2)
            muzzleBullet = 0;

        if (muzzleBullet == 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset[0].position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
            _animatorMinigunOne.SetTrigger("isShoot");
        }
        else if (muzzleBullet == 1)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset[1].position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
            _animatorMinigunTwo.SetTrigger("isShoot");
        }
        else if (muzzleBullet == 2)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _gunOffset[2].position, transform.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
            _animatorMinigunThree.SetTrigger("isShoot");
        }

        muzzleBullet++;

        currentAmmo--;

        OnMinigunShoot.Invoke();
 
        _animOtdasha.SetTrigger("isOtdasha");
    }
}
