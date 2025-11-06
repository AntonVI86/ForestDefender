using UnityEngine;

public class Ember : Item
{
    [SerializeField] private Missile _fireballPrefab;

    public override void Use(GameObject player)
    {
        float offsetY = 1f;

        Vector3 attackPosition = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z);
        
        Missile _fireball = Instantiate(_fireballPrefab, attackPosition, Quaternion.identity);

        _fireball.transform.rotation = player.transform.rotation;
        _fireball.transform.SetParent(null);

        base.Use(player);
    }
}
