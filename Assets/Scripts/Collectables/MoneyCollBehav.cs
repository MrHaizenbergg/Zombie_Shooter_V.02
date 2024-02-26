using UnityEngine;

public class MoneyCollBehav : MonoBehaviour,ICollectableBehaviour
{
    private int _moneyAmount;
    private AmountKillZombies _amountKillZombies;

    private void Awake()
    {
        _amountKillZombies=FindObjectOfType<AmountKillZombies>();
    }

    private void Start()
    {
        _moneyAmount = Random.Range(10, 50);
    }

    public void OnCollected(GameObject player)
    {
        _amountKillZombies.AddMoneyForKilled(_moneyAmount);
        _amountKillZombies.UpdateAmountZombies();
    }
}
