using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnowPlayer : MonoBehaviour
{
    [SerializeField] private float _awarenessDistance;

    public Transform _player;

    public bool awareOfPlayer { get; private set; }

    public Vector2 directionToPlayer { get; private set; }

    private void Awake()
    {
       _player = FindObjectOfType<PlayerMovement>().transform;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, _awarenessDistance);
    //}

    public void TriggerEnemy()
    {
        _awarenessDistance = 50;
    }

    private void Update()
    {
        Vector2 enemyToPlayerVector= _player.position-transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _awarenessDistance)
        {
            awareOfPlayer = true;
        }
        else
        {
            awareOfPlayer= false;
        }
    }
}
