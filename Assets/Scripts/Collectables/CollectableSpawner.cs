using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _collectablePrefabs;

    private GameObject _selectedCollectable = null;

    public void SpawnCollectable(Vector2 position)
    {
        int index = Random.Range(0, _collectablePrefabs.Count);
        _selectedCollectable = _collectablePrefabs[index];

        Instantiate(_selectedCollectable,position,Quaternion.identity);
    }
}
