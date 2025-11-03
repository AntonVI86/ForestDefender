using UnityEngine;

public class PlayerGetter : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health Player => _health;
}
