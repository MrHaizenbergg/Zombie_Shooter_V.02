using UnityEngine;

public class WallBlowTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlesBlow;
    [SerializeField] private AudioSource _wallBreakAudioSource;
    [SerializeField] private SpriteRenderer _WallSprite;
    [SerializeField] private GameObject _explosePlace;
    private Collider2D _wallCollider;

    private void Awake()
    {
        _wallCollider = GetComponent<Collider2D>();
    }

    public void BreakWallBombTNT()
    {
        _wallBreakAudioSource.Play();
        _wallCollider.enabled = false;
        _WallSprite.sprite = null;
        _particlesBlow.gameObject.SetActive(true);

        if (_explosePlace != null)
            _explosePlace.gameObject.SetActive(false);

        Instantiate(_particlesBlow, transform.position, Quaternion.identity);
        Destroy(gameObject, 1.5f);
    }
}
