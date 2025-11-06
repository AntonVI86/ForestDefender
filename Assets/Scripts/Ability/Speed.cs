using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private ParticleSystem _vfx;

    [SerializeField] private Timer _timer;

    private float _timeActionOfSpeedUp = 5f;

    private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Awake() => ResetSpeed();

    private void Update()
    {
        if (_currentSpeed <= _defaultSpeed)
            return;

        _timer.ProcessTimeFlow();

        if (_timer.CurrentTime > _timeActionOfSpeedUp)
        {
            _vfx.Stop();
            ResetSpeed();
        }
    }

    public void ResetSpeed() => _currentSpeed = _defaultSpeed;

    public void Increase(float value)
    {
        if (value < 0)
            return;

        _timer.ResetTime();

        _currentSpeed += value;
        _vfx.Play();
    }
}
