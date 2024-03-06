public abstract class StatusEffect
{
    protected Unit unitAffected;
    protected int duration;
    
    public StatusEffect(Unit unit)
    {
        unitAffected = unit;
    }

    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
    public void UpdateDuration()
    {
        duration -= 1;
        if (duration <= 0)
        {
            RemoveEffect();
        }
    }
}
