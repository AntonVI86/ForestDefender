using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathVfxPrefab;

    private Attacker _attacker;
    private Health _player;

    private float _speedRotation = 600f;

    public Health Player => _player;

    private void Awake() =>
        _attacker = GetComponent<Attacker>();

    private void Update()
    {
        if (_player == null)
            return;

        Vector3 direction = _player.transform.position - transform.position;

        RotateTo(direction.normalized);
        _attacker.ProcessAttack();
    }

    public void GetPlayer()
    {
        _player = GetComponentInParent<PlayerGetter>().Player;
    }

    private void RotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _speedRotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fireball fireball))
        {
            ParticleSystem deathEffect = Instantiate(_deathVfxPrefab, transform);
            deathEffect.transform.SetParent(null);

            Destroy(fireball.gameObject);
            Destroy(gameObject);
        }
    }
}
