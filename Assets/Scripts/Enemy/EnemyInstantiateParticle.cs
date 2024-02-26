using UnityEngine;

public class EnemyInstantiateParticle : MonoBehaviour
{
    [SerializeField] private GameObject _particleSystem;

    public void BloodSplash()
    {
        Instantiate(_particleSystem, transform.position, Quaternion.identity);
    }
}
