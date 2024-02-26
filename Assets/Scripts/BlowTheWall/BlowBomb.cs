using UnityEngine;

public class BlowBomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem _missleExplosion;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _timeForDestroy = 3f;
    [SerializeField] private SpriteRenderer _bombSprite;

    [SerializeField] private AudioSource _bombAudioSource; 

    private Rigidbody2D _rb;
    Collider2D[] isExplosionRadius = null;

    private void Start()
    {
        Invoke("Explosion", _timeForDestroy);
    }

    private void Explosion()
    {
        _bombAudioSource.Play();

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
                    if (rb.gameObject.CompareTag("BlowWall"))
                    {
                        rb.gameObject.GetComponent<WallBlowTrigger>().BreakWallBombTNT();
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
