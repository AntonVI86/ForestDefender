using UnityEngine;

public class Attacker : MonoBehaviour
{
    public const string AttackAnimationKey = "Attack";

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Missile _stonePrefab;
    [SerializeField] private CharacterAnimator _animator;

    [SerializeField] private Timer _timer;

    [SerializeField] private float _minCoolDownValue = 2f;
    [SerializeField] private float _maxCoolDownValue = 5f;

    private float _coolDown;

    private void Start() =>
        SetCoolDownValue();

    public void ProcessAttack()
    {
        if (IsTimerReachedValue() == false)
            _timer.ProcessTimeFlow();
    }

    private bool IsTimerReachedValue()
    {
        if (_timer.CurrentTime > _coolDown)
        {
            Attack();
            return true;
        }

        return false;
    }

    private void Attack()
    {
        _animator.PlayPerfomAction(AttackAnimationKey);

        Missile missile = Instantiate(_stonePrefab, _attackPoint);
        missile.transform.SetParent(null);

        _timer.ResetTime();
        SetCoolDownValue();
    }

    private void SetCoolDownValue() => _coolDown = Random.Range(_minCoolDownValue, _maxCoolDownValue);
}
