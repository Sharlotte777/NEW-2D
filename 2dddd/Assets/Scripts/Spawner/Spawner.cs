using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : Item
{
    [SerializeField][Range(1, 10)] private float _timeToSpawn = 5f;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private T _prefab;

    private float _radius = 1f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitSpawn = new(_timeToSpawn);

        while (enabled)
        {
            yield return waitSpawn;

            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                SpawnPoint spawnPoint = _spawnPoints[i];
                CreateObject(spawnPoint);
            }
        }
    }

    private void CreateObject(SpawnPoint spawnPoint)
    {
        if (SearchObject(spawnPoint) == false)
        {
            Instantiate(_prefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    private bool SearchObject(SpawnPoint spawnPoint)
    {
        bool haveItem = false;

        Collider2D[] objects = Physics2D.OverlapCircleAll(spawnPoint.transform.position, _radius);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.TryGetComponent(out T item))
            {
                haveItem = true;
            }
        }

        return haveItem;
    }
}
