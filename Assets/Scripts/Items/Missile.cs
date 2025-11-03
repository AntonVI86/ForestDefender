using UnityEngine;

public abstract class Missile : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private float _timeToDestroy = 2f;

    public virtual void Start() =>
        Destroy(gameObject, _timeToDestroy);

    public virtual void Update() =>
        transform.Translate(Vector3.forward * _speedMove * Time.deltaTime, Space.Self);

}
