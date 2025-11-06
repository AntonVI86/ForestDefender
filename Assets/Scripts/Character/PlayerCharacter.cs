using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public const string HorizontalAxis = "Horizontal";
    public const string VerticalAxis = "Vertical";

    public const string RunAnimationKey = "IsRun";

    private CharacterMover _mover;
    private CharacterRotator _rotator;
    private CharacterAnimator _animator;
    private ItemCollector _collector;

    private Vector3 _input;

    private float _deadZone = 0.05f;

    private KeyCode _useItemKey = KeyCode.E;

    public KeyCode UseItemKey => _useItemKey;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
        _rotator = GetComponent<CharacterRotator>();
        _animator = GetComponent<CharacterAnimator>();
        _collector = GetComponent<ItemCollector>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_useItemKey))
            _collector.UseItem();

        _input = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis)).normalized;

        if (_input.magnitude <= _deadZone)
        {
            _animator.IsPlayLoopingAnimation(RunAnimationKey, false);
            return;
        }

        _animator.IsPlayLoopingAnimation(RunAnimationKey, true);
        _rotator.ProcessRotateTo(_input);
    }

    private void FixedUpdate() =>
        _mover.ProcessMoveTo(_input);
}
