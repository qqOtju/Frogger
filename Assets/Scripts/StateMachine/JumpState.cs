using System;
using UnityEngine;

public class JumpState : State
{
    private readonly ParticleSystem[] _landingEffect;
    private readonly ParticleSystem[] _jumpEffect;
    private readonly Transform _actorTransform;
    public JumpState(FrogMovementController inputHandler, StateMachine stateMachine, ParticleSystem[] landingEffect, 
        ParticleSystem[] jumpEffect, GameObject actor) : base(inputHandler, stateMachine)
    {
        _actorTransform = actor.transform;
        _landingEffect = landingEffect;
        _jumpEffect = jumpEffect;
    }

    public void OnLanding()
    {
        stateMachine.ChangeState(inputHandler.StateStanding);
    }

    public override void Enter()
    {
        base.Enter();
        _actorTransform.localScale += new Vector3(0.2f, 0.2f,0);
        foreach(ParticleSystem effect in _jumpEffect)
            effect.Play();
    }

    public override void Exit()
    {
        base.Exit();
        _actorTransform.localScale -= new Vector3(0.2f, 0.2f,0);
        foreach(ParticleSystem effect in _landingEffect)
            effect.Play();
    }
}
