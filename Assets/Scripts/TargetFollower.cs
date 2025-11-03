using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _offset = -10f;

    private void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, transform.position.y, transform.position.z);
    }
}
