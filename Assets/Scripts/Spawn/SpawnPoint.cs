using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour
{
    public abstract bool IsEmpty { get; }
    public Vector3 Position => transform.position;
}
