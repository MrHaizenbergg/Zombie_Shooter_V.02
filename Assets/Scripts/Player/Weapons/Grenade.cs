using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private ParticleSystem _grenadeExplosion;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _timeForDestroy = 2f;

    [SerializeField] private SpriteRenderer _grenadeSprite;
    [SerializeField] private AudioSource _grenadeAudioSource;

    private Rigidbody2D _rb;
    Collider2D[] isExplosionRadius = null;

    private void Start()
    {   
        Invoke("Explosion",_timeForDestroy);
    }

    private void Explosion()
    {
        _grenadeAudioSource.Play();

        _grenadeSprite.sprite = null;
        _grenadeExplosion.gameObject.SetActive(true);
        Instantiate(_grenadeExplosion, transform.position, Quaternion.identity);

        isExplosionRadius = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (Collider2D obj in isExplosionRadius)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            BreakBox breakBox = obj.GetComponent<BreakBox>();
            if (breakBox != null)
            {
                breakBox.StartCoroutineBreakBox();
            }

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
