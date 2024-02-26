using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarForegImage;

    public void UpdateHealthBar(HealthController healthController)
    {
        _healthBarForegImage.fillAmount = healthController.RemaininHealthPercentage;
    }
}
