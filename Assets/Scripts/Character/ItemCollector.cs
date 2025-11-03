using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _itemSlot;
    [SerializeField] private AbilityHandler _ability;

    private Item _currentItem;

    public void UseItem() 
    {
        if (_currentItem == null)
            return;

        if (_currentItem.TryGetComponent(out Coin coin))
            return;

        if(_currentItem.TryGetComponent(out Ember magicScroll))
        {
            magicScroll.Use(this);
            return;
        }

        _ability.ApplyItemToStat(_currentItem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Item item))
        {
            if (item.TryGetComponent(out Bomb bomb))
                return;

            if (_currentItem == null)
                GetItem(item);
        }

        if(other.TryGetComponent(out ItemSpawner well))
        {
            if (_currentItem == null)
                return;

            if (_currentItem.TryGetComponent(out Coin coin) == false)
                return;

            DropItem(_currentItem);
            well.Create();
        }
    }

    private void GetItem(Item item)
    {
        item.transform.SetParent(_itemSlot);
        item.transform.position = _itemSlot.transform.position;
        _currentItem = item;
    }

    private void DropItem(Item item)
    {
        Destroy(item.gameObject);
        item = null;
    }
}
