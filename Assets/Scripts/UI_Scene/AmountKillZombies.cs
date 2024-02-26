using UnityEngine;
using UnityEngine.UI;

public class AmountKillZombies : MonoBehaviour
{
    [SerializeField] private Text _amountOfZombieText;
    [SerializeField] private Text _amountOfMoney;
    [SerializeField] private Text _amountOfZombieTextEndLevel;
    [SerializeField] private Text _amountOfMoneyEndLevel;
    [SerializeField] private Text _amountOfZombieTextPlayerDeath;
    [SerializeField] private Text _amountOfMoneyPlayerDeath;
    [SerializeField] private Text _currentTimeLevel;
    [SerializeField] private Text _rewardForHardText;

    private Timer _timer;

    public int amountKilledEnemies;
    public int amountOfMoney;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    public void AddMoneyForKilled(int money)
    {
        amountOfMoney += money;
        //PlayerPrefs.SetInt("currentLevelMoney", amountOfMoney);
        Debug.Log("CurrentMoney " + amountOfMoney);
    }

    public void AmountResourcesEndLevel()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            _amountOfMoneyEndLevel.text = "Reward for murder: " + amountOfMoney;
            _amountOfZombieTextEndLevel.text = "Killed: " + amountKilledEnemies;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            _amountOfMoneyEndLevel.text = "Награда за убийство: " + amountOfMoney;
            _amountOfZombieTextEndLevel.text = "Уничтожено: " + amountKilledEnemies;
        }
        else
        {
            _amountOfMoneyEndLevel.text = "Reward for murder: " + amountOfMoney;
            _amountOfZombieTextEndLevel.text = "Killed: " + amountKilledEnemies;
        }
    }

    public void AmountKilledEndLevel()
    {
        if (Language.Instance.currentLanguage == "en")
        {
            _amountOfMoneyPlayerDeath.text = "Reward for murder: " + amountOfMoney;
            _amountOfZombieTextPlayerDeath.text = "Killed: " + amountKilledEnemies;
        }
        else if (Language.Instance.currentLanguage == "ru")
        {
            _amountOfMoneyPlayerDeath.text = "Награда за убийство: " + amountOfMoney;
            _amountOfZombieTextPlayerDeath.text = "Уничтожено: " + amountKilledEnemies;
        }
        else
        {
            _amountOfMoneyPlayerDeath.text = "Reward for murder: " + amountOfMoney;
            _amountOfZombieTextPlayerDeath.text = "Killed: " + amountKilledEnemies;
        }
    }

    public void RewardForHard(int price)
    {
        if (Language.Instance.currentLanguage == "en")
            _rewardForHardText.text = "Difficulty Reward: " + price;
        else if (Language.Instance.currentLanguage == "ru")
            _rewardForHardText.text = "Награда за сложность: " + price;
        else
            _rewardForHardText.text = "Difficulty Reward: " + price;
    }

    public void CurrentTimeEndLevel()
    {
        int minutes = Mathf.FloorToInt(_timer._elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_timer._elapsedTime % 60);
        _currentTimeLevel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateAmountZombies()
    {
        _amountOfZombieText.text = amountKilledEnemies.ToString();
        _amountOfMoney.text = amountOfMoney.ToString();
    }
}
