using System;
using UnityEngine;

public class StandingState : State
{
    private readonly Command _keyW, _keyA, _keyS, _keyD;
    public StandingState(FrogMovementController inputHandler, StateMachine stateMachine, GameObject actor,
        AnimationCurve animationCurve, float distance, Action onLanding) : base(inputHandler, stateMachine)
    {
        _keyW = new Commands.Move(actor, animationCurve, 0, distance);
        _keyA = new Commands.Move(actor, animationCurve, -distance, 0);
        _keyS = new Commands.Move(actor, animationCurve, 0, -distance);
        _keyD = new Commands.Move(actor, animationCurve, distance, 0);
        _keyW.onCommandEnd += () => { onLanding?.Invoke(); };
        _keyA.onCommandEnd += () => { onLanding?.Invoke(); };
        _keyS.onCommandEnd += () => { onLanding?.Invoke(); };
        _keyD.onCommandEnd += () => { onLanding?.Invoke(); };
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.ChangeState(inputHandler.StateJump);
            _keyW.Execute();
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            stateMachine.ChangeState(inputHandler.StateJump);
            _keyA.Execute(); 
        }
        if ( Input.GetKeyDown(KeyCode.S))
        {
            stateMachine.ChangeState(inputHandler.StateJump);
            _keyS.Execute(); 
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            stateMachine.ChangeState(inputHandler.StateJump);
            _keyD.Execute(); 
        }
    }
}
