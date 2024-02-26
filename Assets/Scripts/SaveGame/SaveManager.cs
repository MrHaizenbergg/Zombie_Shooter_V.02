using Newtonsoft.Json;
using System;
using UnityEngine;
using YG;

[Serializable]
class PlayerData
{
    public int killedZombies;
    public int amountGrenade;
    public int currentSkin;
    public int currentLevel;
    public int currentWeapon;
    public int currentWeaponTwo;
    public int money;

    public bool[] weaponUnlocked;
    public bool[] skinsUnlocked;

    public float elapsedTimeFirstLevel;
    public float elapsedTimeSecondLevel;
    public float elapsedTimeThirdLevel;

    public bool[] timeBetweenShotCloseUpgrade;
    public bool[] bulletSpeedCloseUpgrade;
    public bool[] damageCloseUpgrade;
    public bool[] reloadTimeCloseUpgrade;
    public bool[] magSizeCloseUpgrade;

    public float timeBetweenShotsPistol;
    public float bulletSpeedPistol;
    public float damagePistol;
    public float reloadTimePistol;
    public int magSizePistol;

    public float timeBetweenShotsShotGun;
    public float bulletSpeedShotGun;
    public float damageShotGun;
    public float reloadTimeShotGun;
    public int magSizeShotGun;

    public float timeBetweenShotsAKA;
    public float bulletSpeedAKA;
    public float damageAKA;
    public float reloadTimeAKA;
    public int magSizeAKA;

    public float timeBetweenShotsMahineGun;
    public float bulletSpeedMahineGun;
    public float damageMahineGun;
    public float reloadTimeMahineGun;
    public int magSizeMahineGun;

    public float timeBetweenShotsSniperRiffle;
    public float bulletSpeedSniperRiffle;
    public float damageSniperRiffle;
    public float reloadTimeSniperRiffle;
    public int magSizeSniperRiffle;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    public int currentLevel = 1;

    public int killedZombies;
    public int amountGrenade = 1;
    public int currentSkin;
    public int currentWeapon;
    public int currentWeaponTwo;
    public int money;
    public bool[] weaponUnlocked = new bool[7] { true, false, false, false, false, false, false };
    public bool[] skinsUnlocked = new bool[10] { true, false, false, false, false, false, false, false, false, false };

    public float elapsedTimeFirstLevel = 0;
    public float elapsedTimeSecondLevel = 0;
    public float elapsedTimeThirdLevel = 0;

    public bool[] timeBetweenShotCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
    public bool[] bulletSpeedCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
    public bool[] damageCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
    public bool[] reloadTimeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
    public bool[] magSizeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };

    public float timeBetweenShotsPistol;
    public float bulletSpeedPistol;
    public float damagePistol;
    public float reloadTimePistol;
    public int magSizePistol;

    public float timeBetweenShotsShotGun;
    public float bulletSpeedShotGun;
    public float damageShotGun;
    public float reloadTimeShotGun;
    public int magSizeShotGun;

    public float timeBetweenShotsAKA;
    public float bulletSpeedAKA;
    public float damageAKA;
    public float reloadTimeAKA;
    public int magSizeAKA;

    public float timeBetweenShotsMahineGun;
    public float bulletSpeedMahineGun;
    public float damageMahineGun;
    public float reloadTimeMahineGun;
    public int magSizeMahineGun;

    public float timeBetweenShotsSniperRiffle;
    public float bulletSpeedSniperRiffle;
    public float damageSniperRiffle;
    public float reloadTimeSniperRiffle;
    public int magSizeSniperRiffle;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //SavePath = Application.streamingAssetsPath + "/player-stats.json";
        //Debug.Log("SavePathAwake" + Application.streamingAssetsPath + "/player-stats.json");
        Debug.Log("Money" + money);
        Debug.Log("MoneyAfterLoad" + money);
    }

    private void OnEnable() => YandexGame.GetDataEvent += Load;
    private void OnDisable() => YandexGame.GetDataEvent -= Load;

    private void SetDefaultWeaponSettings()
    {
        timeBetweenShotsPistol = 1.5f;
        bulletSpeedPistol = 19f;
        damagePistol = 4f;
        reloadTimePistol = 4f;
        magSizePistol = 6;

        timeBetweenShotsShotGun = 1.2f;
        bulletSpeedShotGun = 15f;
        damageShotGun = 5f;
        reloadTimeShotGun = 4f;
        magSizeShotGun = 2;

        timeBetweenShotsAKA = 0.6f;
        bulletSpeedAKA = 21f;
        damageAKA = 6f;
        reloadTimeAKA = 5f;
        magSizeAKA = 24;

        timeBetweenShotsMahineGun = 0.5f;
        bulletSpeedMahineGun = 19f;
        damageMahineGun = 5f;
        reloadTimeMahineGun = 10f;
        magSizeMahineGun = 55;

        timeBetweenShotsSniperRiffle = 3.3f;
        bulletSpeedSniperRiffle = 23f;
        damageSniperRiffle = 25f;
        reloadTimeSniperRiffle = 7f;
        magSizeSniperRiffle = 7;
    }

    public void Load()
    {
        if (YandexGame.savesData.jsonSaves == "")
        {
            Debug.Log("SaveDataNull");
            return;
        }

        try
        {
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(YandexGame.savesData.jsonSaves);

            Debug.Log("JsonAfterLoad" + JsonConvert.DeserializeObject<PlayerData>(YandexGame.savesData.jsonSaves));
            //if (!File.Exists(SavePath))
            //{
            //    Debug.LogError($"Cannot load file at {SavePath}. File does not exist!");
            //    throw new FileNotFoundException($"{SavePath} does not exist!");
            //}

            //PlayerData data = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(SavePath));

            //Debug.Log("dataLoad: " + JsonConvert.SerializeObject(data));

            killedZombies = data.killedZombies;
            amountGrenade = data.amountGrenade;
            currentLevel = data.currentLevel;
            money = data.money;
            currentSkin = data.currentSkin;
            currentWeapon = data.currentWeapon;
            currentWeaponTwo = data.currentWeaponTwo;
            weaponUnlocked = data.weaponUnlocked;
            skinsUnlocked = data.skinsUnlocked;

            elapsedTimeFirstLevel = data.elapsedTimeFirstLevel;
            elapsedTimeSecondLevel = data.elapsedTimeSecondLevel;
            elapsedTimeThirdLevel = data.elapsedTimeThirdLevel;

            timeBetweenShotsPistol = data.timeBetweenShotsPistol;
            bulletSpeedPistol = data.bulletSpeedPistol;
            damagePistol = data.damagePistol;
            reloadTimePistol = data.reloadTimePistol;
            magSizePistol = data.magSizePistol;

            timeBetweenShotsShotGun = data.timeBetweenShotsShotGun;
            bulletSpeedShotGun = data.bulletSpeedShotGun;
            damageShotGun = data.damageShotGun;
            reloadTimeShotGun = data.reloadTimeShotGun;
            magSizeShotGun = data.magSizeShotGun;

            timeBetweenShotsAKA = data.timeBetweenShotsAKA;
            bulletSpeedAKA = data.bulletSpeedAKA;
            damageAKA = data.damageAKA;
            reloadTimeAKA = data.reloadTimeAKA;
            magSizeAKA = data.magSizeAKA;

            timeBetweenShotsMahineGun = data.timeBetweenShotsMahineGun;
            bulletSpeedMahineGun = data.bulletSpeedMahineGun;
            damageMahineGun = data.damageMahineGun;
            reloadTimeMahineGun = data.reloadTimeMahineGun;
            magSizeMahineGun = data.magSizeMahineGun;

            timeBetweenShotsSniperRiffle = data.timeBetweenShotsSniperRiffle;
            bulletSpeedSniperRiffle = data.bulletSpeedSniperRiffle;
            damageSniperRiffle = data.damageSniperRiffle;
            reloadTimeSniperRiffle = data.reloadTimeSniperRiffle;
            magSizeSniperRiffle = data.magSizeSniperRiffle;

            timeBetweenShotCloseUpgrade = data.timeBetweenShotCloseUpgrade;
            bulletSpeedCloseUpgrade = data.bulletSpeedCloseUpgrade;
            damageCloseUpgrade = data.damageCloseUpgrade;
            reloadTimeCloseUpgrade = data.reloadTimeCloseUpgrade;
            magSizeCloseUpgrade = data.magSizeCloseUpgrade;

            if (data.weaponUnlocked == null)
                weaponUnlocked = new bool[7] { true, false, false, false, false, false, false };
            if (data.skinsUnlocked == null)
                skinsUnlocked = new bool[10] { true, false, false, false, false, false, false, false, false, false };

            if (data.timeBetweenShotCloseUpgrade == null)
                timeBetweenShotCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
            if (data.bulletSpeedCloseUpgrade == null)
                bulletSpeedCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
            if (data.damageCloseUpgrade == null)
                damageCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
            if (data.reloadTimeCloseUpgrade == null)
                reloadTimeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
            if (data.magSizeCloseUpgrade == null)
                magSizeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
            if (data.currentLevel == 0)
                currentLevel = 1;
            if (data.amountGrenade == 0)
            {
                data.amountGrenade = 1;
                amountGrenade = 1;
            }

            if (timeBetweenShotsPistol == 0)
            {
                SetDefaultWeaponSettings();
            }

            Debug.Log("ElapsedTime: " + data.elapsedTimeFirstLevel);
            Debug.Log("ElapsedTime: " + data.elapsedTimeSecondLevel);
            Debug.Log("ElapsedTime: " + data.elapsedTimeThirdLevel);

            Debug.Log("Money: " + data.money);
            Debug.Log(data.currentSkin);
            Debug.Log(data.weaponUnlocked);
            Debug.Log("AfterLoad" + JsonConvert.SerializeObject(data));
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
            throw e;
        }
    }

    public void ClearData()
    {
        PlayerData data = new PlayerData();

        elapsedTimeFirstLevel = 0;
        elapsedTimeSecondLevel = 0;
        elapsedTimeThirdLevel = 0;

        killedZombies = 0;
        amountGrenade = 1;
        currentLevel = 1;
        currentSkin = 0;
        currentWeapon = 0;
        currentWeaponTwo = 0;
        money = 0;
        weaponUnlocked = new bool[7] { true, false, false, false, false, false, false };
        skinsUnlocked = new bool[10] { true, false, false, false, false, false, false, false, false, false };

        timeBetweenShotCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        bulletSpeedCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        damageCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        reloadTimeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        magSizeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };

        SetDefaultWeaponSettings();

        data.timeBetweenShotsPistol = 1.5f;
        data.bulletSpeedPistol = 19f;
        data.damagePistol = 4f;
        data.reloadTimePistol = 4f;
        data.magSizePistol = 6;

        data.timeBetweenShotsShotGun = 1.2f;
        data.bulletSpeedShotGun = 17f;
        data.damageShotGun = 5f;
        data.reloadTimeShotGun = 4f;
        data.magSizeShotGun = 2;

        data.timeBetweenShotsAKA = 0.8f;
        data.bulletSpeedAKA = 21f;
        data.damageAKA = 6f;
        data.reloadTimeAKA = 5f;
        data.magSizeAKA = 24;

        data.timeBetweenShotsMahineGun = 0.7f;
        data.bulletSpeedMahineGun = 19f;
        data.damageMahineGun = 5f;
        data.reloadTimeMahineGun = 10f;
        data.magSizeMahineGun = 55;

        data.timeBetweenShotsSniperRiffle = 3.3f;
        data.bulletSpeedSniperRiffle = 23f;
        data.damageSniperRiffle = 15f;
        data.reloadTimeSniperRiffle = 7f;
        data.magSizeSniperRiffle = 7;

        data.killedZombies = 0;
        data.amountGrenade = 1;
        data.currentLevel = 1;
        data.currentSkin = 0;
        data.currentWeapon = 0;
        data.currentWeaponTwo = 0;
        data.money = 0;
        data.weaponUnlocked = new bool[7] { true, false, false, false, false, false, false };
        data.skinsUnlocked = new bool[10] { true, false, false, false, false, false, false, false, false, false };

        data.elapsedTimeFirstLevel = 0;
        data.elapsedTimeSecondLevel = 0;
        data.elapsedTimeThirdLevel = 0;

        data.timeBetweenShotCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        data.bulletSpeedCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        data.damageCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        data.reloadTimeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };
        data.magSizeCloseUpgrade = new bool[7] { true, true, true, true, true, false, false };

        YandexGame.savesData.jsonSaves = JsonConvert.SerializeObject(data);
        YandexGame.SaveProgress();
    }

    public void Save()
    {
        PlayerData data = new PlayerData();

        Debug.Log("Save");
        Debug.Log(money);
        Debug.Log("CurrentSkim: " + currentSkin);
        Debug.Log(weaponUnlocked);
        Debug.Log(currentLevel);
        Debug.Log(amountGrenade);

        Debug.Log("ElapsedTime: " + elapsedTimeFirstLevel);
        Debug.Log("ElapsedTime: " + elapsedTimeSecondLevel);
        Debug.Log("ElapsedTime: " + elapsedTimeThirdLevel);

        data.killedZombies = killedZombies;
        data.amountGrenade = amountGrenade;
        data.money = money;
        data.currentWeapon = currentWeapon;
        data.currentWeaponTwo = currentWeaponTwo;
        data.currentSkin = currentSkin;
        data.weaponUnlocked = weaponUnlocked;
        data.skinsUnlocked = skinsUnlocked;
        data.currentLevel = currentLevel;

        data.elapsedTimeFirstLevel = elapsedTimeFirstLevel;
        data.elapsedTimeSecondLevel = elapsedTimeSecondLevel;
        data.elapsedTimeThirdLevel = elapsedTimeThirdLevel;

        data.timeBetweenShotsPistol = timeBetweenShotsPistol;
        data.bulletSpeedPistol = bulletSpeedPistol;
        data.damagePistol = damagePistol;
        data.reloadTimePistol = reloadTimePistol;
        data.magSizePistol = magSizePistol;

        data.timeBetweenShotsShotGun = timeBetweenShotsShotGun;
        data.bulletSpeedShotGun = bulletSpeedShotGun;
        data.damageShotGun = damageShotGun;
        data.reloadTimeShotGun = reloadTimeShotGun;
        data.magSizeShotGun = magSizeShotGun;

        data.timeBetweenShotsAKA = timeBetweenShotsAKA;
        data.bulletSpeedAKA = bulletSpeedAKA;
        data.damageAKA = damageAKA;
        data.reloadTimeAKA = reloadTimeAKA;
        data.magSizeAKA = magSizeAKA;

        data.timeBetweenShotsMahineGun = timeBetweenShotsMahineGun;
        data.bulletSpeedMahineGun = bulletSpeedMahineGun;
        data.damageMahineGun = damageMahineGun;
        data.reloadTimeMahineGun = reloadTimeMahineGun;
        data.magSizeMahineGun = magSizeMahineGun;

        data.timeBetweenShotsSniperRiffle = timeBetweenShotsSniperRiffle;
        data.bulletSpeedSniperRiffle = bulletSpeedSniperRiffle;
        data.damageSniperRiffle = damageSniperRiffle;
        data.reloadTimeSniperRiffle = reloadTimeSniperRiffle;
        data.magSizeSniperRiffle = magSizeSniperRiffle;

        data.timeBetweenShotCloseUpgrade = timeBetweenShotCloseUpgrade;
        data.bulletSpeedCloseUpgrade = bulletSpeedCloseUpgrade;
        data.damageCloseUpgrade = damageCloseUpgrade;
        data.reloadTimeCloseUpgrade = reloadTimeCloseUpgrade;
        data.magSizeCloseUpgrade = magSizeCloseUpgrade;

        Debug.Log("AfterSave");
        Debug.Log(money);

        try
        {
            //if (File.Exists(SavePath))
            //{
            //    Debug.Log("Data exists, Deleting old file and writing a new one!");
            //    File.Delete(SavePath);
            //}
            //else
            //{
            //    Debug.Log("Wtiting file for the first time");
            //}

            //using FileStream stream = File.Create(SavePath);
            //stream.Close();
            //File.WriteAllText(SavePath, JsonConvert.SerializeObject(data));

            YandexGame.savesData.jsonSaves = JsonConvert.SerializeObject(data);
            YandexGame.SaveProgress();
            Debug.Log(JsonConvert.SerializeObject(data));
            Debug.Log(YandexGame.savesData.jsonSaves);
        }
        catch (Exception e)
        {
            Debug.LogError($"Unable to save data dur to: {e.Message} {e.StackTrace}");
        }
    }
}