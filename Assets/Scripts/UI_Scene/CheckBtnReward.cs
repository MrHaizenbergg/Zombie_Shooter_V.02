using UnityEngine;

public class CheckBtnReward : MonoBehaviour
{
    [SerializeField] private GameObject _rewardBtnX3;

    [SerializeField] private AmountKillZombies _amountKillZombies;

    private void Start()
    {
        if (_amountKillZombies.amountOfMoney <= 0)
            _rewardBtnX3.SetActive(false);
        else
            _rewardBtnX3.SetActive(true);
    }
}
