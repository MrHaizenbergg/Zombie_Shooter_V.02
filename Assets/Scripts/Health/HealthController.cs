using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    public float maxHealth;

    private HealthBarUI _barUI;
    private AmountKillZombies _amountKillZombies;
    private VictoryScreen _victoryScreen;
    private DeathScreen _deathScreen;

    public UnityEvent OnDied;
    public UnityEvent OnDiedForAds;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    public bool IsInvincible;
    private bool IsAlive;

    private void Awake()
    {
        IsAlive = false;
        _barUI = FindObjectOfType<HealthBarUI>();
        _amountKillZombies = FindObjectOfType<AmountKillZombies>();
        _victoryScreen = FindObjectOfType<VictoryScreen>();
        _deathScreen = FindObjectOfType<DeathScreen>();
    }

    private void Start()
    {
        maxHealth = _maxHealth;

        if (gameObject.CompareTag("Player"))
        {
            OnHealthChanged.AddListener(delegate { _barUI.UpdateHealthBar(this); });
            OnDiedForAds.AddListener(_deathScreen.CallDieOrAliveScreen);
            OnDied.AddListener(_deathScreen.CallDeathScreen);
        }
    }

    public void AddKilledEnemy(int money)
    {
        _amountKillZombies.amountKilledEnemies++;
        _amountKillZombies.AddMoneyForKilled(money);
        _amountKillZombies.UpdateAmountZombies();
        Debug.Log("CurrentKilled " + _amountKillZombies.amountKilledEnemies);
    }

    public float RemaininHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                if (!IsAlive)
                {
                    OnDiedForAds.Invoke();
                    IsAlive = true;
                }
                else
                    OnDied.Invoke();
            }
            else
                OnDied.Invoke();
        }
        else
            OnDamaged.Invoke();

        OnHealthChanged.Invoke();
    }

    public void AddHeatlh(float amountToAdd)
    {
        if (_currentHealth == _maxHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        OnHealthChanged.Invoke();
    }
}
