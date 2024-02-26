using UnityEngine;

public class ExplosionBarrel : MonoBehaviour
{
    [SerializeField] private ParticleSystem _missleExplosion;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private SpriteRenderer _bombSprite;

    private Rigidbody2D _rb;
    Collider2D[] isExplosionRadius = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.GetComponent<EnemyMovement>())
        //{
        //    Explosion();
        //}
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Explosion();
        }
        if (collision.gameObject.GetComponent<MissleExplosion>())
        {
            Explosion();          
        }
    }

    private void Explosion()
    {
        _bombSprite.sprite = null;
        _missleExplosion.gameObject.SetActive(true);
        Instantiate(_missleExplosion, transform.position, Quaternion.identity);

        isExplosionRadius = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (Collider2D obj in isExplosionRadius)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 distanceVector = obj.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float explosionForce = _explosionForce / distanceVector.magnitude;
                    rb.AddForce(distanceVector.normalized * explosionForce);
                    HealthController healthController = rb.gameObject.GetComponent<HealthController>();
                    if (healthController != null)
                    {
                        healthController.TakeDamage(50);
                        Debug.Log("KillEnemy " + rb.name);
                    }
                }
            }
        }

        Destroy(gameObject, 1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
