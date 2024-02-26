using UnityEngine;
using UnityEngine.UI;

public class DiedChoiseBtn : MonoBehaviour
{
    private Button _dieBtn;
    private PlayerMovement _player;

    private void Awake()
    {
        _dieBtn = GetComponent<Button>();
        _player = FindObjectOfType<PlayerMovement>();
    }

    private void OnEnable()
    {
        _dieBtn.onClick.AddListener(_player.GetComponent<HealthController>().OnDied.Invoke);
    }

    private void OnDisable()
    {
        _dieBtn.onClick.RemoveListener(_player.GetComponent<HealthController>().OnDied.Invoke);
    }
}
