using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class BazzukaType : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _gunOffset;

    [SerializeField] private Animator _animatorBazuka;
    [SerializeField] private Animator _animatorMuzzleBack;
    [SerializeField] private Animator _animOtdasha;

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
    public UnityEvent OnBazukaShoot;

    private void Awake()
    {
        _weaponUI = FindObjectOfType<AmmoAndWeaponUI>();
        _fireButton = FindObjectOfType<FireButton>();

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

        _timeBetweenShots = 3;
        _bulletSpeed = 8f;
        _damage = 50f;
        _reloadTime = 3f;
        _magSize = 1;
    }

    private void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = _magSize;

        OnBazukaShoot.Invoke();
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
        OnBazukaShoot.AddListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
        OnBazukaShoot.Invoke();
        Debug.Log("AddEventWeapon");
    }

    private void OnDisable()
    {
        OnBazukaShoot.RemoveListener(delegate { _weaponUI.UpdateAmmoAndWeapon(_weaponSprite, GetCurrentAmmo, _magSize); });
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
        OnBazukaShoot.Invoke();
    }

    private void FireBullet()
    {
        _audioSourceShot.Play();

        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);

        currentAmmo--;

        OnBazukaShoot.Invoke();

        _animatorBazuka.SetTrigger("isShoot");
        _animatorMuzzleBack.SetTrigger("isShoot");
        _animOtdasha.SetTrigger("isOtdasha");
    }
}
