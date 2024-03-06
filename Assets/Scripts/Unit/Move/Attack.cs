public abstract class Attack
{
    protected Unit attacker;
    protected Unit target;

    public Attack(Unit attacker, Unit target)
    {
        this.attacker = attacker;
        this.target = target;
    }

    public abstract void ExecuteAction();

}
