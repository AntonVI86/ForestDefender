using UnityEngine;

public class Health : Ability
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private CharacterAnimator _animator;

    private float _health;

    public bool IsAlive
    {
        get
        {
            if (_health <= 0)
                return false;

            return true;
        }
    }

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

    private void Awake() =>
        ResetHealth();

    public void TakeDamage(float damage)
    {
        string deathAnimationKey = "Death";

        if (damage < 0)
            return;

        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            _animator.PlayPerfomAction(deathAnimationKey);
        }
    }

    public override void IncreaseStat(float value)
    {
        if (value < 0)
            return;

        _health += value;
        Vfx.Play();

        if (_health >= _maxHealth)
            _health = _maxHealth;
    }

    public void ResetHealth() 
    {
        string idleAnimationName = "Idle";

        _animator.PlayAnimation(idleAnimationName);
        _health = _maxHealth;
    } 
    
}
