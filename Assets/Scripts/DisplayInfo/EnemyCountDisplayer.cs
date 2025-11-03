using TMPro;
using UnityEngine;

public class EnemyCountDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _info;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Update() =>
        _info.text = _enemySpawner.GetRemainCountEnemies().ToString();
}
