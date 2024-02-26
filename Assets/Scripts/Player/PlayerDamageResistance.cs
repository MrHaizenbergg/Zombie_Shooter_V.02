using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageResistance : MonoBehaviour
{
    private InvincibilityController _invincibilityController;
    [SerializeField] private float _invincibilitiDuration;

    private void Awake()
    {
        _invincibilityController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility()
    {
        _invincibilityController.StartInvulnerability(_invincibilitiDuration);
    }
}
