using UnityEngine;

public class PlayerGetter : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    public Health PlayerHealth => _playerHealth;
}
