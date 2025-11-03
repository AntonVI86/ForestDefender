using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Speed _speed;

    [SerializeField] private Timer _timer;

    public void ApplyItemToStat(Item item)
    {
        if(item.TryGetComponent(out HealthPotion potion))
            item.UseTo(_health);

        if (item.TryGetComponent(out PotionOfSpeed speedPotion))
        {
            item.UseTo(_speed);
            _timer.ResetTime();
        }
    }

    private void Update()
    {
        if (_speed.IsSpeedUp == false)
            return;

        if(IsTimerReachedValue() == false)
            _timer.ProcessTimeFlow();
    }

    private bool IsTimerReachedValue()
    {
        float coolDown = 5f;

        if (_timer.CurrentTime > coolDown)
        {
            _speed.ResetSpeed();
            return true;
        }

        return false;
    }
}
