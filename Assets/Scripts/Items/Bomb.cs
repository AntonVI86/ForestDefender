using UnityEngine;

public class Bomb : Item
{
    [SerializeField] private ParticleSystem _explosionVfxPrefab;

    private void Start()
    {
        ProcessExplosion();
    }

    private void ProcessExplosion()
    {
        ParticleSystem effect = Instantiate(_explosionVfxPrefab);
        effect.transform.position = transform.position;
        effect.transform.SetParent(null);
        effect.Play();

        Destroy(gameObject, _value);
    }
}
