using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private AmountKillZombies _amountKillZombies;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _dieOrAliveScreen;

    private void Awake()
    {
        _deathScreen.SetActive(false);
    }

    public void CallDieOrAliveScreen()
    {
        Time.timeScale = 0f;
        _dieOrAliveScreen.SetActive(true);
    }

    public void CallDeathScreen()
    {
        _dieOrAliveScreen.SetActive(false);

        _amountKillZombies.AmountKilledEndLevel();

        SaveManager.instance.killedZombies += _amountKillZombies.amountKilledEnemies;
        SaveManager.instance.money += _amountKillZombies.amountOfMoney;

        SaveManager.instance.Save();

        _deathScreen.SetActive(true);
        Debug.Log("ScreenOnDeath");
    }
}
