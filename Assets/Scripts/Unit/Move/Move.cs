public abstract class Move
{
    protected Unit actor;
    protected Unit target;

    public Move(Unit actor, Unit target)
    {
        this.actor = actor;
        this.target = target;
    }

    public abstract void ExecuteAction();

}
