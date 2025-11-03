using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected List<SpawnPoint> SpawnPoints;

    protected List<SpawnPoint> EmptySpawnPoints = new();

    public abstract void Create();

    protected List<SpawnPoint> GetEmptySpawnPoint()
    {
        List<SpawnPoint> emptySpawnPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in SpawnPoints)
        {
            if (point.IsEmpty)
                emptySpawnPoints.Add(point);
        }

        return emptySpawnPoints;
    }
}
