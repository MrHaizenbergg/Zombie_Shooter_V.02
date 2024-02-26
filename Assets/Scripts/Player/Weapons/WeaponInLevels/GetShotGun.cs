using UnityEngine;
using UnityEngine.Events;

public class GetShotGun : MonoBehaviour
{
    private SkinWeaponPlayer _skinWeaponPlayer;
    private WeaponShotGun _weaponShotGun;
    [SerializeField] private GameObject _shotGun;

    public UnityEvent getShotgun;

    private void Start()
    {
        _skinWeaponPlayer = FindObjectOfType<SkinWeaponPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _skinWeaponPlayer.SpawnShotGun();
            getShotgun.Invoke();
            Destroy(gameObject);
        }
    }
}
