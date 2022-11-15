using System;
using UnityEngine;

public class FrogMovementController : MonoBehaviour
{
    [SerializeField] private GameStatusEvent onGameStatusChange;
    [SerializeField] private AnimationCurve animationCurve;
    [Header("Effects")]
    [SerializeField] private ParticleSystem[] landingEffect;
    [SerializeField] private ParticleSystem[] jumpEffect;
    [Space(20f)]
    [SerializeField] private GameObject actor;
    public StandingState StateStanding { private set; get; }
    public JumpState StateJump { private set; get; }

    private Command _keyW, _keyA, _keyS, _keyD;
    private StateMachine _stateMachine;
    private float distance = 1.75f;
    private GameStatus _status;
    private void Awake()
    {
        onGameStatusChange.Event += status =>
        {
            _status = status switch
            {
                GameStatus.Game => GameStatus.Game,
                GameStatus.Pause => GameStatus.Pause,
                _ => _status
            };
        };
    }
    private void Start()
    {
        _stateMachine = new StateMachine();
        StateJump = new JumpState(this, _stateMachine, landingEffect, jumpEffect, actor);
        StateStanding = new StandingState(this, _stateMachine, actor, animationCurve, distance, StateJump.OnLanding);
        _stateMachine.Initialize(StateStanding);
    }

    private void Update()
    {
        if(_status == GameStatus.Pause)
            return;
        _stateMachine.CurrentState.Update();
    }
}
