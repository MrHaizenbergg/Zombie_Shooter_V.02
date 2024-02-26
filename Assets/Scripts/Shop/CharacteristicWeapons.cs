using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacteristicWeapons : MonoBehaviour
{
    [SerializeField] private Text _timeBetweenShots;
    [SerializeField] private Text _bulletSpeed;
    [SerializeField] private Text _damage;
    [SerializeField] private Text _reloadTime;
    [SerializeField] private Text _magSize;

    [SerializeField] private Button _timBetweenShotsUpgrade;
    [SerializeField] private Button _bulletSpeedUpgrade;
    [SerializeField] private Button _damageUpgrade;
    [SerializeField] private Button _reloadTimeUpgrade;
    [SerializeField] private Button _magSizeUpgrade;

    [SerializeField] private List<GameObject> _weapons;

    public int _timeBetweenShotPrice;
    public int _damageUpgradePrice;
    public int _bulletSpeedPrice;
    public int _reloadTimePrice;
    public int _magSizePrice;

    private int _currentWeapon;

    public void ShowInfoAboutWeapon(int currentWeapon)
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            InfoCharacteristicPlayers(currentWeapon);
            _currentWeapon = currentWeapon;
        }
    }

    private void Update()
    {
        if (_timBetweenShotsUpgrade.gameObject.activeInHierarchy)
        {
            _timBetweenShotsUpgrade.interactable = SaveManager.instance.money >= _timeBetweenShotPrice && SaveManager.instance.weaponUnlocked[_currentWeapon]
                && SaveManager.instance.timeBetweenShotCloseUpgrade[_currentWeapon];
        }
        if (_bulletSpeedUpgrade.gameObject.activeInHierarchy)
        {
            _bulletSpeedUpgrade.interactable = SaveManager.instance.money >= _bulletSpeedPrice && SaveManager.instance.weaponUnlocked[_currentWeapon]
                && SaveManager.instance.bulletSpeedCloseUpgrade[_currentWeapon];
        }
        if (_damageUpgrade.gameObject.activeInHierarchy)
        {
            _damageUpgrade.interactable = SaveManager.instance.money >= _damageUpgradePrice && SaveManager.instance.weaponUnlocked[_currentWeapon]
                && SaveManager.instance.damageCloseUpgrade[_currentWeapon];
        }
        if (_reloadTimeUpgrade.gameObject.activeInHierarchy)
        {
            _reloadTimeUpgrade.interactable = SaveManager.instance.money >= _reloadTimePrice && SaveManager.instance.weaponUnlocked[_currentWeapon]
                && SaveManager.instance.reloadTimeCloseUpgrade[_currentWeapon];
        }
        if (_magSizeUpgrade.gameObject.activeInHierarchy)
        {
            _magSizeUpgrade.interactable = SaveManager.instance.money >= _magSizePrice && SaveManager.instance.weaponUnlocked[_currentWeapon]
                && SaveManager.instance.magSizeCloseUpgrade[_currentWeapon];
        }
    }

    public void UpgradeMagSize(int currentWeapon)
    {
        if (currentWeapon == 0)
        {
            if (SaveManager.instance.magSizePistol < 16)
            {
                SaveManager.instance.money -= _magSizePrice;
                SaveManager.instance.magSizePistol += 1;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.magSizePistol);
                InfoCharacteristicPlayers(0);
            }
            else
            {
                SaveManager.instance.magSizeCloseUpgrade[0] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Обоймы Пистолета");
            }
        }
        if (currentWeapon == 1)
        {
            if (SaveManager.instance.magSizeShotGun < 6)
            {
                SaveManager.instance.money -= _magSizePrice;
                SaveManager.instance.magSizeShotGun += 1;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.magSizeShotGun);
                InfoCharacteristicPlayers(1);
            }
            else
            {
                SaveManager.instance.magSizeCloseUpgrade[1] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Патронаша Дробовика");
            }
        }
        if (currentWeapon == 2)
        {
            if (SaveManager.instance.magSizeAKA < 38)
            {
                SaveManager.instance.money -= _magSizePrice;
                SaveManager.instance.magSizeAKA += 1;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.magSizeShotGun);
                InfoCharacteristicPlayers(2);
            }
            else
            {
                SaveManager.instance.magSizeCloseUpgrade[2] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Обоймы Автомата");
            }
        }
        if (currentWeapon == 3)
        {
            if (SaveManager.instance.magSizeMahineGun < 155)
            {
                SaveManager.instance.money -= _magSizePrice;
                SaveManager.instance.magSizeMahineGun += 1;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.magSizeMahineGun);
                InfoCharacteristicPlayers(3);
            }
            else
            {
                SaveManager.instance.magSizeCloseUpgrade[3] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Обоймы Пулемета");
            }
        }
        if (currentWeapon == 4)
        {
            if (SaveManager.instance.magSizeSniperRiffle < 13)
            {
                SaveManager.instance.money -= _magSizePrice;
                SaveManager.instance.magSizeSniperRiffle += 1;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.magSizeSniperRiffle);
                InfoCharacteristicPlayers(4);
            }
            else
            {
                SaveManager.instance.magSizeCloseUpgrade[4] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Обоймы Снайперки");
            }
        }
    }

    public void UpgradeReloadTime(int currentWeapon)
    {
        if (currentWeapon == 0)
        {
            if (SaveManager.instance.reloadTimePistol > 1.5f)
            {
                SaveManager.instance.money -= _reloadTimePrice;
                SaveManager.instance.reloadTimePistol -= 0.2f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.reloadTimePistol);
                InfoCharacteristicPlayers(0);
            }
            else
            {
                SaveManager.instance.reloadTimeCloseUpgrade[0] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Перезарядки Пистолета");
            }
        }
        if (currentWeapon == 1)
        {
            if (SaveManager.instance.reloadTimeShotGun > 1.5f)
            {
                SaveManager.instance.money -= _reloadTimePrice;
                SaveManager.instance.reloadTimeShotGun -= 0.2f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.reloadTimeShotGun);
                InfoCharacteristicPlayers(1);
            }
            else
            {
                SaveManager.instance.reloadTimeCloseUpgrade[1] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Перезарядки Дробовика");
            }
        }
        if (currentWeapon == 2)
        {
            if (SaveManager.instance.reloadTimeAKA > 1.2f)
            {
                SaveManager.instance.money -= _reloadTimePrice;
                SaveManager.instance.reloadTimeAKA -= 0.2f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.reloadTimeAKA);
                InfoCharacteristicPlayers(2);
            }
            else
            {
                SaveManager.instance.reloadTimeCloseUpgrade[2] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Перезарядки Автомата");
            }
        }
        if (currentWeapon == 3)
        {
            if (SaveManager.instance.reloadTimeMahineGun > 5f)
            {
                SaveManager.instance.money -= _reloadTimePrice;
                SaveManager.instance.reloadTimeMahineGun -= 0.2f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.reloadTimeMahineGun);
                InfoCharacteristicPlayers(3);
            }
            else
            {
                SaveManager.instance.reloadTimeCloseUpgrade[3] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Перезарядки Пулемета");
            }
        }
        if (currentWeapon == 4)
        {
            if (SaveManager.instance.reloadTimeSniperRiffle > 2.5f)
            {
                SaveManager.instance.money -= _reloadTimePrice;
                SaveManager.instance.reloadTimeSniperRiffle -= 0.2f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.reloadTimeSniperRiffle);
                InfoCharacteristicPlayers(4);
            }
            else
            {
                SaveManager.instance.reloadTimeCloseUpgrade[4] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Перезарядки Снайперки");
            }
        }
    }

    public void UpgradeDamage(int currentWeapon)
    {
        if (currentWeapon == 0)
        {
            if (SaveManager.instance.damagePistol < 10f)
            {
                SaveManager.instance.money -= _damageUpgradePrice;
                SaveManager.instance.damagePistol += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.damagePistol);
                InfoCharacteristicPlayers(0);
            }
            else
            {
                SaveManager.instance.damageCloseUpgrade[0] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Урона Пистолета");
            }
        }
        if (currentWeapon == 1)
        {
            if (SaveManager.instance.damageShotGun < 13f)
            {
                SaveManager.instance.money -= _damageUpgradePrice;
                SaveManager.instance.damageShotGun += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.damageShotGun);
                InfoCharacteristicPlayers(1);
            }
            else
            {
                SaveManager.instance.damageCloseUpgrade[1] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Урона Дробовика");
            }
        }
        if (currentWeapon == 2)
        {
            if (SaveManager.instance.damageAKA < 17f)
            {
                SaveManager.instance.money -= _damageUpgradePrice;
                SaveManager.instance.damageAKA += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.damageAKA);
                InfoCharacteristicPlayers(2);
            }
            else
            {
                SaveManager.instance.damageCloseUpgrade[2] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Урона Автомата");
            }
        }
        if (currentWeapon == 3)
        {
            if (SaveManager.instance.damageMahineGun < 18f)
            {
                SaveManager.instance.money -= _damageUpgradePrice;
                SaveManager.instance.damageMahineGun += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.damageMahineGun);
                InfoCharacteristicPlayers(3);
            }
            else
            {
                SaveManager.instance.damageCloseUpgrade[3] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Урона Пулемета");
            }
        }
        if (currentWeapon == 4)
        {
            if (SaveManager.instance.damageSniperRiffle < 50f)
            {
                SaveManager.instance.money -= _damageUpgradePrice;
                SaveManager.instance.damageSniperRiffle += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.damageSniperRiffle);
                InfoCharacteristicPlayers(4);
            }
            else
            {
                SaveManager.instance.damageCloseUpgrade[4] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Урона Снайперки");
            }
        }
    }

    public void UpgradeBulletSpeed(int currentWeapon)
    {
        if (currentWeapon == 0)
        {
            if (SaveManager.instance.bulletSpeedPistol < 28f)
            {
                SaveManager.instance.money -= _bulletSpeedPrice;
                SaveManager.instance.bulletSpeedPistol += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.bulletSpeedPistol);
                InfoCharacteristicPlayers(0);
            }
            else
            {
                SaveManager.instance.bulletSpeedCloseUpgrade[0] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорости пули Пистолета");
            }
        }
        if (currentWeapon == 1)
        {
            if (SaveManager.instance.bulletSpeedShotGun < 26f)
            {
                SaveManager.instance.money -= _bulletSpeedPrice;
                SaveManager.instance.bulletSpeedShotGun += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.bulletSpeedShotGun);
                InfoCharacteristicPlayers(1);
            }
            else
            {
                SaveManager.instance.bulletSpeedCloseUpgrade[1] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорости дроби Дробовика");
            }
        }
        if (currentWeapon == 2)
        {
            if (SaveManager.instance.bulletSpeedAKA < 32f)
            {
                SaveManager.instance.money -= _bulletSpeedPrice;
                SaveManager.instance.bulletSpeedAKA += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.bulletSpeedAKA);
                InfoCharacteristicPlayers(2);
            }
            else
            {
                SaveManager.instance.bulletSpeedCloseUpgrade[2] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорострельности Автомата");
            }
        }
        if (currentWeapon == 3)
        {
            if (SaveManager.instance.bulletSpeedMahineGun < 34f)
            {
                SaveManager.instance.money -= _bulletSpeedPrice;
                SaveManager.instance.bulletSpeedMahineGun += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.bulletSpeedMahineGun);
                InfoCharacteristicPlayers(3);
            }
            else
            {
                SaveManager.instance.bulletSpeedCloseUpgrade[3] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорости пули Пулемета");
            }
        }
        if (currentWeapon == 4)
        {
            if (SaveManager.instance.bulletSpeedSniperRiffle < 38f)
            {
                SaveManager.instance.money -= _bulletSpeedPrice;
                SaveManager.instance.bulletSpeedSniperRiffle += 1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.bulletSpeedSniperRiffle);
                InfoCharacteristicPlayers(4);
            }
            else
            {
                SaveManager.instance.bulletSpeedCloseUpgrade[4] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорости пули Снайперки");
            }
        }
    }

    public void UpgradeTimeBetweenShots(int currentWeapon)
    {
        if (currentWeapon == 0)
        {
            if (SaveManager.instance.timeBetweenShotsPistol >= 0.3f)
            {
                SaveManager.instance.money -= _timeBetweenShotPrice;
                SaveManager.instance.timeBetweenShotsPistol -= 0.1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.timeBetweenShotsPistol);
                InfoCharacteristicPlayers(0);
            }
            else
            {
                SaveManager.instance.timeBetweenShotCloseUpgrade[0] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорострельности Пистолета");
            }
        }
        if (currentWeapon == 1)
        {
            if (SaveManager.instance.timeBetweenShotsShotGun >= 0.5f)
            {
                SaveManager.instance.money -= _timeBetweenShotPrice;
                SaveManager.instance.timeBetweenShotsShotGun -= 0.1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.timeBetweenShotsShotGun);
                InfoCharacteristicPlayers(1);
            }
            else
            {
                SaveManager.instance.timeBetweenShotCloseUpgrade[1] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорострельности Дробовика");
            }
        }
        if (currentWeapon == 2)
        {
            if (SaveManager.instance.timeBetweenShotsAKA >= 0.3f)
            {
                SaveManager.instance.money -= _timeBetweenShotPrice;
                SaveManager.instance.timeBetweenShotsAKA -= 0.1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.timeBetweenShotsAKA);
                InfoCharacteristicPlayers(2);
            }
            else
            {
                SaveManager.instance.timeBetweenShotCloseUpgrade[2] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорострельности Автомата");
            }
        }
        if (currentWeapon == 3)
        {
            if (SaveManager.instance.timeBetweenShotsMahineGun >= 0.2f)
            {
                SaveManager.instance.money -= _timeBetweenShotPrice;
                SaveManager.instance.timeBetweenShotsMahineGun -= 0.1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.timeBetweenShotsMahineGun);
                InfoCharacteristicPlayers(3);
            }
            else
            {
                SaveManager.instance.timeBetweenShotCloseUpgrade[3] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорострельности Пулемета");
            }
        }
        if (currentWeapon == 4)
        {
            if (SaveManager.instance.timeBetweenShotsSniperRiffle > 0.1f)
            {
                SaveManager.instance.money -= _timeBetweenShotPrice;
                SaveManager.instance.timeBetweenShotsSniperRiffle -= 0.1f;
                SaveManager.instance.Save();
                Debug.Log("Текущее Улучшение " + SaveManager.instance.timeBetweenShotsSniperRiffle);
                InfoCharacteristicPlayers(4);
            }
            else
            {
                SaveManager.instance.timeBetweenShotCloseUpgrade[4] = false;
                SaveManager.instance.Save();
                Debug.Log("Предел Улучшения Скорострельности Снайперки");
            }
        }
    }

    private void InfoCharacteristicPlayers(int info)
    {
        if (info == 0)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();
            _timBetweenShotsUpgrade.onClick.AddListener(delegate { UpgradeTimeBetweenShots(info); });
            _bulletSpeedUpgrade.onClick.AddListener(delegate { UpgradeBulletSpeed(info); });
            _damageUpgrade.onClick.AddListener(delegate { UpgradeDamage(info); });
            _reloadTimeUpgrade.onClick.AddListener(delegate { UpgradeReloadTime(info); });
            _magSizeUpgrade.onClick.AddListener(delegate { UpgradeMagSize(info); });

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsPistol.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedPistol.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damagePistol;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimePistol.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizePistol;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text ="Скорость стрельбы: " + SaveManager.instance.timeBetweenShotsPistol.ToString("0.0");
                _bulletSpeed.text ="Скорость пули: " + SaveManager.instance.bulletSpeedPistol.ToString();
                _damage.text = "Урон оружия: " + SaveManager.instance.damagePistol;
                _reloadTime.text = "Время Перезарядки: " + SaveManager.instance.reloadTimePistol.ToString("0.0");
                _magSize.text = "Размер обоймы: " + SaveManager.instance.magSizePistol;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsPistol.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedPistol.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damagePistol;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimePistol.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizePistol;
            }

        }
        else if (info == 1)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();
            _timBetweenShotsUpgrade.onClick.AddListener(delegate { UpgradeTimeBetweenShots(info); });
            _bulletSpeedUpgrade.onClick.AddListener(delegate { UpgradeBulletSpeed(info); });
            _damageUpgrade.onClick.AddListener(delegate { UpgradeDamage(info); });
            _reloadTimeUpgrade.onClick.AddListener(delegate { UpgradeReloadTime(info); });
            _magSizeUpgrade.onClick.AddListener(delegate { UpgradeMagSize(info); });

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsShotGun.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedShotGun.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageShotGun;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeShotGun.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeShotGun;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text = "Скорость стрельбы: " + SaveManager.instance.timeBetweenShotsShotGun.ToString("0.0");
                _bulletSpeed.text = "Скорость пули: " + SaveManager.instance.bulletSpeedShotGun;
                _damage.text = "Урон оружия: " + SaveManager.instance.damageShotGun;
                _reloadTime.text = "Время Перезарядки: " + SaveManager.instance.reloadTimeShotGun.ToString("0.0");
                _magSize.text = "Размер обоймы: " + SaveManager.instance.magSizeShotGun;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsShotGun.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedShotGun.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageShotGun;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeShotGun.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeShotGun;
            }

           
        }
        else if (info == 2)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();
            _timBetweenShotsUpgrade.onClick.AddListener(delegate { UpgradeTimeBetweenShots(info); });
            _bulletSpeedUpgrade.onClick.AddListener(delegate { UpgradeBulletSpeed(info); });
            _damageUpgrade.onClick.AddListener(delegate { UpgradeDamage(info); });
            _reloadTimeUpgrade.onClick.AddListener(delegate { UpgradeReloadTime(info); });
            _magSizeUpgrade.onClick.AddListener(delegate { UpgradeMagSize(info); });

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsAKA.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedAKA.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageAKA;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeAKA.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeAKA;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text = "Скорость стрельбы: " + SaveManager.instance.timeBetweenShotsAKA.ToString("0.0");
                _bulletSpeed.text = "Скорость пули: " + SaveManager.instance.bulletSpeedAKA;
                _damage.text = "Урон оружия: " + SaveManager.instance.damageAKA;
                _reloadTime.text = "Время Перезарядки: " + SaveManager.instance.reloadTimeAKA.ToString("0.0");
                _magSize.text = "Размер обоймы: " + SaveManager.instance.magSizeAKA;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsAKA.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedAKA.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageAKA;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeAKA.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeAKA;
            }
        }
        else if (info == 3)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();
            _timBetweenShotsUpgrade.onClick.AddListener(delegate { UpgradeTimeBetweenShots(info); });
            _bulletSpeedUpgrade.onClick.AddListener(delegate { UpgradeBulletSpeed(info); });
            _damageUpgrade.onClick.AddListener(delegate { UpgradeDamage(info); });
            _reloadTimeUpgrade.onClick.AddListener(delegate { UpgradeReloadTime(info); });
            _magSizeUpgrade.onClick.AddListener(delegate { UpgradeMagSize(info); });

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsMahineGun.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedMahineGun.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageMahineGun;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeMahineGun.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeMahineGun;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text = "Скорость стрельбы: " + SaveManager.instance.timeBetweenShotsMahineGun.ToString("0.0");
                _bulletSpeed.text = "Скорость пули: " + SaveManager.instance.bulletSpeedMahineGun;
                _damage.text = "Урон оружия: " + SaveManager.instance.damageMahineGun;
                _reloadTime.text = "Время Перезарядки: " + SaveManager.instance.reloadTimeMahineGun.ToString("0.0");
                _magSize.text = "Размер обоймы: " + SaveManager.instance.magSizeMahineGun;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsMahineGun.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedMahineGun.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageMahineGun;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeMahineGun.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeMahineGun;
            }
        }
        else if (info == 4)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();
            _timBetweenShotsUpgrade.onClick.AddListener(delegate { UpgradeTimeBetweenShots(info); });
            _bulletSpeedUpgrade.onClick.AddListener(delegate { UpgradeBulletSpeed(info); });
            _damageUpgrade.onClick.AddListener(delegate { UpgradeDamage(info); });
            _reloadTimeUpgrade.onClick.AddListener(delegate { UpgradeReloadTime(info); });
            _magSizeUpgrade.onClick.AddListener(delegate { UpgradeMagSize(info); });

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsSniperRiffle.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedSniperRiffle.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageSniperRiffle;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeSniperRiffle.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeSniperRiffle;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text = "Скорость стрельбы: " + SaveManager.instance.timeBetweenShotsSniperRiffle.ToString("0.0");
                _bulletSpeed.text = "Скорость пули: " + SaveManager.instance.bulletSpeedSniperRiffle;
                _damage.text = "Урон оружия: " + SaveManager.instance.damageSniperRiffle;
                _reloadTime.text = "Время Перезарядки: " + SaveManager.instance.reloadTimeSniperRiffle.ToString("0.0");
                _magSize.text = "Размер обоймы: " + SaveManager.instance.magSizeSniperRiffle;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + SaveManager.instance.timeBetweenShotsSniperRiffle.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + SaveManager.instance.bulletSpeedSniperRiffle.ToString();
                _damage.text = "Weapon Damage: " + SaveManager.instance.damageSniperRiffle;
                _reloadTime.text = "Recharge time:  " + SaveManager.instance.reloadTimeSniperRiffle.ToString("0.0");
                _magSize.text = "Magazine size: " + SaveManager.instance.magSizeSniperRiffle;
            }
        }
        else if (info == 5)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + 3f.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + 8f;
                _damage.text = "Weapon Damage: " + 50f;
                _reloadTime.text = "Recharge time:  " + 3f;
                _magSize.text = "Magazine size: " + 1;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text = "Скорость стрельбы: " + 3f.ToString("0.0");
                _bulletSpeed.text = "Скорость пули: " + 8f;
                _damage.text = "Урон оружия: " + 50f;
                _reloadTime.text = "Время Перезарядки: " + 3f;
                _magSize.text = "Размер обоймы: " + 1;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + 3f.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + 8f;
                _damage.text = "Weapon Damage: " + 50f;
                _reloadTime.text = "Recharge time:  " + 3f;
                _magSize.text = "Magazine size: " + 1;
            }

           
        }
        else if (info == 6)
        {
            _timBetweenShotsUpgrade.onClick.RemoveAllListeners();
            _bulletSpeedUpgrade.onClick.RemoveAllListeners();
            _damageUpgrade.onClick.RemoveAllListeners();
            _reloadTimeUpgrade.onClick.RemoveAllListeners();
            _magSizeUpgrade.onClick.RemoveAllListeners();

            if (Language.Instance.currentLanguage == "en")
            {
                _timeBetweenShots.text = "Rate of fire: " + 0.15f.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + 25f;
                _damage.text = "Weapon Damage: " + 6f;
                _reloadTime.text = "Recharge time:  " + 7f;
                _magSize.text = "Magazine size: " + 160;
            }
            else if (Language.Instance.currentLanguage == "ru")
            {
                _timeBetweenShots.text = "Скорость стрельбы: " + 0.15f.ToString("0.0");
                _bulletSpeed.text = "Скорость пули: " + 25f;
                _damage.text = "Урон оружия: " + 6f;
                _reloadTime.text = "Время Перезарядки: " + 7f;
                _magSize.text = "Размер обоймы: " + 160;
            }
            else
            {
                _timeBetweenShots.text = "Rate of fire: " + 0.15f.ToString("0.0");
                _bulletSpeed.text = "Bullet speed: " + 25f;
                _damage.text = "Weapon Damage: " + 6f;
                _reloadTime.text = "Recharge time:  " + 7f;
                _magSize.text = "Magazine size: " + 160;
            }    
        }
    }
}