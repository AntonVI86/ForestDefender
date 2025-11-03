using UnityEngine;

public class Ember : Item
{
    [SerializeField] private Missile _fireballPrefab;

    public void Use(ItemCollector collector)
    {
        float offsetY = 1f;

        Vector3 attackPosition = new Vector3(collector.transform.position.x, collector.transform.position.y + offsetY, collector.transform.position.z);
        
        Missile _fireball = Instantiate(_fireballPrefab, attackPosition, Quaternion.identity);

        _fireball.transform.rotation = collector.transform.rotation;
        _fireball.transform.SetParent(null);

        Destroy(gameObject);
    }
}
