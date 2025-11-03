using UnityEngine;

public class EnemySpawnPoint : SpawnPoint
{
    private Enemy _enemy;

    public override bool IsEmpty
    {
        get
        {
            if (_enemy == null)
                return true;

            if (_enemy.gameObject == null)
                return true;

            return false;
        }
    }

    public void Occupy(Enemy enemy) =>
        _enemy = enemy;
}
