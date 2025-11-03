using UnityEngine;

public class FrostBall : Missile
{
    [SerializeField] private float _minDamageValue;
    [SerializeField] private float _maxDamageValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Health health))
        {
            float damage = Random.Range(_minDamageValue, _maxDamageValue);

            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
