using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Item _coinPrefab;
    [SerializeField] private float _coolDown;

    [SerializeField] private Timer _timer;

    private void Update()
    {
        _timer.ProcessTimeFlow();

        if (_timer.CurrentTime >= _coolDown)
        {
            EmptySpawnPoints = GetEmptySpawnPoint();

            if (EmptySpawnPoints.Count == 0)
            {
                _timer.ResetTime();
                return;
            }

            Create();
        }
    }

    public override void Create()
    {
        ItemSpawnPoint point = (ItemSpawnPoint)EmptySpawnPoints[Random.Range(0, EmptySpawnPoints.Count)];

        Item newItem = Instantiate(_coinPrefab, point.Position, Quaternion.identity);

        newItem.transform.SetParent(transform);

        point.Occupy(newItem);

        _timer.ResetTime();
    }

    public void ResetValues()
    {
        _timer.ResetTime();

        if (transform.childCount > 0)
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
    }
}
