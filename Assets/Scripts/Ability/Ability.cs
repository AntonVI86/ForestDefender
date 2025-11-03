using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected ParticleSystem Vfx;
    public abstract void IncreaseStat(float value);
}
