using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }
    public void PlayPerfomAction(string animationName)
    {
        _animator.SetTrigger(animationName);
    }

    public void IsPlayLoopingAnimation(string animationName, bool value)
    {
        _animator.SetBool(animationName, value);
    }
}
