using UnityEngine;

public class PotionOfSpeed : Item
{
    [SerializeField] private float _speedUpValue;

    public override void Use(GameObject player)
    {
        Speed speed = player.GetComponent<Speed>();
        speed.Increase(_speedUpValue);
        base.Use(player);
    }
}
