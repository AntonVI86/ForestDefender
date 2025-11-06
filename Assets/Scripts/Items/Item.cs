using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual void Use(GameObject player)
    {
        Destroy(gameObject);
    }

    public virtual void OnPickUp(GameObject owner)
    {
    }

    public virtual bool CanUse(GameObject owner) => true;
}
