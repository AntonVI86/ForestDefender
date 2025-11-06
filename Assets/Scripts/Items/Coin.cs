using UnityEngine;

public class Coin : Item
{
    public override void OnPickUp(GameObject owner)
    {
        owner.GetComponent<WellInteractor>().EnableSpawningItemInNextInteraction();
    }

    public override bool CanUse(GameObject owner)
    {
        bool interact = owner.GetComponent<WellInteractor>().Interacting;

        return interact;
    }
}
