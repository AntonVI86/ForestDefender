using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private float _healValue;

    public override void Use(GameObject player)
    {
        Health health = player.GetComponent<Health>();
        health.Increase(_healValue);

        base.Use(player);
    }
}
