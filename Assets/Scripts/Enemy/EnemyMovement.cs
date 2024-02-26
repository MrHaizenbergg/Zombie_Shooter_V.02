using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rb;
    private EnemyKnowPlayer _enemyKnowPlayer;
    private Vector2 _targetDirection;
    private float _changeDirCooldown;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyKnowPlayer = GetComponent<EnemyKnowPlayer>();
        _targetDirection = transform.up;
    }


    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirection();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirection()
    {
        _changeDirCooldown -= Time.deltaTime;

        if (_changeDirCooldown <= 0)
        {
            float angleChange = Random.Range(-180f, 180f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;
            _changeDirCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_enemyKnowPlayer.awareOfPlayer)
        {
            _targetDirection = _enemyKnowPlayer.directionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRot = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRot, _rotationSpeed * Time.deltaTime);

        _rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rb.velocity = transform.up * _enemySpeed;      
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
