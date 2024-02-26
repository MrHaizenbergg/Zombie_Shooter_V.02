using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvulnerability(float invulnerabilityDuration)
    {
        StartCoroutine(InvulnerabilityCoroutine(invulnerabilityDuration));
    }

    private IEnumerator InvulnerabilityCoroutine(float invulnerabilityDuration)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        _healthController.IsInvincible = false;
    }
}
