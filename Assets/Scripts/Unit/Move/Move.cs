public abstract class Move
{
    protected Unit actor;

    public Move(Unit actor)
    {
        this.actor = actor;
    }

    public abstract void ExecuteAction();

}
