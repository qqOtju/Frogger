public abstract class State
{
    protected readonly FrogMovementController inputHandler;
    protected readonly StateMachine stateMachine;
    protected State(FrogMovementController inputHandler, StateMachine stateMachine)
    {
        this.inputHandler = inputHandler;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
        
    }

    public virtual void Update()
    {
        
    }
    public virtual void Exit()
    {

    }
}