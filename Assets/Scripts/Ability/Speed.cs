using UnityEngine;

public class Speed : Ability
{
    [SerializeField] private float _defaultSpeed;

    private float _value;
    public bool IsSpeedUp
    {
        get
        {
            if (_value > _defaultSpeed)
                return true;

            Vfx.Stop();
            return false;
        }
    }

    public float Value => _value;

    private void Awake() => ResetSpeed();

    public void ResetSpeed() => _value = _defaultSpeed;

    public override void IncreaseStat(float value)
    {
        if (value < 0)
            return;

        _value += value;
        Vfx.Play();
    }
}
