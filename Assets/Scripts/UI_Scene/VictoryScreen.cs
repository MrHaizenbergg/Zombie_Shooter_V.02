using UnityEngine;
using YG;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private AmountKillZombies _amountKillZombies;
    [SerializeField] private GameObject _screen;

    [SerializeField] private Timer _timer;

    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int[] _priceRewarded;

    //[DllImport("__Internal")]
    //private static extern void SetToLeaderboard(int value);

    private void Awake()
    {
        _screen.SetActive(false);
        currentLevel = SaveManager.instance.currentLevel;
    }

    public void CallVictoryScreen()
    {
        _amountKillZombies.AmountResourcesEndLevel();
        _amountKillZombies.CurrentTimeEndLevel();

        SaveManager.instance.killedZombies += _amountKillZombies.amountKilledEnemies;
        SaveManager.instance.money += _amountKillZombies.amountOfMoney;

        if (currentLevel == 1)
        {
            SaveManager.instance.money += _priceRewarded[0];
            _amountKillZombies.RewardForHard(_priceRewarded[0]);

            if (SaveManager.instance.elapsedTimeFirstLevel == 0)
            {
                SaveManager.instance.elapsedTimeFirstLevel = _timer._elapsedTime;           
                Debug.Log("ElapsedTime: 0");
            }
            else if (SaveManager.instance.elapsedTimeFirstLevel > _timer._elapsedTime)
            {
                SaveManager.instance.elapsedTimeFirstLevel = _timer._elapsedTime;
                Debug.Log("ElapsedTime More");
            }
        }
        if (currentLevel == 2)
        {
            SaveManager.instance.money += _priceRewarded[1];
            _amountKillZombies.RewardForHard(_priceRewarded[1]);

            if (SaveManager.instance.elapsedTimeSecondLevel == 0)
            {
                SaveManager.instance.elapsedTimeSecondLevel = _timer._elapsedTime;
            }
            else if (SaveManager.instance.elapsedTimeSecondLevel > _timer._elapsedTime)
            {
                SaveManager.instance.elapsedTimeSecondLevel = _timer._elapsedTime;
            }
        }
        if (currentLevel == 3)
        {
            SaveManager.instance.money += _priceRewarded[2];
            _amountKillZombies.RewardForHard(_priceRewarded[2]);

            if (SaveManager.instance.elapsedTimeThirdLevel == 0)
            {
                SaveManager.instance.elapsedTimeThirdLevel = _timer._elapsedTime;
            }
            else if (SaveManager.instance.elapsedTimeThirdLevel > _timer._elapsedTime)
            {
                SaveManager.instance.elapsedTimeThirdLevel = _timer._elapsedTime;
            }
        }

        // SetToLeaderboard(SaveManager.instance.killedZombies);
        YandexGame.NewLeaderboardScores("MutantssKilled", SaveManager.instance.killedZombies);

        SaveManager.instance.Save();

        Debug.Log("KilledOffLevel: " + SaveManager.instance.killedZombies);
        Debug.Log("MoneyForAllLevel: " + SaveManager.instance.killedZombies);
        Debug.Log("TimeEasyLevel: " + SaveManager.instance.elapsedTimeFirstLevel);
        _screen.SetActive(true);
    }
}
