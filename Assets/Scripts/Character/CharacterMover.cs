using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Speed _speed;

    private Rigidbody _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    public void ProcessMoveTo(Vector3 direction) =>
        _rigidbody.velocity = direction * _speed.CurrentSpeed;

    public void ResetSpeed() => _rigidbody.velocity = Vector3.zero;
}
