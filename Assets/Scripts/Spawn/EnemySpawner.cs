using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private ParticleSystem _spawnVfx;

    [SerializeField] private int _defultEnemyCount;
    [SerializeField] private float _coolDown;

    [SerializeField] private Timer _timer;

    private int _enemyCount;

    private void Awake() =>
        ResetValues();

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
        if (_enemyCount == 0)
            return;

        EnemySpawnPoint point = (EnemySpawnPoint)EmptySpawnPoints[Random.Range(0, EmptySpawnPoints.Count)];

        Enemy newEnemy = Instantiate(_enemyPrefab, point.Position, Quaternion.identity);
        newEnemy.transform.SetParent(transform);
        newEnemy.Initialize();

        Instantiate(_spawnVfx, point.transform);

        _enemyCount--;

        point.Occupy(newEnemy);

        _timer.ResetTime();
    }

    public int GetRemainCountEnemies() => transform.childCount + _enemyCount;

    public void ResetValues()
    {
        _enemyCount = _defultEnemyCount;
        _timer.ResetTime();

        if(transform.childCount > 0)
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
    }
}
