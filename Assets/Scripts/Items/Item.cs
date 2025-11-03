using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float _value;

    public float Value => _value;
    
    public void UseTo(Ability stat)
    {
        Destroy(gameObject);
        stat.IncreaseStat(_value);
    }
}
