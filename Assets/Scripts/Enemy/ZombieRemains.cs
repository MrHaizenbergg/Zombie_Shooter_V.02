using UnityEngine;

public class ZombieRemains : MonoBehaviour
{
    [SerializeField] private GameObject[] _bloodesPool;
    private int _bloodeRandom;

    public void SpawnBloodPool()
    {
        _bloodeRandom = Random.Range(0, _bloodesPool.Length);
        GameObject blood = Instantiate(_bloodesPool[_bloodeRandom], transform.position, Quaternion.identity);
        Destroy(blood,15f);
    }
}
