using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BreakBox : MonoBehaviour
{
    [SerializeField] private ParticleSystem _boxCrashed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public UnityEvent isBreakBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>())
        {
            StartCoroutine(BreakBoxCoroutine(collision));      
        }
    }

    public void StartCoroutineBreakBox()
    {
        StartCoroutine(BreakBoxCoroutineForGrenade());
    }

    private IEnumerator BreakBoxCoroutineForGrenade()
    {
        _boxCrashed.Play();
        _spriteRenderer.enabled = false;
        isBreakBox.Invoke();

        yield return new WaitForSeconds(_boxCrashed.main.startLifetime.constantMax);
        Destroy(gameObject);
    }

    private IEnumerator BreakBoxCoroutine(Collider2D coll)
    {
        _boxCrashed.Play();
        _spriteRenderer.enabled= false;
        Destroy(coll.gameObject);
        isBreakBox.Invoke();


        yield return new WaitForSeconds(_boxCrashed.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
