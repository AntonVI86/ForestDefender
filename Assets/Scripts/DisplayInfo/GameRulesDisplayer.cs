using TMPro;
using UnityEngine;

public class GameRulesDisplayer : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TMP_Text _gameRules;
    [SerializeField] private Timer _timer;

    [SerializeField] private float _timeToShowInfo;

    private void Start()
    {
        ShowGameRules();    
    }

    private void Update()
    {
        if(_timer.CurrentTime < _timeToShowInfo)
        {
            _timer.ProcessTimeFlow();
            return;
        }

        _gameRules.text = "";
        this.enabled = false;
    }

    private void ShowGameRules()
    {
        string rules = "Древний колодец подвергся атаке. " +
            "Твоя задача выжить и защитить его. Каждая брошенная в колодец монетка даст тебе предмет для борьбы с захватчиками. " +
            $"Использовать предмет клавиша {_playerInput.UseItemKey}.";

        _gameRules.text = rules;
    }
}
