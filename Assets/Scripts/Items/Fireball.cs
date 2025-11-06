using UnityEngine;

public class Fireball : Missile
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.ProcessDie();
            Destroy(gameObject);
        }
    }
}
