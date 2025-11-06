using UnityEngine;

public class Bomb : Item
{
    [SerializeField] private ParticleSystem _explosionVfxPrefab;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _radiusOfExplosion;

    public override void Use(GameObject player)
    {
        gameObject.transform.SetParent(null);
        transform.position = player.transform.position;

        ProcessExplosion(transform.position);
    }

    private void ProcessExplosion(Vector3 vfxPosition)
    {
        ParticleSystem effect = Instantiate(_explosionVfxPrefab);
        effect.transform.position = vfxPosition;
        effect.transform.SetParent(null);
        effect.Play();

        Destroy(gameObject, _timeToDestroy);
    }

    private void DestroyFindingEnemies()
    {
        Collider[] characters = Physics.OverlapSphere(transform.position, _radiusOfExplosion);

        foreach (Collider character in characters)
            if (character.TryGetComponent(out Enemy enemy))
                enemy.ProcessDie();
    }

    private void OnDestroy()
    {
        DestroyFindingEnemies();
    }
}
