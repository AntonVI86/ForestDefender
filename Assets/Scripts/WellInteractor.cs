using UnityEngine;

public class WellInteractor : MonoBehaviour
{
    [SerializeField] private ItemCollector _collector;

    private bool _canSpawnItem = false;
    private bool _interacting = false;

    public bool Interacting => _interacting;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ItemSpawner spawner))
        {
            if (_canSpawnItem)
            {
                spawner.Create();
                _canSpawnItem = false;
                _collector.DropItem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ItemSpawner spawner))
            _interacting = false;
    }

    public void EnableSpawningItemInNextInteraction() => _canSpawnItem = true;
}
