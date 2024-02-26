using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;

    [SerializeField] private GameObject[] _enemyPrefabs;

    [SerializeField] private int _spawnCount;

    private int _currentSpawned;
    private int _randomEnemy;

    private float _timeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_currentSpawned >= _spawnCount)
        {
            Destroy(gameObject);
        }
        else
        {
            if (_timeUntilSpawn <= 0)
            {
                _currentSpawned++;
                _randomEnemy=Random.Range(0, _enemyPrefabs.Length);
                Instantiate(_enemyPrefabs[_randomEnemy], transform.position, Quaternion.identity);

                SetTimeUntilSpawn();
            }
        }

    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

}
