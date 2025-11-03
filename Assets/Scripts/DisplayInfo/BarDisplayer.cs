using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarDisplayer : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _healthInfo;

    private void Start() 
    {
        _healthBar.maxValue = _health.MaxHealth;
        _healthInfo.text = $"{_health.CurrentHealth} / {_health.MaxHealth}";
    }

    private void Update()
    {
        _healthBar.value = _health.CurrentHealth;
        _healthInfo.text = $"{Mathf.Round(_health.CurrentHealth)} / {_health.MaxHealth}";
    }
}
