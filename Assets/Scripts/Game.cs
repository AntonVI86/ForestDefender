using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private ItemSpawner _itemSpawner;

    [SerializeField] private Health _health;
    [SerializeField] private CharacterMover _mover;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private Transform _playerDefaultPoint;

    [SerializeField] private TMP_Text _gameResults;

    private KeyCode _restartGameKey = KeyCode.F;

    private void Update()
    {
        if (_health.IsAlive == false)
            GameOver();

        if(IsWin())
            Win();
    }

    private void Win()
    {
        _gameResults.text = $"Победа!\nТы успешно отразил атаку тёмных друидов!" +
            $"\n\nДревний колодец снова в безопасности." +
            $"\nНажмите {_restartGameKey}, чтобы начать заново...";
        StartGameProcess();
    }

    private void GameOver()
    {
        _health.enabled = false;
        _playerInput.enabled = false;
        _mover.ResetSpeed();
        _gameResults.text = $"Поражение!\nТы пал под натиском тёмных друидов, и древний колодец остался без защитника." +
            $"\nНажмите {_restartGameKey}, чтобы начать заново...";
        StartGameProcess();
    }

    private void StartGameProcess()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _gameResults.text = "";

            _health.transform.position = _playerDefaultPoint.position;
            _health.enabled = true;
            _health.ResetHealth();

            _playerInput.enabled = true;

            _enemySpawner.ResetValues();
            _itemSpawner.ResetValues();
            _coinSpawner.ResetValues();
        }            
    }

    private bool IsWin() => _enemySpawner.GetRemainCountEnemies() <= 0;
}
