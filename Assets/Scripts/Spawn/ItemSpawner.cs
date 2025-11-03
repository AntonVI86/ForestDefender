using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [SerializeField] private List<Item> _itemPrefabs;
    [SerializeField] private ParticleSystem _createVfx;

    public override void Create()
    {
        EmptySpawnPoints = GetEmptySpawnPoint();

        if(EmptySpawnPoints.Count > 0)
        {
            int indexOfItem = Random.Range(0, _itemPrefabs.Count);

            ItemSpawnPoint point = (ItemSpawnPoint)EmptySpawnPoints[Random.Range(0, EmptySpawnPoints.Count)];

            Item newItem = Instantiate(_itemPrefabs[indexOfItem], point.Position, Quaternion.identity);

            newItem.transform.SetParent(transform);

            Instantiate(_createVfx, point.transform);

            point.Occupy(newItem);
        }
    }

    public void ResetValues()
    {
        if (transform.childCount > 0)
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
    }
}
