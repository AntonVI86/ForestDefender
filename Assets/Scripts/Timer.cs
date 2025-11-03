using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime;
    public float CurrentTime => _currentTime;

    public void ProcessTimeFlow() =>
        _currentTime += Time.deltaTime;

    public void ResetTime() => _currentTime = 0;
}
