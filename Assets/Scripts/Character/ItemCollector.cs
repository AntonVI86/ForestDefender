using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _itemSlot;

    private Item _currentItem;

    public void UseItem() 
    {
        if (_currentItem == null)
            return;

        if (_currentItem.CanUse(gameObject))
            _currentItem.Use(gameObject);
    }

    public void DropItem()
    {
        Destroy(_currentItem.gameObject);
        _currentItem = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Item item))
        {
            if (_currentItem == null)
            {
                item.OnPickUp(gameObject);
                GetItem(item);
            }
        }
    }

    private void GetItem(Item item)
    {
        item.transform.SetParent(_itemSlot);
        item.transform.position = _itemSlot.transform.position;
        _currentItem = item;
    }
}
