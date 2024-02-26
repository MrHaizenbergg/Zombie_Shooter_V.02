using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardedBtn : MonoBehaviour
{
    [SerializeField] private int _rewardIndex;
    private Button _btnRewarded;

    private void Awake()
    {
        _btnRewarded = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _btnRewarded.onClick.AddListener(delegate { YandexGame.RewVideoShow(_rewardIndex); });
        Debug.Log("RewAddListener");
    }

    private void OnDisable()
    {
        _btnRewarded.onClick.RemoveListener(delegate { YandexGame.RewVideoShow(_rewardIndex); });
        //_btnRewarded.onClick.RemoveAllListeners();
        Debug.Log("RewDisable RemoveListeners");
    }
}
