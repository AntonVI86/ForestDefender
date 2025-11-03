using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _speed * Time.deltaTime;
        
        Quaternion dir = Quaternion.RotateTowards(transform.localRotation, lookRotation, step);

        transform.rotation = dir;
    }
}
